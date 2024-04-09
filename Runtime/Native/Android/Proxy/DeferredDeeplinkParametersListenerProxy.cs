#if UNITY_ANDROID
using Io.AppMetrica.Internal;
using JetBrains.Annotations;
using System.Linq;
using UnityEngine;

namespace Io.AppMetrica.Native.Android.Proxy {
    internal class DeferredDeeplinkParametersListenerProxy : AndroidJavaProxy {
        [NotNull]
        private readonly DeferredDeeplinkParameters.ParametersDelegate _onParametersLoadedDelegate;
        [CanBeNull]
        private readonly DeferredDeeplinkParameters.ErrorDelegate _onErrorDelegate;

        public DeferredDeeplinkParametersListenerProxy(
            [NotNull] DeferredDeeplinkParameters.ParametersDelegate onParametersLoadedDelegate,
            [CanBeNull] DeferredDeeplinkParameters.ErrorDelegate onErrorDelegate
        ) : base("io.appmetrica.analytics.plugin.unity.DeferredDeeplinkParametersListenerProxy") {
            _onParametersLoadedDelegate = onParametersLoadedDelegate;
            _onErrorDelegate = onErrorDelegate;
        }

        // ReSharper disable once InconsistentNaming
        public void onParametersLoaded([NotNull] string parameters) {
            _onParametersLoadedDelegate(
                JSONDecoder.Decode(parameters).ObjectValue.ToDictionary(
                    keySelector: it => it.Key,
                    elementSelector: it => it.Value.StringValue
                )
            );
        }

        // ReSharper disable once InconsistentNaming
        public void onError([NotNull] string error, [NotNull] string referrer) {
            _onErrorDelegate?.Invoke(GetError(error), referrer);
        }

        private static DeferredDeeplinkParameters.Error GetError([NotNull] string str) {
            switch (str) {
                case "NoReferrer":
                    return DeferredDeeplinkParameters.Error.NoReferrer;
                case "NotAFirstLaunch":
                    return DeferredDeeplinkParameters.Error.NotAFirstLaunch;
                case "ParseError":
                    return DeferredDeeplinkParameters.Error.ParseError;
                default:
                    return DeferredDeeplinkParameters.Error.Unknown;
            }
        }
    }
}
#endif
