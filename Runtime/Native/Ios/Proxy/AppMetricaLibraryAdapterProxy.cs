#if UNITY_IPHONE || UNITY_IOS
using System.Runtime.InteropServices;
using JetBrains.Annotations;
using System;

namespace Io.AppMetrica.Native.Ios.Proxy {
    internal static class AppMetricaLibraryAdapterProxy {
        [DllImport("__Internal")]
        public static extern void amau_subscribeForAutoCollectedData([NotNull] string apiKey);
    }
}
#endif
