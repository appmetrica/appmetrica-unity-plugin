#if UNITY_IPHONE || UNITY_IOS
using AOT;
using Io.AppMetrica.Native.Utils.Serializer;
using JetBrains.Annotations;
using System;

namespace Io.AppMetrica.Native.Ios.Proxy {
    internal delegate void AMAUStartupParamsCallbackDelegate(IntPtr actionPtr, [CanBeNull] string result, [CanBeNull] string errorReason);

    internal static class StartupParamsCallbackProxy {
        [MonoPInvokeCallback(typeof(AMAUStartupParamsCallbackDelegate))]
        public static void Callback(IntPtr actionPtr, [CanBeNull] string result, [CanBeNull] string errorReason) {
            ActionUtils.FromIntPtr<StartupParams.Delegate>(actionPtr)?.Invoke(
                StartupParamsSerializer.ResultFromJsonString(result),
                StartupParamsSerializer.ErrorReasonFromJsonString(errorReason)
            );
        }
    }
}
#endif
