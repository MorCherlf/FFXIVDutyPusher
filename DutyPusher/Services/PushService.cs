using Dalamud.Plugin.Services;
using DutyPusher.PushChannels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace DutyPusher.Services
{
    public class PushService: IDisposable
    {
        private Dictionary<string, IPushChannel> channels;
        private IPushChannel activeChannel;
        private IPluginLog pluginLog;
        private bool disposed;

        public PushService(Configuration configuration, IPluginLog pluginLog)
        {
            this.pluginLog = pluginLog;
            Reload(configuration);
        }

        public void Dispose()
        {
            if (disposed) return;
            disposed = true;

            GC.SuppressFinalize(this);
        }

        public void Reload(Configuration configuration)
        {
            channels = new Dictionary<string, IPushChannel>
            {
                ["Bark"] = new BarkChannel(configuration.BarkServer, configuration.BarkTimeSensitive),
                ["PushDeer"] = new PushDeerChannel(configuration.PushDeerKey),
                ["Telegram_Official_API"] = new TelegramChannel(configuration.TelegramBotToken, configuration.TelegramChatID),
                ["Ntfy"] = new NtfyChannel(configuration.NtfyServer, configuration.NtfyTopic, configuration.NtfyPriority, configuration.NtfyEmoji)
            };

            // 检查配置的 PushChannel 是否存在，防止 KeyNotFound 异常
            if (channels.TryGetValue(configuration.PushChannel, out var channel))
            {
                activeChannel = channel;
            }
            else
            {
                // 根据需要记录日志或设定默认通道
                pluginLog.Error($"PushChannel '{configuration.PushChannel}' not found, falling back to default channel.");
                activeChannel = channels.Values.First();
            }
        }

        public async Task<bool> SendNotificationAsync(string title, string content)
        {
            if (activeChannel == null)
            {
                pluginLog.Warning("No channel has been selected!");
                return false;
            }
            using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(10));
            try
            {
                await activeChannel.SendAsync(title, content, pluginLog)
                    .ConfigureAwait(false); // 避免同步上下文问题
                return true;
            }
            catch (TaskCanceledException)
            {
                pluginLog.Error("Network timeout!");
            }
            catch (HttpRequestException ex)
            {
                pluginLog.Error($"Network error: ({ex.StatusCode}): {ex.Message}");
            }
            catch (Exception ex)
            {
                pluginLog.Error($"Failed: {ex.GetType().Name} - {ex.Message}");
            }
            return false;
        }

    }
}
