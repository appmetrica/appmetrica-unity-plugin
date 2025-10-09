#if UNITY_ANDROID
using Io.AppMetrica.Native.Android.Proxy;
using JetBrains.Annotations;

namespace Io.AppMetrica.Native.Android {
    internal class AppMetricaLibraryAdapterAndroid : IAppMetricaLibraryAdapterNative {
        public void SubscribeForAutoCollectedData([NotNull] string apiKey) {
            AppMetricaLibraryAdapterProxy.SubscribeForAutoCollectedData(apiKey);
        }
    }
}
#endif
