using System;
using System.Numerics;
using System.Net.Http;
using Dalamud.Interface.Windowing;
using ImGuiNET;
using Dalamud.Plugin.Services;
using Dalamud.Loc;
using DutyPusher.Services;
using System.Diagnostics;
using Newtonsoft.Json.Linq;

namespace DutyPusher.Windows
{
    public class ConfigWindow : Window, IDisposable
    {
        private Configuration configuration;
        private Plugin Plugin;
        private readonly IPluginLog pluginLog;
        private Localization loc;
        private readonly PushService pushService;

        private string selectedChannel = "";
        private string barkServer = "";
        private string pushdeerKey = "";
        private string telegramBotToken = "";
        private string chatID = "";
        private bool enable = false;
        private bool barkTimeSensitive = false;
        private string selectedNtfy = "";
        private string ntfyServer = "";
        private string ntfyTopic = "";
        private int ntfyPriority = 3;
        private bool ntfyEmoji = false;

        public ConfigWindow(Plugin plugin, PushService pushService, IPluginLog pluginLog, Localization loc) : base(loc.GetString("PluginName") +"###By MorCherlf")
        {
            Flags = ImGuiWindowFlags.NoCollapse;
            Size = new Vector2(800, 300);
            this.configuration = plugin.Configuration;
            this.pluginLog = pluginLog;
            Plugin = plugin;
            this.loc = loc;
            this.pushService = pushService;

            selectedChannel = configuration.PushChannel;
            barkServer = configuration.BarkServer;
            pushdeerKey = configuration.PushDeerKey;
            telegramBotToken = configuration.TelegramBotToken; 
            chatID = configuration.TelegramChatID;
            enable = configuration.Enable;
            barkTimeSensitive = configuration.BarkTimeSensitive;
            selectedNtfy = configuration.NtfySelection;
            ntfyServer = configuration.NtfyServer;
            ntfyTopic = configuration.NtfyTopic;
            ntfyPriority = configuration.NtfyPriority;
            ntfyEmoji = configuration.NtfyEmoji;
        }

        public void Dispose() { }

        public override void OnOpen()
        {
            base.OnOpen();
            selectedChannel = configuration.PushChannel;
            barkServer = configuration.BarkServer;
            pushdeerKey = configuration.PushDeerKey;
            telegramBotToken = configuration.TelegramBotToken;
            chatID = configuration.TelegramChatID;
            enable = configuration.Enable;
            barkTimeSensitive = configuration.BarkTimeSensitive;
            selectedNtfy = configuration.NtfySelection;
            ntfyServer = configuration.NtfyServer;
            ntfyTopic = configuration.NtfyTopic;
            ntfyPriority = configuration.NtfyPriority;
            ntfyEmoji = configuration.NtfyEmoji;
        }

        public override void Draw()
        {

            ImGui.Text(loc.GetString("WelcomeLine"));
            ImGui.SameLine();
            if (ImGui.Button(loc.GetString("Guide")))
            {
                string url = loc.GetString("GuideURL");

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
                    pluginLog.Error($"Error: {ex.Message}");
                }
            }

            // 第一个下拉菜单，选择 Push Channel
            if (ImGui.BeginCombo(loc.GetString("PushChannel"), selectedChannel))
            {
                if (ImGui.Selectable(loc.GetString("Bark")))
                {
                    selectedChannel = "Bark";
                }

                if (ImGui.Selectable(loc.GetString("PushDeer")))
                {
                    selectedChannel = "PushDeer";
                }

                if (ImGui.Selectable(loc.GetString("TelegramOfficialAPI")))
                {
                    selectedChannel = "Telegram_Official_API";
                }

                if (ImGui.Selectable(loc.GetString("ntfy")))
                {
                    selectedChannel = "Ntfy";
                }

                ImGui.EndCombo();
            }

