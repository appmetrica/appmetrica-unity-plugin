#if UNITY_IPHONE || UNITY_IOS
using Io.AppMetrica.Native.Ios.Proxy;
using JetBrains.Annotations;

namespace Io.AppMetrica.Native.Ios {
    internal class AppMetricaLibraryAdapterIos : IAppMetricaLibraryAdapterNative {
        public void SubscribeForAutoCollectedData([NotNull] string apiKey) {
            AppMetricaLibraryAdapterProxy.amau_subscribeForAutoCollectedData(apiKey);
        }
    }
}
#endif
