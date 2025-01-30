using System;
using System.Numerics;
using System.Net.Http;
using System.Threading.Tasks;
using Dalamud.Interface.Windowing;
using ImGuiNET;
using System.Net.Http.Json;
using Dalamud.Utility;
using Dalamud.Logging;
using Dalamud.Plugin.Services;
using Dalamud.Loc;
using Dalamud.Interface.Utility.Table;
using DutyPusher.Services;
using System.Diagnostics;
using System.Threading.Channels;
using Newtonsoft.Json.Linq;

namespace DutyPusher.Windows
{
    public class ConfigWindow : Window, IDisposable
    {
        private Configuration Configuration;
        private string selectedChannel = ""; 
        private string barkServer = ""; // Bark Server 字段
        private string pushdeerKey = ""; // PushDeer 字段
        private string telegramBotToken = "";
        private string chatID = "";
        private bool enable = false;
        private bool barkTimeSensitive = false;
        private Plugin Plugin;

        private readonly IPluginLog PluginLog; // 添加私有字段用于存储接口实例

        private Localization Loc;

        public ConfigWindow(Plugin plugin, IPluginLog pluginLog, Localization loc) : base(loc.GetString("PluginName") +"###By MorCherlf")
        {
            Flags = ImGuiWindowFlags.NoCollapse;
            Size = new Vector2(800, 300);
            Configuration = plugin.Configuration;
            PluginLog = pluginLog;
            Plugin = plugin;
            Loc = loc;
            selectedChannel = Configuration.PushChannel;
            barkServer = Configuration.BarkServer;
            pushdeerKey = Configuration.PushDeerKey;
            telegramBotToken = Configuration.TelegramBotToken; 
            chatID = Configuration.TelegramChatID;
            enable = Configuration.Enable;
            barkTimeSensitive = Configuration.BarkTimeSensitive;
        }

        public void Dispose() { }

        public override void Draw()
        {

            ImGui.Text(Loc.GetString("WelcomeLine"));
            ImGui.SameLine();
            if (ImGui.Button(Loc.GetString("Guide")))
            {
                string url = Loc.GetString("GuideURL");

                try
                {
                    // 使用系统默认浏览器打开 URL
                    Process.Start(new ProcessStartInfo
                    {
                        FileName = url,
                        UseShellExecute = true // 在跨平台环境中必须启用
                    });
                }
                catch (Exception ex)
                {
                    // 在 Dalamud 日志中记录错误
                    PluginLog.Error($"Error: {ex.Message}");
                }
            }

            // 第一个下拉菜单，选择 Push Channel
            if (ImGui.BeginCombo(Loc.GetString("PushChannel"), selectedChannel))
            {
                if (ImGui.Selectable(Loc.GetString("Bark")))
                {
                    selectedChannel = "Bark";
                }

                if (ImGui.Selectable(Loc.GetString("PushDeer")))
                {
                    selectedChannel = "PushDeer";
                }

                if (ImGui.Selectable(Loc.GetString("TelegramOfficalAPI")))
                {
                    selectedChannel = "Telegram_Offical_API";
                }

                ImGui.EndCombo();
            }

            // 第二个文本框，根据选择的 Push Channel 改变内容
            switch (selectedChannel)
            {
                case "Bark":
                    ImGui.Text(Loc.GetString("BarkURL"));
                    ImGui.SameLine();
                    ImGui.InputText("##Bark", ref barkServer, 256);
                    ImGui.SameLine();
                    ImGui.Checkbox(Loc.GetString("TimeSensitive"), ref barkTimeSensitive);
                    break;
                case "PushDeer":
                    ImGui.Text(Loc.GetString("PushDeerKey"));
                    ImGui.SameLine();
                    ImGui.InputText("##PushDeer", ref pushdeerKey, 256);
                    break;
                case "Telegram_Offical_API":
                    ImGui.Text(Loc.GetString("TelegramBotToken"));
                    ImGui.SameLine();
                    ImGui.InputText("##BotToken", ref telegramBotToken, 256);
                    break;
            }
            ImGui.SameLine();
            if (ImGui.Button(Loc.GetString("Test")))
            {
                TestRequest();
            }
            switch (selectedChannel)
            {
                case "Telegram_Offical_API":
                    ImGui.Text(Loc.GetString("Chat_ID"));
                    ImGui.SameLine();
                    ImGui.InputText("##ChatID", ref chatID, 256);
                    ImGui.SameLine();
                    if (ImGui.Button(Loc.GetString("Get_Chat_ID")))
                    {
                        GetChatID();
                    }
                    break;
            }


            // 第三个复选框
            ImGui.Checkbox(Loc.GetString("Enable"), ref enable);


            // 保存配置
            if (ImGui.Button(Loc.GetString("Save")))
            {
                // 在这里保存配置信息，可以使用保存到配置文件或其他方式
                SaveConfig();
                Plugin.InitializeDtrBar(Plugin.DtrBar, Loc);
            }

        }

