using Dalamud.Configuration;
using Dalamud.Plugin;
using System;

namespace DutyPusher;

[Serializable]
public class Configuration : IPluginConfiguration
{
    public int Version { get; set; } = 0;

    public string PushChannel { get; set; } = ""; // Push Channel
    public string BarkServer { get; set; } = ""; // Bark Server 
    public string PushDeerKey { get; set; } = "";
    public string TelegramBotToken { get; set; } = "";
    public string TelegramChatID { get; set; } = "";
    public bool Enable { get; set; } = false; 
    public bool BarkTimeSensitive { get; set; } = false;

    public event Action<Configuration>? OnSaved;

    // the below exist just to make saving less cumbersome
    [NonSerialized]
    private IDalamudPluginInterface? PluginInterface;

    public void Initialize(IDalamudPluginInterface pluginInterface)
    {
        PluginInterface = pluginInterface;
    }

    public void Save()
    {
        PluginInterface!.SavePluginConfig(this);
        OnSaved?.Invoke(this);
    }
}