            // 第二个文本框，根据选择的 Push Channel 改变内容
            switch (selectedChannel)
            {
                case "Bark":
                    ImGui.Text(loc.GetString("BarkURL"));
                    ImGui.SameLine();
                    ImGui.InputText("##Bark", ref barkServer, 256);
                    ImGui.SameLine();
                    ImGui.Checkbox(loc.GetString("TimeSensitive"), ref barkTimeSensitive);
                    ImGui.SameLine();
                    if (ImGui.Button(loc.GetString("Test")))
                    {
                        TestRequest();
                    }
                    break;
                case "PushDeer":
                    ImGui.Text(loc.GetString("PushDeerKey"));
                    ImGui.SameLine();
                    ImGui.InputText("##PushDeer", ref pushdeerKey, 256);
                    ImGui.SameLine();
                    if (ImGui.Button(loc.GetString("Test")))
                    {
                        TestRequest();
                    }
                    break;
                case "Telegram_Official_API":
                    ImGui.Text(loc.GetString("TelegramBotToken"));
                    ImGui.SameLine();
                    ImGui.InputText("##BotToken", ref telegramBotToken, 256);
                    ImGui.SameLine();
                    if (ImGui.Button(loc.GetString("Get_Chat_ID")))
                    {
                        GetChatID();
                    }
                    ImGui.Text(loc.GetString("Chat_ID"));
                    ImGui.SameLine();
                    ImGui.InputText("##ChatID", ref chatID, 256);
                    ImGui.SameLine();
                    if (ImGui.Button(loc.GetString("Test")))
                    {
                        TestRequest();
                    }
                    break;
                case "Ntfy":
                    if (ImGui.BeginCombo(loc.GetString("ntfy.serverlist"), selectedNtfy))
                    {
                        if (ImGui.Selectable(loc.GetString("ntfy.sh")))
                        {
                            selectedNtfy = "ntfy.sh";
                            ntfyServer = "https://ntfy.sh/";
                        }

                        if (ImGui.Selectable(loc.GetString("ntfy.dutypusher")))
                        {
                            selectedNtfy = "ntfy.dutypusher";
                            ntfyServer = "https://ntfy.sh/";
                        }

                        if (ImGui.Selectable(loc.GetString("ntfy.customer")))
                        {
                            selectedNtfy = "ntfy.customer";
                        }

                        ImGui.EndCombo();
                    }

                    if(selectedNtfy == "ntfy.customer")
                    {
                        ImGui.Text(loc.GetString("ntfy.custom.serverURL"));
                        ImGui.SameLine();
                        ImGui.InputText("##The Link Should Be Like 'https://domain.xx/' ", ref ntfyServer, 256);
                    }

                    ImGui.Text(loc.GetString("ntfy.topic"));
                    ImGui.SameLine();
                    ImGui.InputText("##Your Topic", ref ntfyTopic, 256);

                    ImGui.InputInt(loc.GetString("ntfy.priority"), ref ntfyPriority);
                    ImGui.SameLine();
                    ImGui.Text(loc.GetString("ntfy.priority.descript"));

                    ImGui.Checkbox(loc.GetString("ntfy.emoji"), ref ntfyEmoji);
                    ImGui.SameLine();
                    if (ImGui.Button(loc.GetString("Test")))
                    {
                        TestRequest();
                    }
                    break;
            }


            // 第三个复选框
            if (ImGui.Checkbox(loc.GetString("Enable"), ref enable))
            {
                configuration.Enable = enable;
                configuration.Save();
                Plugin.UpdateDtrBarState(loc); // 即时更新DTR状态
            }


            // 保存配置
            if (ImGui.Button(loc.GetString("Save")))
            {
                // 在这里保存配置信息，可以使用保存到配置文件或其他方式
                SaveConfig();
                Plugin.UpdateDtrBarState(loc);
            }

        }
        
        // 通过官方API 使用自己创建的Bot Token 获取 ChatID 
        private async void GetChatID()
        {
            var channel = selectedChannel;
            var url = "";

            if (channel == "Telegram_Official_API" && !string.IsNullOrWhiteSpace(telegramBotToken))
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

                                pluginLog.Info("Get the user chat ID", chatId.ToString());
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    pluginLog.Error("Something wrong, please check your bot token or verify that you already sent a message to your bot");
                }
            }
        }

        private void SaveConfig()
        {
            configuration.PushChannel = selectedChannel;
            configuration.BarkServer = barkServer;
            configuration.BarkTimeSensitive = barkTimeSensitive;
            configuration.PushDeerKey = pushdeerKey;
            configuration.TelegramBotToken = telegramBotToken;
            configuration.TelegramChatID = chatID;
            configuration.NtfyEmoji = ntfyEmoji;
            configuration.NtfyPriority = ntfyPriority;
            configuration.NtfySelection  = selectedNtfy;
            configuration.NtfyServer = ntfyServer;
            configuration.NtfyTopic = ntfyTopic;
            configuration.Enable = enable;
            configuration.Save();
        }


        private async void TestRequest()
        {
            try
            {
                SaveConfig();
                await pushService.SendNotificationAsync(loc.GetString("PushTitle"), loc.GetString("TestContent"));
                pluginLog.Info("Test notification sent successfully");
            }
            catch (Exception ex)
            {
                pluginLog.Error($"Test failed: {ex.Message}");
            }
        }
    }
}
