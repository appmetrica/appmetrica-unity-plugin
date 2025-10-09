#if UNITY_ANDROID
using JetBrains.Annotations;
using UnityEngine;

namespace Io.AppMetrica.Native.Android.Proxy {
    internal static class AppMetricaLibraryAdapterProxy {
        private static readonly AndroidJavaClass NativeClass = new AndroidJavaClass("io.appmetrica.analytics.plugin.unity.AppMetricaLibraryAdapterProxy");

        public static void SubscribeForAutoCollectedData([NotNull] string apiKey) {
            NativeClass.CallStatic("subscribeForAutoCollectedData", apiKey);
        }
    }
}
#endif
