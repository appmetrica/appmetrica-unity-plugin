#if UNITY_ANDROID
using JetBrains.Annotations;
using UnityEngine;

namespace Io.AppMetrica.Native.Android.Proxy {
    internal class DeferredDeeplinkListenerProxy : AndroidJavaProxy {
        [NotNull]
        private readonly DeferredDeeplink.DeeplinkDelegate _onDeeplinkLoadedDelegate;
        [CanBeNull]
        private readonly DeferredDeeplink.ErrorDelegate _onErrorDelegate;

        public DeferredDeeplinkListenerProxy(
            [NotNull] DeferredDeeplink.DeeplinkDelegate onDeeplinkLoadedDelegate,
            [CanBeNull] DeferredDeeplink.ErrorDelegate onErrorDelegate
        ) : base("io.appmetrica.analytics.plugin.unity.DeferredDeeplinkListenerProxy") {
            _onDeeplinkLoadedDelegate = onDeeplinkLoadedDelegate;
            _onErrorDelegate = onErrorDelegate;
        }

        // ReSharper disable once InconsistentNaming
        public void onDeeplinkLoaded([NotNull] string deeplink) {
            _onDeeplinkLoadedDelegate(deeplink);
        }

        // ReSharper disable once InconsistentNaming
        public void onError([NotNull] string error, [NotNull] string referrer) {
            _onErrorDelegate?.Invoke(GetError(error), referrer == "<UNITY_NULL>" ? null : referrer);
        }

        private static DeferredDeeplink.Error GetError([NotNull] string str) {
            switch (str) {
                case "NoReferrer":
                    return DeferredDeeplink.Error.NoReferrer;
                case "NotAFirstLaunch":
                    return DeferredDeeplink.Error.NotAFirstLaunch;
                case "ParseError":
                    return DeferredDeeplink.Error.ParseError;
                default:
                    return DeferredDeeplink.Error.Unknown;
            }
        }
    }
}
#endif
