using Io.AppMetrica.Ecommerce;
using Io.AppMetrica.Profile;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;

namespace Io.AppMetrica.Native {
    internal interface IAppMetricaNative {
        public void Activate([NotNull] AppMetricaConfig config);

        public void ActivateReporter([NotNull] ReporterConfig config);

        public void ClearAppEnvironment();

        [CanBeNull]
        public string GetDeviceId();

        [NotNull]
        public string GetLibraryVersion();

        [NotNull]
        public IReporter GetReporter([NotNull] string apiKey);

        [CanBeNull]
        public string GetUuid();

        public void PauseSession();

        public void PutAppEnvironmentValue([NotNull] string key, [CanBeNull] string value);

        public void PutErrorEnvironmentValue([NotNull] string key, [CanBeNull] string value);

        public void ReportAdRevenue([NotNull] AdRevenue adRevenue);

        public void ReportAppOpen([NotNull] string deeplink);

        public void ReportECommerce([NotNull] ECommerceEvent ecommerce);

        public void ReportError([NotNull] string message, [NotNull] Exception error);

        public void ReportError([NotNull] string identifier, [CanBeNull] string message, [CanBeNull] Exception error);

        public void ReportEvent([NotNull] string eventName);

        public void ReportEvent([NotNull] string eventName, [CanBeNull] string jsonValue);

        public void ReportRevenue([NotNull] Revenue revenue);

        public void ReportUnhandledException([NotNull] Exception exception);

        public void ReportUserProfile([NotNull] UserProfile profile);

        public void RequestDeferredDeeplink([NotNull] DeferredDeeplink.DeeplinkDelegate onDeeplinkLoaded, [CanBeNull] DeferredDeeplink.ErrorDelegate onError);

        public void RequestDeferredDeeplinkParameters([NotNull] DeferredDeeplinkParameters.ParametersDelegate onParametersLoaded, [CanBeNull] DeferredDeeplinkParameters.ErrorDelegate onError);

        public void RequestStartupParams([NotNull] StartupParams.Delegate action, [NotNull] IEnumerable<string> identifiers);

        public void ResumeSession();

        public void SendEventsBuffer();

        public void SetDataSendingEnabled(bool enabled);

        public void SetLocation([CanBeNull] Location? location);

        public void SetLocationTracking(bool enabled);

        public void SetUserProfileID([CanBeNull] string userProfileID);
    }
}
