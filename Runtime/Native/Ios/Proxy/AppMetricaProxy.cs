#if UNITY_IPHONE || UNITY_IOS
using System.Runtime.InteropServices;
using JetBrains.Annotations;
using System;

namespace Io.AppMetrica.Native.Ios.Proxy {
    internal static class AppMetricaProxy {
        [DllImport("__Internal")]
        public static extern void amau_activate([NotNull] string config);

        [DllImport("__Internal")]
        public static extern void amau_activateReporter([NotNull] string config);

        [DllImport("__Internal")]
        public static extern void amau_clearAppEnvironment();

        [CanBeNull]
        [DllImport("__Internal")]
        public static extern string amau_getDeviceID();

        [NotNull]
        [DllImport("__Internal")]
        public static extern string amau_getLibraryVersion();

        [CanBeNull]
        [DllImport("__Internal")]
        public static extern string amau_getUuid();

        [DllImport("__Internal")]
        public static extern bool amau_isActivated();
        
        [DllImport("__Internal")]
        public static extern void amau_pauseSession();

        [DllImport("__Internal")]
        public static extern void amau_putAppEnvironmentValue([NotNull] string key, [CanBeNull] string value);

        [DllImport("__Internal")]
        public static extern void amau_putErrorEnvironmentValue([NotNull] string key, [CanBeNull] string value);

        [DllImport("__Internal")]
        public static extern void amau_reportAdRevenue([NotNull] string adRevenue);

        [DllImport("__Internal")]
        public static extern void amau_reportAppOpen([NotNull] string deeplink);

        [DllImport("__Internal")]
        public static extern void amau_reportECommerce([NotNull] string ecommerce);

        [DllImport("__Internal")]
        public static extern void amau_reportErrorWithoutIdentifier([NotNull] string message, [NotNull] string error);

        [DllImport("__Internal")]
        public static extern void amau_reportError([NotNull] string identifier, [CanBeNull] string message, [CanBeNull] string error);

        [DllImport("__Internal")]
        public static extern void amau_reportEvent([NotNull] string message, [CanBeNull] string jsonValue);

        [DllImport("__Internal")]
        public static extern void amay_reportExternalAttribution([NotNull] string source, [NotNull] string value);
        
        [DllImport("__Internal")]
        public static extern void amau_reportRevenue([NotNull] string revenue);

        [DllImport("__Internal")]
        public static extern void amau_reportUnhandledException([NotNull] string exception);

        [DllImport("__Internal")]
        public static extern void amau_reportUserProfile([NotNull] string profile);

        [DllImport("__Internal")]
        public static extern void amau_requestStartupParams([NotNull] string identifiers, [NotNull] AMAUStartupParamsCallbackDelegate @delegate, IntPtr actionPtr);

        [DllImport("__Internal")]
        public static extern void amau_resumeSession();

        [DllImport("__Internal")]
        public static extern void amau_sendEventsBuffer();

        [DllImport("__Internal")]
        public static extern void amau_setDataSendingEnabled(bool enabled);

        [DllImport("__Internal")]
        public static extern void amau_setLocation([CanBeNull] string location);

        [DllImport("__Internal")]
        public static extern void amau_setLocationTracking(bool enabled);

        [DllImport("__Internal")]
        public static extern void amau_setUserProfileID([CanBeNull] string userProfileID);

        [DllImport("__Internal")]
        public static extern void amau_touchReporter([NotNull] string apiKey);
    }
}
#endif
