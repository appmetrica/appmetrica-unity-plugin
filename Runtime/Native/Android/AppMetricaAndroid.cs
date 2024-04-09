#if UNITY_ANDROID
using Io.AppMetrica.Ecommerce;
using Io.AppMetrica.Native.Android.Proxy;
using Io.AppMetrica.Native.Utils.Serializer;
using Io.AppMetrica.Profile;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Io.AppMetrica.Native.Android {
    internal class AppMetricaAndroid : IAppMetricaNative {
        public void Activate([NotNull] AppMetricaConfig config) {
            AppMetricaProxy.Activate(config.ToJsonString());
        }

        public void ActivateReporter([NotNull] ReporterConfig config) {
            AppMetricaProxy.ActivateReporter(config.ToJsonString());
        }

        public void ClearAppEnvironment() {
            AppMetricaProxy.ClearAppEnvironment();
        }

        [CanBeNull]
        public string GetDeviceId() {
            return AppMetricaProxy.GetDeviceId();
        }

        [NotNull]
        public string GetLibraryVersion() {
            return AppMetricaProxy.GetLibraryVersion();
        }

        [NotNull]
        public IReporter GetReporter([NotNull] string apiKey) {
            AppMetricaProxy.TouchReporter(apiKey);
            return new ReporterAndroid(apiKey);
        }

        [CanBeNull]
        public string GetUuid() {
            return AppMetricaProxy.GetUuid();
        }

        public bool IsActivated() {
            return AppMetricaProxy.IsActivated();
        }

        public void PauseSession() {
            AppMetricaProxy.PauseSession();
        }

        public void PutAppEnvironmentValue([NotNull] string key, [CanBeNull] string value) {
            AppMetricaProxy.PutAppEnvironmentValue(key, value);
        }

        public void PutErrorEnvironmentValue([NotNull] string key, [CanBeNull] string value) {
            AppMetricaProxy.PutErrorEnvironmentValue(key, value);
        }

        public void ReportAdRevenue([NotNull] AdRevenue adRevenue) {
            AppMetricaProxy.ReportAdRevenue(adRevenue.ToJsonString());
        }

        public void ReportAppOpen([NotNull] string deeplink) {
            AppMetricaProxy.ReportAppOpen(deeplink);
        }

        public void ReportECommerce([NotNull] ECommerceEvent ecommerce) {
            var jsonString = ecommerce.ToJsonString();
            if (jsonString != null) {
                AppMetricaProxy.ReportECommerce(jsonString);
            }
        }

        public void ReportError([NotNull] string message, [NotNull] Exception error) {
            AppMetricaProxy.ReportErrorWithoutIdentifier(message, error.ToJsonString());
        }

        public void ReportError([NotNull] string identifier, [CanBeNull] string message, [CanBeNull] Exception error) {
            AppMetricaProxy.ReportError(identifier, message, error?.ToJsonString());
        }

        public void ReportEvent([NotNull] string eventName) {
            AppMetricaProxy.ReportEvent(eventName, null);
        }

        public void ReportEvent([NotNull] string eventName, [CanBeNull] string jsonValue) {
            AppMetricaProxy.ReportEvent(eventName, jsonValue);
        }

        public void ReportExceptionFromLog(string condition, string exception, string source) {
            AppMetricaProxy.ReportErrorWithoutIdentifier(condition, ExceptionSerializer.GetFromLogs(condition, exception, source));
        }

        public void ReportExternalAttribution([NotNull] string source, [NotNull] string value) {
            AppMetricaProxy.ReportExternalAttribution(source, value);
        }

        public void ReportRevenue([NotNull] Revenue revenue) {
            AppMetricaProxy.ReportRevenue(revenue.ToJsonString());
        }

        public void ReportUnhandledException([NotNull] Exception exception) {
            AppMetricaProxy.ReportUnhandledException(exception.ToJsonString());
        }

        public void ReportUserProfile([NotNull] UserProfile profile) {
            AppMetricaProxy.ReportUserProfile(profile.ToJsonString());
        }

        public void RequestDeferredDeeplink([NotNull] DeferredDeeplink.DeeplinkDelegate onDeeplinkLoaded, [CanBeNull] DeferredDeeplink.ErrorDelegate onError) {
            AppMetricaProxy.RequestDeferredDeeplink(new DeferredDeeplinkListenerProxy(onDeeplinkLoaded, onError));
        }

        public void RequestDeferredDeeplinkParameters([NotNull] DeferredDeeplinkParameters.ParametersDelegate onParametersLoaded, [CanBeNull] DeferredDeeplinkParameters.ErrorDelegate onError) {
            AppMetricaProxy.RequestDeferredDeeplinkParameters(new DeferredDeeplinkParametersListenerProxy(onParametersLoaded, onError));
        }

        public void RequestStartupParams([NotNull] StartupParamsDelegate action, [NotNull] IEnumerable<string> identifiers) {
            AppMetricaProxy.RequestStartupParams(new StartupParamsCallbackProxy(action), identifiers.ToArray());
        }

        public void ResumeSession() {
            AppMetricaProxy.ResumeSession();
        }

        public void SendEventsBuffer() {
            AppMetricaProxy.SendEventsBuffer();
        }

        public void SetDataSendingEnabled(bool enabled) {
            AppMetricaProxy.SetDataSendingEnabled(enabled);
        }

        public void SetLocation([CanBeNull] Location? location) {
            AppMetricaProxy.SetLocation(location?.ToJsonString());
        }

        public void SetLocationTracking(bool enabled) {
            AppMetricaProxy.SetLocationTracking(enabled);
        }

        public void SetUserProfileID([CanBeNull] string userProfileID) {
            AppMetricaProxy.SetUserProfileID(userProfileID);
        }
    }
}
#endif
