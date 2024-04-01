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

        void onDeeplinkLoaded([NotNull] string deeplink) {
            _onDeeplinkLoadedDelegate(deeplink);
        }

        void onError([NotNull] string error, [NotNull] string referrer) {
            _onErrorDelegate?.Invoke(GetError(error), referrer == "<UNITY_NULL>" ? null : referrer);
        }

        private static DeferredDeeplink.Error GetError([NotNull] string str) {
            return str switch {
                "NoReferrer" => DeferredDeeplink.Error.NoReferrer,
                "NotAFirstLaunch" => DeferredDeeplink.Error.NotAFirstLaunch,
                "ParseError" => DeferredDeeplink.Error.ParseError,
                _ => DeferredDeeplink.Error.Unknown,
            };
        }
    }
}
#endif