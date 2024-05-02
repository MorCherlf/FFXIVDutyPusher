using Dalamud.Game.Text;
using Dalamud.Game.Text.SeStringHandling;
using Dalamud.Logging;
using Dalamud.Plugin;
using Dalamud.Plugin.Services;
using Dalamud.IoC;
namespace DutyPusher.Services
{
    internal class Service
    {
        [PluginService] internal static IChatGui Chat { get; private set; } = null!;
    }

    internal unsafe class ChatListener
    {
        private readonly DalamudPluginInterface pluginInterface;
        private readonly DutyFinderStatus dutyFinderStatus;
        private Plugin Plugin;
        public Configuration Configuration;
        private bool enable = false;

        public ChatListener(Plugin plugin, DalamudPluginInterface pluginInterface, DutyFinderStatus dutyFinderStatus, Configuration configuration)
        {
            PluginLog.Log("Start Listning Message!");
            this.pluginInterface = pluginInterface;
            this.dutyFinderStatus = dutyFinderStatus;
            this.Plugin = plugin;
            this.Configuration = configuration;

            pluginInterface.Create<Service>();

            // 注册监听器
            Service.Chat.ChatMessage += OnChatMessageHandled;
        }

        public ChatListener(DalamudPluginInterface pluginInterface, DutyFinderStatus dutyFinderStatus, Configuration configuration)
        {
            this.pluginInterface = pluginInterface;
            this.dutyFinderStatus = dutyFinderStatus;
            this.Configuration = configuration;
            enable = Configuration.Enable;
        }

        public void Disable()
        {
            // 移除监听器
            Service.Chat.ChatMessage -= OnChatMessageHandled;
        }

        private void OnChatMessageHandled(XivChatType type, uint senderId, ref SeString sender, ref SeString message, ref bool isHandled)
        {
            enable = Configuration.Enable;

            // 检查消息是否为系统消息
            if (type == XivChatType.SystemMessage)
            //if (true)
            {
                var messageText = message.TextValue;

                // 检查消息是否包含特定内容
                if (messageText.Contains("发送了参加申请") || messageText.Contains("Your party leader has registered the party for duty") || messageText.Contains("Duty registration complete") || messageText.Contains("パーティリーダーにより、コンテンツ参加申請が行われました") || messageText.Contains("コンテンツ参加申請を行いました"))
                {
                    
                    // 当收到特定系统信息时触发相应操作
                    PluginLog.Log("Received a system message: " + messageText);

                    // 激活队列状态监听器
                    if (enable)
                    {
                        dutyFinderStatus.Enable();
                    }
                }
            }
        }
    }
}
