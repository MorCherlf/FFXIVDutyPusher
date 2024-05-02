using System;
using System.Numerics;
using Dalamud.Interface.Internal;
using Dalamud.Interface.Utility;
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
    private readonly DutyFinderStatus dutyFinderStatus;
    private bool alwaysPush = false;

    // We give this window a hidden ID using ##
    // So that the user will see "My Amazing Window" as window title,
    // but for ImGui the ID is "My Amazing Window##With a hidden ID"
    public MainWindow(Plugin plugin, Localization loc, Configuration configuration, DutyFinderStatus dutyFinderStatus)
        : base(loc.GetString("PluginName") + "##With a hidden ID", ImGuiWindowFlags.NoScrollbar | ImGuiWindowFlags.NoScrollWithMouse)
    {
        Configuration = configuration;
        this.Plugin = plugin;
        this.loc = loc;
       // this.alwaysPush = configuration.AlwaysPush;
        this.dutyFinderStatus = dutyFinderStatus;

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
        if (alwaysPush)
        {
            ImGui.Text(loc.GetString("IsPluginActive") + ": " + loc.GetString("On"));
            if(ImGui.Button(loc.GetString("Disable")))
            {
                dutyFinderStatus.Disable();
                alwaysPush = false;
            }
        } else
        {
            ImGui.Text(loc.GetString("IsPluginActive") + ": " + loc.GetString("Off"));

            if (ImGui.Button(loc.GetString("Enable")))
            {
                dutyFinderStatus.Enable();
                alwaysPush = true;
            }
        }

    }
}