        private async void GetChatID()
        {
            var channel = selectedChannel;
            var url = "";

            if (channel == "Telegram_Offical_API" && !string.IsNullOrWhiteSpace(telegramBotToken))
            {
                url = "https://api.telegram.org/bot" + telegramBotToken + "/getUpdates";
                try
                {
                    using (var client = new HttpClient())
                    {
                        var response = await client.GetAsync(url);
                        response.EnsureSuccessStatusCode();
                        string responseBody = await response.Content.ReadAsStringAsync();
                        var json = JObject.Parse(responseBody);

                        // 直接遍历获取chat.id
                        foreach (var update in json["result"])
                        {
                            var chatId = update["message"]?["chat"]?["id"]?.Value<long>();
                            if (chatId != null)
                            {
                                chatID = chatId.ToString();
                            }
                        }
                        PluginLog.Info("Get the user chat ID");
                    }
                }
                catch (Exception ex)
                {
                    PluginLog.Error("Something wrong, please check your bot token or verify that you already sent a message to your bot");
                }
            }
        }

        private void SaveConfig()
        {
            Configuration.PushChannel = selectedChannel;
            Configuration.BarkServer = barkServer;
            Configuration.BarkTimeSensitive = barkTimeSensitive;
            Configuration.PushDeerKey = pushdeerKey;
            Configuration.TelegramBotToken = telegramBotToken;
            Configuration.TelegramChatID = chatID;
            Configuration.Enable = enable;
            Configuration.Save();
        }


        private async void TestRequest()
        {
            var channel = selectedChannel;
            var url = "";

            if (channel == "Bark" && !string.IsNullOrWhiteSpace(barkServer))
            {
                if (barkTimeSensitive)
                {
                    url = barkServer + Loc.GetString("PushTitle") + "/" + Loc.GetString("TestContent") + "?sound=ff14&level=timeSensitive&icon=https://cdn2.steamgriddb.com/icon/5f268dfb0fbef44de0f668a022707b86/32/256x256.png";
                }
                else
                {
                    url = barkServer + Loc.GetString("PushTitle") + "/" + Loc.GetString("TestContent") + "?sound=ff14&icon=https://cdn2.steamgriddb.com/icon/5f268dfb0fbef44de0f668a022707b86/32/256x256.png";
                }
                try
                {
                    using (var client = new HttpClient())
                    {
                        var response = await client.GetAsync(url);
                        response.EnsureSuccessStatusCode();
                        string responseBody = await response.Content.ReadAsStringAsync();
                        PluginLog.Info("Already send a push to your device");
                    }
                }
                catch (Exception ex)
                {
                    PluginLog.Error("Please check your Bark Server");
                }
            }else if(channel == "PushDeer" && !string.IsNullOrWhiteSpace(pushdeerKey))
            {
                url = "https://api2.pushdeer.com/message/push?pushkey="+ pushdeerKey + "&text=" + Loc.GetString("PushTitle") + "    " + Loc.GetString("TestContent");
                try
                {
                    using (var client = new HttpClient())
                    {
                        var response = await client.GetAsync(url);
                        response.EnsureSuccessStatusCode();
                        string responseBody = await response.Content.ReadAsStringAsync();
                        PluginLog.Info("Already send a push to your device");
                    }
                }
                catch (Exception ex)
                {
                    PluginLog.Error("Please check your PushDeer Key");
                }
            }
            else if(channel == "Telegram_Offical_API" && !string.IsNullOrWhiteSpace(telegramBotToken))
            {
                url = "https://api.telegram.org/bot" + telegramBotToken + "/sendMessage?chat_id=" + chatID + "&parse_mode=MarkdownV2&text=" + Loc.GetString("TelegramPushTitle") + "%0D%0A" + Loc.GetString("TelegramTestContent");
                try
                {
                    using (var client = new HttpClient())
                    {
                        var response = await client.GetAsync(url);
                        response.EnsureSuccessStatusCode();
                        string responseBody = await response.Content.ReadAsStringAsync();
                        PluginLog.Info("Already send a push to your device");
                    }
                }
                catch (Exception ex)
                {
                    PluginLog.Error("Please check your Telegram configuration");
                    PluginLog.Error(url);
                }
            }
        }
    }
}
