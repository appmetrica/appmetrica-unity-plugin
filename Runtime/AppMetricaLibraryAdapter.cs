using Io.AppMetrica.Native;
using JetBrains.Annotations;

#if UNITY_ANDROID && !UNITY_EDITOR
using Io.AppMetrica.Native.Android;
#elif (UNITY_IPHONE || UNITY_IOS) && !UNITY_EDITOR
using Io.AppMetrica.Native.Ios;
#else
using Io.AppMetrica.Native.Dummy;
#endif

namespace Io.AppMetrica
{
    /// <summary>
    /// Adapter for libraries that use AppMetrica.
    /// </summary>
    public static class AppMetricaLibraryAdapter
    {
        [NotNull]
        private static readonly IAppMetricaLibraryAdapterNative Native;

        static AppMetricaLibraryAdapter()
        {
#if UNITY_ANDROID && !UNITY_EDITOR
            Native = new AppMetricaLibraryAdapterAndroid();
#elif (UNITY_IPHONE || UNITY_IOS) && !UNITY_EDITOR
            Native = new AppMetricaLibraryAdapterIos();
#else
            Native = new AppMetricaLibraryAdapterDummy();
#endif
        }

        /// <summary>
        /// Subscribes for auto-collected data flow.
        /// 
        /// <p><b>Platforms</b>: Android, iOS.</p>
        /// </summary>
        /// <param name="apiKey">AppMetrica API_KEY.</param>
        public static void SubscribeForAutoCollectedData([NotNull] string apiKey)
        {
            Native.SubscribeForAutoCollectedData(apiKey);
        }
    }
}
