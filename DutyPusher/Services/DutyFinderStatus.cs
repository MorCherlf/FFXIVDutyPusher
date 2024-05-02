using Dalamud.Loc;
using Dalamud.Logging;
using Dalamud.Plugin;
using DutyPusher.Windows;
using FFXIVClientStructs.FFXIV.Client.Game.UI;
using System;
using System.Net.Http;
using System.Threading;

namespace DutyPusher.Services
{
    internal class DutyFinderStatus
    {
        private Timer queueStatusTimer;
        private bool isActive = false; // 默认状态为未启用
        private bool isQueueReady = false;
        private Plugin Plugin;
        private Localization loc;
        public Configuration Configuration;
        private string selectedChannel = "";
        private string barkServer = "";
        private string pushdeerKey = "";
        private bool barkTimeSensitive = false;

        public DutyFinderStatus(Plugin plugin, Configuration configuration, Localization loc) // 传入 Configuration 对象
        {
            this.Plugin = plugin;
            this.loc = loc;
            Configuration = configuration;
        }

        public void Enable()
        {
            // 启用 DutyFinderStatus 的功能
            if (selectedChannel != null && barkServer != null)
            {
                PluginLog.Log("Enabling Duty Finder Status Listener...");
                this.isActive = true;

                // 初始化定时器，每秒触发一次检查队列状态的操作
                this.queueStatusTimer = new Timer(OnTimerCallback, null, TimeSpan.Zero, TimeSpan.FromSeconds(1));
            }
            else
            {
                return;
            }

        }

        public void Disable()
        {
            // 停用 DutyFinderStatus 的功能
            PluginLog.Log("Disabling Duty Finder Status Listener...");
            this.isActive = false;
            this.queueStatusTimer?.Change(Timeout.Infinite, Timeout.Infinite); // 停止定时器
        }

        private unsafe void OnTimerCallback(object state)
        {
            if (!isActive) return; // 如果未启用，则不执行任何操作

            // 获取当前队列状态
            var currentQueueState = ContentsFinder.Instance()->QueueInfo.QueueState;

            if (currentQueueState == ContentsFinderQueueInfo.QueueStates.Ready)
            {
                if (!isQueueReady)
                {
                    CheckAmnesty();
                    this.isQueueReady = true;
                }
            }
            else if (currentQueueState == ContentsFinderQueueInfo.QueueStates.InContent)
            {
                // 如果队列状态变为 InContent，则设置标志位为 true
                PluginLog.Log("Duty Finder queue status changed to InContent!");
                Disable();
            }
            else if (currentQueueState == ContentsFinderQueueInfo.QueueStates.None)
            {
                // 如果队列状态变为 None，则停用 DutyFinderStatus
                PluginLog.Log("Duty Finder queue status changed to None!");
                Disable();
            }
            else
            {
                this.isQueueReady = false;
            }
        }

        private void CheckAmnesty()
        {
            // 在队列状态为 Ready 时执行的操作
            PluginLog.Log("Executing action when Duty Finder queue is ready...");
            Push(loc.GetString("PushContent"));
        }

        private async void Push(String text)
        {
            selectedChannel = Configuration.PushChannel;
            barkServer = Configuration.BarkServer;
            barkTimeSensitive = Configuration.BarkTimeSensitive;
            pushdeerKey = Configuration.PushDeerKey;

            var url = "";

            if (selectedChannel == "Bark" && !string.IsNullOrWhiteSpace(barkServer))
            {
                if (barkTimeSensitive)
                {
                    url = barkServer + loc.GetString("PushTitle") + "/" + text + "?sound=ff14&level=timeSensitive&icon=https://cdn2.steamgriddb.com/icon/5f268dfb0fbef44de0f668a022707b86/32/256x256.png";
                }
                else
                {
                    url = barkServer + loc.GetString("PushTitle") + "/" + text + "?sound=ff14&icon=https://cdn2.steamgriddb.com/icon/5f268dfb0fbef44de0f668a022707b86/32/256x256.png";
                }
                try
                {
                    PluginLog.Log("Tring to push notify to " + barkServer + " from " + selectedChannel);
                    using (var client = new HttpClient())
                    {
                        var response = await client.GetAsync(url);
                        response.EnsureSuccessStatusCode();
                        string responseBody = await response.Content.ReadAsStringAsync();
                        PluginLog.Log("Already send a push to your device");
                    }
                }
                catch (Exception ex)
                {
                    PluginLog.Error("Please check your Bark Server");
                }
            }else if(selectedChannel == "PushDeer" && !string.IsNullOrWhiteSpace(pushdeerKey))
            {
                url = "https://api2.pushdeer.com/message/push?pushkey="+ pushdeerKey + "&text=" + loc.GetString("PushTitle") + "    " + text;
                try
                {
                    PluginLog.Log("Tring to push notify to " + pushdeerKey + " from " + selectedChannel);
                    using (var client = new HttpClient())
                    {
                        var response = await client.GetAsync(url);
                        response.EnsureSuccessStatusCode();
                        string responseBody = await response.Content.ReadAsStringAsync();
                        PluginLog.Log("Already send a push to your device");
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
