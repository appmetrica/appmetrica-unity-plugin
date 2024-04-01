#if UNITY_ANDROID
using JetBrains.Annotations;
using UnityEngine;

namespace Io.AppMetrica.Native.Android.Proxy {
    internal static class ReporterProxy {
        private static readonly AndroidJavaClass NativeClass =
            new AndroidJavaClass("io.appmetrica.analytics.plugin.unity.ReporterProxy");

        public static void ClearAppEnvironment([NotNull] string apiKey) {
            NativeClass.CallStatic("clearAppEnvironment", apiKey);
        }

        public static void PauseSession([NotNull] string apiKey) {
            NativeClass.CallStatic("pauseSession", apiKey);
        }

        public static void PutAppEnvironmentValue([NotNull] string apiKey, [NotNull] string key, [CanBeNull] string value) {
            NativeClass.CallStatic("putAppEnvironmentValue", apiKey, key, value);
        }

        public static void ReportAdRevenue([NotNull] string apiKey, [NotNull] string adRevenue) {
            NativeClass.CallStatic("reportAdRevenue", apiKey, adRevenue);
        }

        public static void ReportECommerce([NotNull] string apiKey, [NotNull] string ecommerce) {
            NativeClass.CallStatic("reportECommerce", apiKey, ecommerce);
        }

        public static void ReportErrorWithoutIdentifier([NotNull] string apiKey, [NotNull] string message, [CanBeNull] string error) {
            NativeClass.CallStatic("reportErrorWithoutIdentifier", apiKey, message, error);
        }

        public static void ReportError([NotNull] string apiKey, [NotNull] string identifier, [CanBeNull] string message, [CanBeNull] string error) {
            NativeClass.CallStatic("reportError", apiKey, identifier, message, error);
        }

        public static void ReportEvent([NotNull] string apiKey, [NotNull] string eventName, [CanBeNull] string jsonValue) {
            NativeClass.CallStatic("reportEvent", apiKey, eventName, jsonValue);
        }

        public static void ReportRevenue([NotNull] string apiKey, [NotNull] string revenue) {
            NativeClass.CallStatic("reportRevenue", apiKey, revenue);
        }

        public static void ReportUnhandledException([NotNull] string apiKey, [NotNull] string exception) {
            NativeClass.CallStatic("reportUnhandledException", apiKey, exception);
        }

        public static void ReportUserProfile([NotNull] string apiKey, [NotNull] string profile) {
            NativeClass.CallStatic("reportUserProfile", apiKey, profile);
        }

        public static void ResumeSession([NotNull] string apiKey) {
            NativeClass.CallStatic("resumeSession", apiKey);
        }

        public static void SendEventsBuffer([NotNull] string apiKey) {
            NativeClass.CallStatic("sendEventsBuffer", apiKey);
        }

        public static void SetDataSendingEnabled([NotNull] string apiKey, bool enabled) {
            NativeClass.CallStatic("setDataSendingEnabled", apiKey, enabled);
        }

        public static void SetUserProfileID([NotNull] string apiKey, [CanBeNull] string profileID) {
            NativeClass.CallStatic("setUserProfileID", apiKey, profileID);
        }
    }
}
#endif
