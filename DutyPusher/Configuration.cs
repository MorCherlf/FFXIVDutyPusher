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
    public bool BarkTimeSensitive { get; set; } = false;

    public string PushDeerKey { get; set; } = "";

    public string TelegramBotToken { get; set; } = "";
    public string TelegramChatID { get; set; } = "";


    public string NtfySelection { get; set; } = ""; // Ntfy.sh Server 
    public string NtfyServer { get; set; } = ""; // Ntfy Server 
    public string NtfyTopic { get; set; } = ""; // Ntfy Topic
    public bool NtfyEmoji { get; set; } = false; // Ntfy Emoji
    public int NtfyPriority { get; set; } = 3; // Ntfy Priority


    public bool Enable { get; set; } = false; 

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
