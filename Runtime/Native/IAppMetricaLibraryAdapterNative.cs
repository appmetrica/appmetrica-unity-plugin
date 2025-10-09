using JetBrains.Annotations;

namespace Io.AppMetrica.Native
{
    internal interface IAppMetricaLibraryAdapterNative
    {
        void SubscribeForAutoCollectedData([NotNull] string apiKey);
    }
}
