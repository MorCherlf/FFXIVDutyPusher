using System;
using System.Linq;
using FFXIVClientStructs.Attributes;

using Dalamud.Game.Command;
using Dalamud.IoC;
using Dalamud.Plugin;
using System.IO;
using Dalamud.Interface.Windowing;
using Dalamud.Plugin.Services;
using DutyPusher.Windows;
using DutyPusher.Services;
using FFXIVClientStructs.FFXIV.Component.GUI;
using System.Reflection;
using Dalamud.Game.Gui.Dtr;
using Dalamud.Logging;
using Dalamud.Interface.Utility.Table;
using Dalamud.Loc;

namespace DutyPusher
{
    public sealed class Plugin : IDalamudPlugin
    {
        // 激活窗口的命令
        private const string CommandName = "/dutypusher";

        // 初始化对象
        private IDalamudPluginInterface PluginInterface { get; init; }
        public static IGameGui GameGui { get; private set; }

        private ICommandManager CommandManager { get; init; }
        private IAddonLifecycle AddonLifecycle { get; init; }
        private IAddonEventManager AddonEventManager { get; init; }
        public Configuration Configuration { get; init; }

        public readonly WindowSystem WindowSystem = new("DutyPusher");

        private IDtrBarEntry dtrEntry;

        [PluginService] public static IDtrBar DtrBar { get; private set; } = null!;

        private ConfigWindow ConfigWindow { get; init; }
        // private MainWindow MainWindow { get; init; }

        private readonly IPluginLog pluginLog; // 添加插件日志
        private ChatListener ChatListener { get; set; }
        private DutyFinderStatus DutyFinderStatus { get; set; }
        public Dalamud.Loc.Localization loc;

        // 插件 主类
        public Plugin(
            // 引用依赖
            IDalamudPluginInterface pluginInterface,
            ICommandManager commandManager,
            ITextureProvider textureProvider,
            IGameGui gameGui,
            IAddonLifecycle addonLifecycle,
            IAddonEventManager addonEventManager, 
            IDtrBar dtrBar,
            IPluginLog pluginLog)
        {
            // 初始化
            PluginInterface = pluginInterface;
            CommandManager = commandManager;
            this.pluginLog = pluginLog;

            // 获取配置并装载
            Configuration = PluginInterface.GetPluginConfig() as Configuration ?? new Configuration();
            Configuration.Initialize(PluginInterface);

            var zhLoc = File.ReadAllText(PluginInterface.AssemblyLocation.Directory + "/loc/zh.json");
            var enLoc = File.ReadAllText(PluginInterface.AssemblyLocation.Directory + "/loc/en.json");

            var loc = new Localization(pluginInterface);
            loc.LoadLanguage(Dalamud.Loc.Enums.Language.ChineseSimplified, zhLoc);
            loc.LoadLanguage(Dalamud.Loc.Enums.Language.English, enLoc);
            switch (PluginInterface.UiLanguage)
            {
                case "zh":
                    loc.CurrentLanguage = Dalamud.Loc.Enums.Language.ChineseSimplified;
                    pluginLog.Info("Chinese");
                    break;
                case "en":
                    loc.CurrentLanguage = Dalamud.Loc.Enums.Language.English;
                    pluginLog.Info("English");
                    break;
                default:
                    loc.CurrentLanguage = Dalamud.Loc.Enums.Language.English;
                    pluginLog.Info("Default");
                    break;
            }

            pluginLog.Info("Plugin <DutyPusher> has been loaded!");
            pluginLog.Info(PluginInterface.UiLanguage);
            var languageLoad = loc.GetString("LocalizationLoading");
            pluginLog.Info(languageLoad);


            this.DutyFinderStatus = new DutyFinderStatus(this, Configuration, loc);
            this.ChatListener = new ChatListener(this, pluginInterface, this.DutyFinderStatus, Configuration);

            if (DtrBar != null)
            {
                // 窗口初始化
                ConfigWindow = new ConfigWindow(this, pluginLog, loc);
                // MainWindow = new MainWindow(this, loc, Configuration, DutyFinderStatus);

                // 添加窗口
                WindowSystem.AddWindow(ConfigWindow);
                // WindowSystem.AddWindow(MainWindow);

                // DTRBar初始化
                InitializeDtrBar(DtrBar, loc);
            }
            else
            {
                //PluginLog.LogWarning("DtrBar is null. Skipping DtrBar initialization.");
            }


            // 注册命令 和 帮助信息
            CommandManager.AddHandler(CommandName, new CommandInfo(OnCommand)
            {
                HelpMessage = "A useful message to display in /xlhelp"
            });

            PluginInterface.UiBuilder.Draw += DrawUI;

            // 绘制一个配置按钮
            PluginInterface.UiBuilder.OpenConfigUi += ToggleConfigUI;
        }

        // 释放资源
        public void Dispose()
        {
            WindowSystem.RemoveAllWindows();

            Configuration.Save();

            this.DutyFinderStatus.Disable();
            this.ChatListener.Disable();
            ConfigWindow.Dispose();
            // MainWindow.Dispose();
            dtrEntry?.Remove();
            CommandManager.RemoveHandler(CommandName);
        }

        public void InitializeDtrBar(IDtrBar dtrBar, Localization loc)
        {
            //PluginLog.Log("Initializing Dtr Bar...");
            var dtrBarTitle = "DutyPusher";
            var enable = Configuration.Enable;
            try
            {
                dtrEntry = dtrBar.Get(dtrBarTitle);
                if (enable)
                {
                    dtrEntry.Text = loc.GetString("PluginName") + ": " + loc.GetString("On");
                }
                else
                {
                    dtrEntry.Text = loc.GetString("PluginName") + ": " + loc.GetString("Off");
                }
                dtrEntry.Shown = true;

                dtrEntry.OnClick += () =>
                {
                    if (enable)
                    {
                        enable = false;
                        Configuration.Enable = false;
                        Configuration.Save();
                        dtrEntry.Text = loc.GetString("PluginName") + ": " + loc.GetString("Off");
                    }
                    else
                    {
                        enable = true;
                        Configuration.Enable = true;
                        Configuration.Save();
                        dtrEntry.Text = loc.GetString("PluginName") + ": " + loc.GetString("On");
                    }
                };

            }
            catch (Exception e)
            {
                //PluginLog.Log(e,$"Failed to acquire DtrBarEntry {dtrBarTitle}");
            }
        }


        private void OnCommand(string command, string args)
        {
            ToggleConfigUI();
        }

        private void DrawUI() => WindowSystem.Draw();

        public void ToggleConfigUI() => ConfigWindow.Toggle();
        // public void ToggleMainUI() => MainWindow.Toggle();
    }

}
