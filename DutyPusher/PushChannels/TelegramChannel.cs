using Dalamud.Plugin.Services;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace DutyPusher.PushChannels
{
    public class TelegramChannel : IPushChannel
    {
        private readonly HttpClient httpClient;
        private readonly string botToken;
        private readonly string chatID;

        public TelegramChannel(string token, string id)
        {
            var handler = new HttpClientHandler
            {
                SslProtocols = System.Security.Authentication.SslProtocols.Tls12 |
                   System.Security.Authentication.SslProtocols.Tls13
            };

            httpClient = new HttpClient(handler);
            botToken = token;
            chatID = id;
        }

        public async Task SendAsync(string title, string content, IPluginLog pluginLog)
        {
            var encodedMsg = HttpUtility.UrlEncode($"*{title}*\n{content}");
            var url = $"https://api.telegram.org/bot{botToken}/sendMessage?" + // Telegram Offical bot api
                     $"chat_id={chatID}&parse_mode=MarkdownV2&text={encodedMsg}";
            pluginLog.Debug(url);
            var response = await httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
        }
    }
}
