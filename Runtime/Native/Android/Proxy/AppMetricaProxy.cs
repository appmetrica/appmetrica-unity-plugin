#if UNITY_ANDROID
using JetBrains.Annotations;
using UnityEngine;

namespace Io.AppMetrica.Native.Android.Proxy {
    internal static class AppMetricaProxy {
        private static readonly AndroidJavaClass NativeClass = new AndroidJavaClass("io.appmetrica.analytics.plugin.unity.AppMetricaProxy");

        public static void Activate([NotNull] string config) {
            NativeClass.CallStatic("activate", config);
        }

        public static void ActivateReporter([NotNull] string config) {
            NativeClass.CallStatic("activateReporter", config);
        }

        public static void ClearAppEnvironment() {
            NativeClass.CallStatic("clearAppEnvironment");
        }

        [CanBeNull]
        public static string GetDeviceId() {
            return NativeClass.CallStatic<string>("getDeviceId");
        }

        [NotNull]
        public static string GetLibraryVersion() {
            return NativeClass.CallStatic<string>("getLibraryVersion");
        }

        [CanBeNull]
        public static string GetUuid() {
            return NativeClass.CallStatic<string>("getUuid");
        }

        public static bool IsActivated() {
            return NativeClass.CallStatic<bool>("isActivated");
        }

        public static void PauseSession() {
            NativeClass.CallStatic("pauseSession");
        }

        public static void PutAppEnvironmentValue([NotNull] string key, [CanBeNull] string value) {
            NativeClass.CallStatic("putAppEnvironmentValue", key, value);
        }

        public static void PutErrorEnvironmentValue([NotNull] string key, [CanBeNull] string value) {
            NativeClass.CallStatic("putErrorEnvironmentValue", key, value);
        }

        public static void ReportAdRevenue([NotNull] string adRevenue) {
            NativeClass.CallStatic("reportAdRevenue", adRevenue);
        }

        public static void ReportAppOpen([NotNull] string deeplink) {
            NativeClass.CallStatic("reportAppOpen", deeplink);
        }

        public static void ReportECommerce([NotNull] string ecommerce) {
            NativeClass.CallStatic("reportECommerce", ecommerce);
        }

        public static void ReportErrorWithoutIdentifier([NotNull] string message, [NotNull] string error) {
            NativeClass.CallStatic("reportErrorWithoutIdentifier", message, error);
        }

        public static void ReportError([NotNull] string identifier, [CanBeNull] string message, [CanBeNull] string error) {
            NativeClass.CallStatic("reportError", identifier, message, error);
        }

        public static void ReportEvent([NotNull] string eventName, [CanBeNull] string jsonValue) {
            NativeClass.CallStatic("reportEvent", eventName, jsonValue);
        }

        public static void ReportExternalAttribution([NotNull] string source, [NotNull] string value) {
            NativeClass.CallStatic("reportExternalAttribution", source, value);
        }

        public static void ReportRevenue([NotNull] string revenue) {
            NativeClass.CallStatic("reportRevenue", revenue);
        }

        public static void ReportUnhandledException([NotNull] string exception) {
            NativeClass.CallStatic("reportUnhandledException", exception);
        }

        public static void ReportUserProfile([NotNull] string profile) {
            NativeClass.CallStatic("reportUserProfile", profile);
        }

        public static void RequestDeferredDeeplink([NotNull] DeferredDeeplinkListenerProxy listener) {
            NativeClass.CallStatic("requestDeferredDeeplink", listener);
        }

        public static void RequestDeferredDeeplinkParameters([NotNull] DeferredDeeplinkParametersListenerProxy listener) {
            NativeClass.CallStatic("requestDeferredDeeplinkParameters", listener);
        }

        public static void RequestStartupParams([NotNull] StartupParamsCallbackProxy action, [NotNull] string[] identifiers) {
            NativeClass.CallStatic("requestStartupParams", action, identifiers);
        }

        public static void ResumeSession() {
            NativeClass.CallStatic("resumeSession");
        }

        public static void SendEventsBuffer() {
            NativeClass.CallStatic("sendEventsBuffer");
        }

        public static void SetDataSendingEnabled(bool enabled) {
            NativeClass.CallStatic("setDataSendingEnabled", enabled);
        }

        public static void SetLocation([CanBeNull] string location) {
            NativeClass.CallStatic("setLocation", location);
        }

        public static void SetLocationTracking(bool enabled) {
            NativeClass.CallStatic("setLocationTracking", enabled);
        }

        public static void SetUserProfileID([CanBeNull] string userProfileId) {
            NativeClass.CallStatic("setUserProfileID", userProfileId);
        }

        public static void TouchReporter([NotNull] string apiKey) {
            NativeClass.CallStatic("touchReporter", apiKey);
        }
    }
}
#endif
