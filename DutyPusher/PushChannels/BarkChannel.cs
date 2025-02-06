using Dalamud.Plugin.Services;
using System.Net.Http;
using System.Threading.Tasks;

namespace DutyPusher.PushChannels
{
    public class BarkChannel : IPushChannel
    {
        private readonly HttpClient httpClient;
        private readonly string serverUrl;
        private readonly bool timeSensitiveEnable;

        public BarkChannel(string serverUrl, bool timeSensitive)
        {
            httpClient = new HttpClient();
            serverUrl = serverUrl.TrimEnd('/');
            timeSensitiveEnable = timeSensitive;
        }

        public async Task SendAsync(string title, string content, IPluginLog pluginLog)
        {
            var url = $"{serverUrl}/{title}/{content}?" +
                     $"sound=ff14&icon=https://cdn2.steamgriddb.com/icon/5f268dfb0fbef44de0f668a022707b86/32/256x256.png" + // Customize notify ring and icon
                     (timeSensitiveEnable ? "&level=timeSensitive" : ""); // iOS Time Sensitive
            pluginLog.Debug(url);
            var response = await httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
        }
    }
}
