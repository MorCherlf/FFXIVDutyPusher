using System;
using Dalamud.Game.Command;
using Dalamud.IoC;
using Dalamud.Plugin;
using System.IO;
using Dalamud.Interface.Windowing;
using Dalamud.Plugin.Services;
using DutyPusher.Windows;
using Dalamud.Game.Gui.Dtr;
using Dalamud.Loc;
using DutyPusher.Services;
using Dalamud.Game.Text;
using Dalamud.Game.Text.SeStringHandling;
using Dalamud.Game.Text.SeStringHandling.Payloads;
using FFXIVClientStructs.FFXIV.Component.GUI;
using System.Reflection.Metadata;

namespace DutyPusher
{
    public sealed class Plugin : IDalamudPlugin
    {
        // 激活窗口的命令
        private const string CommandName = "/dutypusher";
        private const string CommandSetting = "/dpui";

        // 切换启用状态
        private const string CommandSwitch = "/dp";
        private const string CommandEnable = "/dpon";
        private const string CommandDisable = "/dpoff";

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
        [PluginService] public static IChatGui ChatGui { get; private set; } = null!;

        private ConfigWindow ConfigWindow { get; init; }
        // private MainWindow MainWindow { get; init; }

        private readonly IPluginLog pluginLog; 
        public static Dalamud.Loc.Localization loc;
        private PushService pushService;
        private DutyListener dutyListener;

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
            IPluginLog pluginLog,
            IClientState clientState)
        {
            // 初始化
            PluginInterface = pluginInterface;
            CommandManager = commandManager;
            this.pluginLog = pluginLog;

            // 获取配置并装载
            Configuration = PluginInterface.GetPluginConfig() as Configuration ?? new Configuration();
            Configuration.OnSaved += HandleConfigurationSaved;
            Configuration.Initialize(PluginInterface);

            
            var deLoc = File.ReadAllText(PluginInterface.AssemblyLocation.Directory + "/loc/de.json");
            var enLoc = File.ReadAllText(PluginInterface.AssemblyLocation.Directory + "/loc/en.json");
            var esLoc = File.ReadAllText(PluginInterface.AssemblyLocation.Directory + "/loc/es.json");
            var frLoc = File.ReadAllText(PluginInterface.AssemblyLocation.Directory + "/loc/fr.json");
            var itLoc = File.ReadAllText(PluginInterface.AssemblyLocation.Directory + "/loc/it.json");
            var jaLoc = File.ReadAllText(PluginInterface.AssemblyLocation.Directory + "/loc/ja.json");
            var koLoc = File.ReadAllText(PluginInterface.AssemblyLocation.Directory + "/loc/ko.json");
            var noLoc = File.ReadAllText(PluginInterface.AssemblyLocation.Directory + "/loc/no.json");
            var ruLoc = File.ReadAllText(PluginInterface.AssemblyLocation.Directory + "/loc/ru.json");
            var twLoc = File.ReadAllText(PluginInterface.AssemblyLocation.Directory + "/loc/tw.json");
            var zhLoc = File.ReadAllText(PluginInterface.AssemblyLocation.Directory + "/loc/zh.json");

            Plugin.loc = new Localization(pluginInterface);

            loc.LoadLanguage(Dalamud.Loc.Enums.Language.German, deLoc);
            loc.LoadLanguage(Dalamud.Loc.Enums.Language.English, enLoc);
            loc.LoadLanguage(Dalamud.Loc.Enums.Language.Spanish, esLoc);
            loc.LoadLanguage(Dalamud.Loc.Enums.Language.French, frLoc);
            loc.LoadLanguage(Dalamud.Loc.Enums.Language.Italian, itLoc);
            loc.LoadLanguage(Dalamud.Loc.Enums.Language.Japanese, jaLoc);
            loc.LoadLanguage(Dalamud.Loc.Enums.Language.Korean, koLoc);
            loc.LoadLanguage(Dalamud.Loc.Enums.Language.Norwegian, noLoc);
            loc.LoadLanguage(Dalamud.Loc.Enums.Language.Russian, ruLoc);
            loc.LoadLanguage(Dalamud.Loc.Enums.Language.ChineseTraditional, twLoc);
            loc.LoadLanguage(Dalamud.Loc.Enums.Language.ChineseSimplified, zhLoc);

            // 根据UI语言设置当前语言
            switch (PluginInterface.UiLanguage)
            {
                case "zh":
                    loc.CurrentLanguage = Dalamud.Loc.Enums.Language.ChineseSimplified;
                    pluginLog.Info("Loaded Simplified Chinese localization");
                    break;
                case "tw":
                    loc.CurrentLanguage = Dalamud.Loc.Enums.Language.ChineseTraditional;
                    pluginLog.Info("Loaded Traditional Chinese localization");
                    break;
                case "de":
                    loc.CurrentLanguage = Dalamud.Loc.Enums.Language.German;
                    pluginLog.Info("Loaded German localization");
                    break;
                case "es":
                    loc.CurrentLanguage = Dalamud.Loc.Enums.Language.Spanish;
                    pluginLog.Info("Loaded Spanish localization");
                    break;
                case "fr":
                    loc.CurrentLanguage = Dalamud.Loc.Enums.Language.French;
                    pluginLog.Info("Loaded French localization");
                    break;
                case "it":
                    loc.CurrentLanguage = Dalamud.Loc.Enums.Language.Italian;
                    pluginLog.Info("Loaded Italian localization");
                    break;
                case "ja":
                    loc.CurrentLanguage = Dalamud.Loc.Enums.Language.Japanese;
                    pluginLog.Info("Loaded Japanese localization");
                    break;
                case "ko":
                    loc.CurrentLanguage = Dalamud.Loc.Enums.Language.Korean;
                    pluginLog.Info("Loaded Korean localization");
                    break;
                case "no":
                    loc.CurrentLanguage = Dalamud.Loc.Enums.Language.Norwegian;
                    pluginLog.Info("Loaded Norwegian localization");
                    break;
                case "ru":
                    loc.CurrentLanguage = Dalamud.Loc.Enums.Language.Russian;
                    pluginLog.Info("Loaded Russian localization");
                    break;
                default:
                    loc.CurrentLanguage = Dalamud.Loc.Enums.Language.English;
                    pluginLog.Info("Loaded default English localization");
                    break;
            }

            pluginLog.Info("Plugin <DutyPusher> has been loaded!");
            pluginLog.Info(PluginInterface.UiLanguage);
            var languageLoad = loc.GetString("LocalizationLoading");
            pluginLog.Info(languageLoad);

            pushService = new PushService(Configuration, pluginLog);

            dutyListener = new DutyListener( () => Configuration.Enable,pluginLog, loc, clientState, pushService);
            UpdateDutyListenerState();

            if (DtrBar != null)
            {
                // 窗口初始化
                ConfigWindow = new ConfigWindow(this, pushService, pluginLog, loc);
                // MainWindow = new MainWindow(this, loc, Configuration, DutyFinderStatus);

                // 添加窗口
                WindowSystem.AddWindow(ConfigWindow);
                // WindowSystem.AddWindow(MainWindow);

                // DTRBar初始化
                InitializeDtrBar(DtrBar, loc);
            }
            else
            {
                pluginLog.Error("DtrBar is null. Skipping DtrBar initialization.");
            }


            CommandManager.AddHandler(CommandName, new CommandInfo(OnCommand)
            {
                HelpMessage = "Open DutyPusher Settings"
            });

            CommandManager.AddHandler(CommandSetting, new CommandInfo(OnCommand)
            {
                HelpMessage = "Open DutyPusher Settings"
            });

            CommandManager.AddHandler(CommandSwitch, new CommandInfo(SwitchEnabledState)
            {
                HelpMessage = "Switch the DutyPusher enabled state"
            });

            CommandManager.AddHandler(CommandEnable, new CommandInfo(SwitchEnable)
            {
                HelpMessage = "Enable the DutyPusher"
            });

            CommandManager.AddHandler(CommandDisable, new CommandInfo(SwitchDisable)
            {
                HelpMessage = "Disable the DutyPusher"
            });

            PluginInterface.UiBuilder.Draw += DrawUI;

            PluginInterface.UiBuilder.OpenConfigUi += ToggleConfigUI;
        }

