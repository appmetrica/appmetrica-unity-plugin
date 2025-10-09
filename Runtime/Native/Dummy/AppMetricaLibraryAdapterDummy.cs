using JetBrains.Annotations;

namespace Io.AppMetrica.Native.Dummy {
    internal class AppMetricaLibraryAdapterDummy : IAppMetricaLibraryAdapterNative {
        public void SubscribeForAutoCollectedData([NotNull] string apiKey) { }
    }
}
