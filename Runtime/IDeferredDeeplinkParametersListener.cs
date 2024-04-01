using JetBrains.Annotations;
using System.Collections.Generic;

namespace Io.AppMetrica {
    /// <summary>
    /// Callback for <see cref="AppMetrica.RequestDeferredDeeplinkParameters"/>.
    /// </summary>
    public static class DeferredDeeplinkParameters {
        public delegate void ParametersDelegate([NotNull] IDictionary<string, string> parameters);
        public delegate void ErrorDelegate(Error? error, [CanBeNull] string referrer);
        
        public enum Error {
            /// <summary>
            /// Means that referrer was not obtained (because there was no provider
            /// (Google Play Services, Huawei Media Services) on device or because the provider returned null).
            /// </summary>
            NoReferrer,

            /// <summary>
            /// Tells that Google Play referrer wasn't obtained because it can be requested during first launch only.
            /// </summary>
            NotAFirstLaunch,

            /// <summary>
            /// Tells that Google Play referrer was obtained but it did not contain deferred deeplink.
            /// </summary>
            ParseError,

            /// <summary>
            /// Could not obtain deferred deeplink due to unknown error.
            /// </summary>
            Unknown,
        }
    }
}
