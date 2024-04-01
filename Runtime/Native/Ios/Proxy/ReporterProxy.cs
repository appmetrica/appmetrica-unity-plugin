#if UNITY_IPHONE || UNITY_IOS
using JetBrains.Annotations;
using System.Runtime.InteropServices;

namespace Io.AppMetrica.Native.Ios.Proxy {
    internal static class ReporterProxy {
        [DllImport("__Internal")]
        public static extern void amau_reporterClearAppEnvironment([NotNull] string apiKey);

        [DllImport("__Internal")]
        public static extern void amau_reporterPauseSession([NotNull] string apiKey);

        [DllImport("__Internal")]
        public static extern void amau_reporterPutAppEnvironmentValue([NotNull] string apiKey, [NotNull] string key, [CanBeNull] string value);

        [DllImport("__Internal")]
        public static extern void amau_reporterReportAdRevenue([NotNull] string apiKey, [NotNull] string adRevenue);

        [DllImport("__Internal")]
        public static extern void amau_reporterReportECommerce([NotNull] string apiKey, [NotNull] string ecommerce);

        [DllImport("__Internal")]
        public static extern void amau_reporterReportErrorWithoutIdentifier([NotNull] string apiKey, [NotNull] string message, [CanBeNull] string error);

        [DllImport("__Internal")]
        public static extern void amau_reporterReportError([NotNull] string apiKey, [NotNull] string identifier, [CanBeNull] string message, [CanBeNull] string error);

        [DllImport("__Internal")]
        public static extern void amau_reporterReportEvent([NotNull] string apiKey, [NotNull] string message, [CanBeNull] string jsonValue);

        [DllImport("__Internal")]
        public static extern void amau_reporterReportRevenue([NotNull] string apiKey, [NotNull] string revenue);

        [DllImport("__Internal")]
        public static extern void amau_reporterReportUnhandledException([NotNull] string apiKey, [NotNull] string exception);

        [DllImport("__Internal")]
        public static extern void amau_reporterReportUserProfile([NotNull] string apiKey, [NotNull] string profile);

        [DllImport("__Internal")]
        public static extern void amau_reporterResumeSession([NotNull] string apiKey);

        [DllImport("__Internal")]
        public static extern void amau_reporterSendEventsBuffer([NotNull] string apiKey);

        [DllImport("__Internal")]
        public static extern void amau_reporterSetDataSendingEnabled([NotNull] string apiKey, bool enabled);

        [DllImport("__Internal")]
        public static extern void amau_reporterSetUserProfileID([NotNull] string apiKey, [CanBeNull] string userProfileID);
    }
}
#endif
