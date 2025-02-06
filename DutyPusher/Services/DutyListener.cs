using Dalamud.Loc;
using Dalamud.Plugin.Services;
using System;

namespace DutyPusher.Services
{
    public class DutyListener: IDisposable
    {
        private Localization loc;
        private readonly IClientState clientState;
        private readonly PushService pushService;
        private readonly IPluginLog pluginLog;
        private readonly Func<bool> getEnableState;
        private bool disposed;

        public DutyListener(Func<bool> getEnableState, IPluginLog pluginLog, Localization loc, IClientState clientState, PushService pushService)
        {
            this.loc = loc;
            this.clientState = clientState;
            this.pushService = pushService;
            this.pluginLog = pluginLog;
            this.getEnableState = getEnableState;

            UpdateSubscriptionState();
        }

        public void UpdateSubscriptionState()
        {
            var shouldEnable = getEnableState();

            if (shouldEnable)
            {
                Enable();
            }
            else
            {
                DisposeCore();
            }
        }
        public void Enable()
        {
            if (disposed) return;

            try
            {
                pluginLog.Info("DutyListener Enable: subscribing to CfPop");
                clientState.CfPop -= OnDutyPop; // 确保总是取消订阅
                clientState.CfPop += OnDutyPop;
            }
            catch (Exception ex)
            {
                pluginLog.Error($"注册监听失败: {ex.Message}");
            }
        }

        private async void OnDutyPop(Lumina.Excel.Sheets.ContentFinderCondition condition)
        {
            if (disposed) return;

            pluginLog.Info("CfPop event triggered.");
            await pushService.SendNotificationAsync(loc.GetString("PushTitle"), loc.GetString("PushContent"));
        }

        public void Dispose()
        {
            if (disposed) return;

            DisposeCore();
            disposed = true;

            GC.SuppressFinalize(this);
        }

        private void DisposeCore()
        {
            try
            {
                clientState.CfPop -= OnDutyPop;
                pluginLog.Info("DutyListener Disable");
            }
            catch (Exception ex)
            {
                pluginLog.Error($"Error: {ex.Message}");
            }
        }
    }
}
