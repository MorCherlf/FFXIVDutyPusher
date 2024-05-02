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

namespace DutyPusher.Windows
{
    public class ConfigWindow : Window, IDisposable
    {
        private Configuration Configuration;
        private string selectedChannel = ""; 
        private string barkServer = ""; // Bark Server 字段
        private string pushdeerKey = ""; // PushDeer 字段
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
            enable = Configuration.Enable;
            barkTimeSensitive = Configuration.BarkTimeSensitive;
        }

        public void Dispose() { }

        public override void Draw()
        {
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

                ImGui.EndCombo();
            }

            // 第二个文本框，根据选择的 Push Channel 改变内容
            ImGui.Text(Loc.GetString("ChannelDetails"));
            ImGui.SameLine();
            switch (selectedChannel)
            {
                case "Bark":
                    ImGui.InputText("", ref barkServer, 256);
                    ImGui.SameLine();
                    ImGui.Checkbox(Loc.GetString("TimeSensitive"), ref barkTimeSensitive);
                    break;
                case "PushDeer":
                    ImGui.InputText("", ref pushdeerKey, 256);
                    break;
            }
            ImGui.SameLine();
            if (ImGui.Button(Loc.GetString("Test")))
            {
                TestRequest();
            }


            // 第三个复选框，Always Push
            ImGui.Checkbox(Loc.GetString("Enable"), ref enable);


            // 保存配置
            if (ImGui.Button(Loc.GetString("Save")))
            {
                // 在这里保存配置信息，可以使用保存到配置文件或其他方式
                SaveConfig();
                Plugin.InitializeDtrBar(Plugin.DtrBar, Loc);
            }
        }

        private void SaveConfig()
        {
            Configuration.PushChannel = selectedChannel;
            Configuration.BarkServer = barkServer;
            Configuration.BarkTimeSensitive = barkTimeSensitive;
            Configuration.PushDeerKey = pushdeerKey;
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
        }
    }
}
