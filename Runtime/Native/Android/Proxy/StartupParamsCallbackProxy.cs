#if UNITY_ANDROID
using Io.AppMetrica.Native.Utils.Serializer;
using JetBrains.Annotations;
using UnityEngine;

namespace Io.AppMetrica.Native.Android.Proxy {
    internal class StartupParamsCallbackProxy : AndroidJavaProxy {
        [NotNull]
        private readonly StartupParamsDelegate _delegate;

        public StartupParamsCallbackProxy([NotNull] StartupParamsDelegate @delegate) : base("io.appmetrica.analytics.plugin.unity.StartupParamsCallbackProxy") {
            _delegate = @delegate;
        }

        // ReSharper disable once InconsistentNaming
        public void onReceive([NotNull] string result, [NotNull] string errorReason) {
            _delegate(StartupParamsSerializer.ResultFromJsonString(result), StartupParamsSerializer.ErrorReasonFromJsonString(errorReason));
        }
    }
}
#endif
