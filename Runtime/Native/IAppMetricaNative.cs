using Io.AppMetrica.Ecommerce;
using Io.AppMetrica.Profile;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;

namespace Io.AppMetrica.Native {
    internal interface IAppMetricaNative {
        void Activate([NotNull] AppMetricaConfig config);

        void ActivateReporter([NotNull] ReporterConfig config);

        void ClearAppEnvironment();

        [CanBeNull]
        string GetDeviceId();

        [NotNull]
        string GetLibraryVersion();

        [NotNull]
        IReporter GetReporter([NotNull] string apiKey);

        [CanBeNull]
        string GetUuid();

        bool IsActivated();

        void PauseSession();

        void PutAppEnvironmentValue([NotNull] string key, [CanBeNull] string value);

        void PutErrorEnvironmentValue([NotNull] string key, [CanBeNull] string value);

        void ReportAdRevenue([NotNull] AdRevenue adRevenue);

        void ReportAppOpen([NotNull] string deeplink);

        void ReportECommerce([NotNull] ECommerceEvent ecommerce);

        void ReportError([NotNull] string message, [NotNull] Exception error);

        void ReportError([NotNull] string identifier, [CanBeNull] string message, [CanBeNull] Exception error);

        void ReportEvent([NotNull] string eventName);

        void ReportEvent([NotNull] string eventName, [CanBeNull] string jsonValue);

        void ReportExceptionFromLog(string condition, string exception, string source);

        void ReportExternalAttribution([NotNull] string source, [NotNull] string value);

        void ReportRevenue([NotNull] Revenue revenue);

        void ReportUnhandledException([NotNull] Exception exception);

        void ReportUserProfile([NotNull] UserProfile profile);

        void RequestDeferredDeeplink([NotNull] DeferredDeeplink.DeeplinkDelegate onDeeplinkLoaded, [CanBeNull] DeferredDeeplink.ErrorDelegate onError);

        void RequestDeferredDeeplinkParameters([NotNull] DeferredDeeplinkParameters.ParametersDelegate onParametersLoaded, [CanBeNull] DeferredDeeplinkParameters.ErrorDelegate onError);

        void RequestStartupParams([NotNull] StartupParamsDelegate action, [NotNull] IEnumerable<string> identifiers);

        void ResumeSession();

        void SendEventsBuffer();

        void SetDataSendingEnabled(bool enabled);

        void SetLocation([CanBeNull] Location? location);

        void SetLocationTracking(bool enabled);

        void SetUserProfileID([CanBeNull] string userProfileID);
    }
}