        private void UpdateDutyListenerState()
        {
            try
            {
                dutyListener?.UpdateSubscriptionState();
                pluginLog.Debug($"Duty listener state updated: {Configuration.Enable}");
            }
            catch (Exception ex)
            {
                pluginLog.Error($"Duty listener error: {ex}");
            }
        }

        private void HandleConfigurationSaved(Configuration configuration)
        {
            try
            {
                pluginLog.Info("Configuration saved");
                pushService.Reload(configuration);
                UpdateDutyListenerState();
            }
            catch (Exception ex)
            {
                pluginLog.Error($"Configuration save error: {ex}");
            }
        }

        // 释放资源
        public void Dispose()
        {
            try
            {
                // 释放托管资源
                Configuration.OnSaved -= HandleConfigurationSaved;
                dtrEntry?.Remove();
                dutyListener?.Dispose();
                pushService?.Dispose();
                WindowSystem.RemoveAllWindows();

                // 移除命令和钩子
                CommandManager.RemoveHandler(CommandName);
                CommandManager.RemoveHandler(CommandSetting);
                CommandManager.RemoveHandler(CommandSwitch);
                CommandManager.RemoveHandler(CommandDisable);
                CommandManager.RemoveHandler(CommandEnable);
                PluginInterface.UiBuilder.Draw -= DrawUI;
                PluginInterface.UiBuilder.OpenConfigUi -= ToggleConfigUI;

                pluginLog.Info("The plugin is uninstalled");
            }
            catch (Exception ex)
            {
                pluginLog.Error($"Dispose error: {ex}");
            }
            finally
            {
                GC.SuppressFinalize(this);
            }
        }

