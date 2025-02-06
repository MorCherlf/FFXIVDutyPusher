using Dalamud.Plugin.Services;
using FFXIVClientStructs.FFXIV.Common.Lua;
using System.Net.Http;
using System.Threading.Tasks;

namespace DutyPusher.PushChannels
{
    public class PushDeerChannel: IPushChannel
    {
        private readonly HttpClient httpClient;
        private readonly string token;

        public PushDeerChannel(string key)
        {
            httpClient = new HttpClient();
            token = key;
        }

        public async Task SendAsync(string title, string content, IPluginLog pluginLog)
        {
            // PushDeer offical service
            var url = $"https://api2.pushdeer.com/message/push?pushkey={token}&text={title}    {content}";
            pluginLog.Debug(url);
            var response = await httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
        }
    }
}
