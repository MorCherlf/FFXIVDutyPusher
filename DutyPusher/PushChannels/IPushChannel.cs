using Dalamud.Plugin.Services;
using System.Threading.Tasks;

namespace DutyPusher.PushChannels
{
    public interface IPushChannel
    {
        Task SendAsync(string title, string content, IPluginLog pluginLog);
    }
}
