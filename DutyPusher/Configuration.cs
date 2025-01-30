using Dalamud.Configuration;
using Dalamud.Interface.Windowing;
using Dalamud.Logging;
using Dalamud.Plugin;
using DutyPusher.Windows;
using System;

namespace DutyPusher;

[Serializable] // 可序列化类
public class Configuration : IPluginConfiguration
{
    public int Version { get; set; } = 0;

    public string PushChannel { get; set; } = ""; // Push Channel
    public string BarkServer { get; set; } = ""; // Bark Server 字段
    public string PushDeerKey { get; set; } = "";
    public string TelegramBotToken { get; set; } = "";
    public string TelegramChatID { get; set; } = "";
    public bool Enable { get; set; } = false; 
    public bool BarkTimeSensitive { get; set; } = false; 

    // the below exist just to make saving less cumbersome
    [NonSerialized]
    private IDalamudPluginInterface? PluginInterface;

    public void Initialize(IDalamudPluginInterface pluginInterface)
    {
        PluginInterface = pluginInterface;
    }

    public void Save()
    {
        //PluginLog.Log("Saving Configuration!");
        PluginInterface!.SavePluginConfig(this);
    }
}
