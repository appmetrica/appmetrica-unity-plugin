#if UNITY_IPHONE || UNITY_IOS
using System;
using System.Collections.Generic;
using Io.AppMetrica.Ecommerce;
using Io.AppMetrica.Internal;
using Io.AppMetrica.Native.Ios.Proxy;
using Io.AppMetrica.Native.Utils.Serializer;
using Io.AppMetrica.Profile;
using JetBrains.Annotations;

namespace Io.AppMetrica.Native.Ios {
    internal class AppMetricaIos : IAppMetricaNative {
        public void Activate([NotNull] AppMetricaConfig config) {
            AppMetricaProxy.amau_activate(config.ToJsonString());
        }

        public void ActivateReporter([NotNull] ReporterConfig config) {
            AppMetricaProxy.amau_activateReporter(config.ToJsonString());
        }

        public void ClearAppEnvironment() {
            AppMetricaProxy.amau_clearAppEnvironment();
        }

        [CanBeNull]
        public string GetDeviceId() {
            return AppMetricaProxy.amau_getDeviceID();
        }

        [NotNull]
        public string GetLibraryVersion() {
            return AppMetricaProxy.amau_getLibraryVersion();
        }

        [NotNull]
        public IReporter GetReporter([NotNull] string apiKey) {
            AppMetricaProxy.amau_touchReporter(apiKey);
            return new ReporterIos(apiKey);
        }

        [CanBeNull]
        public string GetUuid() {
            return AppMetricaProxy.amau_getUuid();
        }

        public bool IsActivated() {
            return AppMetricaProxy.amau_isActivated();
        }

        public void PauseSession() {
            AppMetricaProxy.amau_pauseSession();
        }

        public void PutAppEnvironmentValue([NotNull] string key, [CanBeNull] string value) {
            AppMetricaProxy.amau_putAppEnvironmentValue(key, value);
        }

        public void PutErrorEnvironmentValue([NotNull] string key, [CanBeNull] string value) {
            AppMetricaProxy.amau_putErrorEnvironmentValue(key, value);
        }

        public void ReportAdRevenue([NotNull] AdRevenue adRevenue) {
            AppMetricaProxy.amau_reportAdRevenue(adRevenue.ToJsonString());
        }

        public void ReportAppOpen([NotNull] string deeplink) {
            AppMetricaProxy.amau_reportAppOpen(deeplink);
        }

        public void ReportECommerce([NotNull] ECommerceEvent ecommerce) {
            var json = ecommerce.ToJsonString();
            if (json != null) {
                AppMetricaProxy.amau_reportECommerce(json);
            }
        }

        public void ReportError([NotNull] string message, [NotNull] Exception error) {
            AppMetricaProxy.amau_reportErrorWithoutIdentifier(message, error.ToJsonString());
        }

        public void ReportError([NotNull] string identifier, [CanBeNull] string message, [CanBeNull] Exception error) {
            AppMetricaProxy.amau_reportError(identifier, message, error?.ToJsonString());
        }

        public void ReportEvent([NotNull] string eventName) {
            AppMetricaProxy.amau_reportEvent(eventName, null);
        }

        public void ReportEvent([NotNull] string eventName, [CanBeNull] string jsonValue) {
            AppMetricaProxy.amau_reportEvent(eventName, jsonValue);
        }

        public void ReportExceptionFromLog(string condition, string exception, string source) {
            AppMetricaProxy.amau_reportErrorWithoutIdentifier(condition, ExceptionSerializer.GetFromLogs(condition, exception, source));
        }

        public void ReportExternalAttribution([NotNull] string source, [NotNull] string value) {
            AppMetricaProxy.amay_reportExternalAttribution(source, value);
        }

        public void ReportRevenue([NotNull] Revenue revenue) {
            AppMetricaProxy.amau_reportRevenue(revenue.ToJsonString());
        }

        public void ReportUnhandledException([NotNull] Exception exception) {
            AppMetricaProxy.amau_reportUnhandledException(exception.ToJsonString());
        }

        public void ReportUserProfile([NotNull] UserProfile profile) {
            AppMetricaProxy.amau_reportUserProfile(profile.ToJsonString());
        }

        public void RequestDeferredDeeplink([NotNull] DeferredDeeplink.DeeplinkDelegate onDeeplinkLoaded, [CanBeNull] DeferredDeeplink.ErrorDelegate onError) {
            // not supported in iOS
        }

        public void RequestDeferredDeeplinkParameters([NotNull] DeferredDeeplinkParameters.ParametersDelegate onParametersLoaded, [CanBeNull] DeferredDeeplinkParameters.ErrorDelegate onError) {
            // not supported in iOS
        }

        public void RequestStartupParams([NotNull] StartupParamsDelegate action, [NotNull] IEnumerable<string> identifiers) {
            AppMetricaProxy.amau_requestStartupParams(JSONEncoder.Encode(identifiers), StartupParamsCallbackProxy.Callback, ActionUtils.ToIntPtr(action));
        }

        public void ResumeSession() {
            AppMetricaProxy.amau_resumeSession();
        }

        public void SendEventsBuffer() {
            AppMetricaProxy.amau_sendEventsBuffer();
        }

        public void SetDataSendingEnabled(bool enabled) {
            AppMetricaProxy.amau_setDataSendingEnabled(enabled);
        }

        public void SetLocation([CanBeNull] Location? location) {
            AppMetricaProxy.amau_setLocation(location?.ToJsonString());
        }

        public void SetLocationTracking(bool enabled) {
            AppMetricaProxy.amau_setLocationTracking(enabled);
        }

        public void SetUserProfileID([CanBeNull] string userProfileID) {
            AppMetricaProxy.amau_setUserProfileID(userProfileID);
        }
    }
}
#endif