        public void InitializeDtrBar(IDtrBar dtrBar, Localization loc)
        {
            var dtrBarTitle = "DutyPusher";
            try
            {
                dtrEntry ??= DtrBar.Get(dtrBarTitle);
                dtrEntry.OnClick += () =>
                {
                    try
                    {
                        Configuration.Enable = !Configuration.Enable;
                        Configuration.Save();
                        pluginLog.Info($"Dtr bar toggle switch enable: {Configuration.Enable}");
                        UpdateDtrBarState(); // Call without parameter
                    }
                    catch (Exception ex)
                    {
                        pluginLog.Error($"Dtr bar toggle error: {ex}");
                    }
                };
                UpdateDtrBarState(); // Call without parameter
            }
            catch (Exception e)
            {
                pluginLog.Error($"DTR bar initalize error: {e.Message}");
            }
        }

        public void UpdateDtrBarState()
        {
            if (dtrEntry == null) return;
            try
            {
                dtrEntry.Text = $"{Plugin.loc.GetString("PluginName")}: " +
                                (Configuration.Enable ?
                                 Plugin.loc.GetString("On") :
                                 Plugin.loc.GetString("Off"));
                pluginLog.Debug("DTR bar Updated");
            }
            catch (Exception ex)
            {
                pluginLog.Error($"DTR bar update error: {ex}");
            }
        }

        private void OnCommand(string command, string args)
        {
            ToggleConfigUI();
        }

        private void SwitchEnabledState(string command, string args)
        {
            try
            {
                Configuration.Enable = !Configuration.Enable;
                Configuration.Save();
                pluginLog.Info($"Command toggle switch enable: {Configuration.Enable}");
                UpdateDtrBarState();
                var echoMessage = new XivChatEntry
                {
                    Type = XivChatType.Echo,
                    Message = new SeString(new TextPayload($"{Plugin.loc.GetString("PluginName")}: " +
                                (Configuration.Enable ?
                                 Plugin.loc.GetString("On") :
                                 Plugin.loc.GetString("Off"))),
                                 new IconPayload(
                                 (Configuration.Enable?
                                 BitmapFontIcon.Alarm :
                                 BitmapFontIcon.DoNotDisturb)))
                };
                ChatGui.Print(echoMessage);

            }
            catch (Exception ex)
            {
                pluginLog.Error($"Command toggle error: {ex}");
            }
        }

        private void SwitchEnable(string command, string args)
        {
            try
            {
                Configuration.Enable = true;
                Configuration.Save();
                pluginLog.Info($"Command toggle switch enable: {Configuration.Enable}");
                UpdateDtrBarState();
                var echoMessage = new XivChatEntry
                {
                    Type = XivChatType.Echo,
                    Message = new SeString(new TextPayload($"{Plugin.loc.GetString("PluginName")}: {Plugin.loc.GetString("On")}" ), new IconPayload(BitmapFontIcon.Alarm))
                };
                ChatGui.Print(echoMessage);

            }
            catch (Exception ex)
            {
                pluginLog.Error($"Command toggle error: {ex}");
            }
        }

        private void SwitchDisable(string command, string args)
        {
            try
            {
                Configuration.Enable = false;
                Configuration.Save();
                pluginLog.Info($"Command toggle switch enable: {Configuration.Enable}");
                UpdateDtrBarState();
                var echoMessage = new XivChatEntry
                {
                    Type = XivChatType.Echo,
                    Message = new SeString(new TextPayload($"{Plugin.loc.GetString("PluginName")}: {Plugin.loc.GetString("Off")}"), new IconPayload(BitmapFontIcon.DoNotDisturb))
                };
                ChatGui.Print(echoMessage);
            }
            catch (Exception ex)
            {
                pluginLog.Error($"Command toggle error: {ex}");
            }
        }


        private void DrawUI() => WindowSystem.Draw();

        public void ToggleConfigUI() => ConfigWindow.Toggle();
        
    }

}
