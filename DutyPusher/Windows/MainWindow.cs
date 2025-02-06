using System;
using System.Numerics;
using Dalamud.Interface.Windowing;
using Dalamud.Loc;
using DutyPusher.Services;
using ImGuiNET;

namespace DutyPusher.Windows;

internal class MainWindow : Window, IDisposable
{
    private Plugin Plugin;
    private Localization loc;
    public Configuration Configuration;

    // We give this window a hidden ID using ##
    // So that the user will see "My Amazing Window" as window title,
    // but for ImGui the ID is "My Amazing Window##With a hidden ID"
    public MainWindow(Plugin plugin, Localization loc, Configuration configuration, DutyListener dutyListener)
        : base(loc.GetString("PluginName") + "##By MorCherlf", ImGuiWindowFlags.NoScrollbar | ImGuiWindowFlags.NoScrollWithMouse)
    {
        Configuration = configuration;
        this.Plugin = plugin;
        this.loc = loc;

        SizeConstraints = new WindowSizeConstraints
        {
            MinimumSize = new Vector2(375, 330),
            MaximumSize = new Vector2(float.MaxValue, float.MaxValue)
        };

        Plugin = plugin;
    }

    public void Dispose() { }

    public override void Draw()
    {
        if (Configuration.Enable)
        {
            ImGui.Text(loc.GetString("IsPluginActive") + ": " + loc.GetString("On"));
            if(ImGui.Button(loc.GetString("Disable")))
            {
                Configuration.Enable = false;
                Configuration.Save();
            }
        } else
        {
            ImGui.Text(loc.GetString("IsPluginActive") + ": " + loc.GetString("Off"));

            if (ImGui.Button(loc.GetString("Enable")))
            {
                Configuration.Enable = true;
                Configuration.Save();
            }
        }

    }
}
