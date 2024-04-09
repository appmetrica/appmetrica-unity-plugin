using JetBrains.Annotations;
using System.Collections.Generic;

namespace Io.AppMetrica {
    /// <summary>
    /// Helper class for <see cref="AppMetrica.RequestDeferredDeeplinkParameters"/> method.
    /// </summary>
    public static class DeferredDeeplinkParameters {
        /// <summary>
        /// Called when deferred deeplink parameters requested in <see cref="AppMetrica.RequestDeferredDeeplinkParameters"/> are obtained.
        /// </summary>
        /// <param name="parameters">dictionary with obtained deferred deeplink parameters.</param>
        public delegate void ParametersDelegate([NotNull] IDictionary<string, string> parameters);

        /// <summary>
        /// Called when error occurs during deferred deeplink parameters obtaining by <see cref="AppMetrica.RequestDeferredDeeplinkParameters"/>.
        /// </summary>
        /// <param name="error">error which tells why deferred deeplink parameters were not obtained.</param>
        /// <param name="referrer">Google Play referrer in case of <see cref="Error.ParseError"/>.</param>
        public delegate void ErrorDelegate(Error? error, [CanBeNull] string referrer);

        /// <summary>
        /// Possible values for error parameter in <see cref="ErrorDelegate"/> delegate.
        /// </summary>
        public enum Error {
            /// <summary>
            /// Means that referrer was not obtained.
            /// Because there was no provider (Google Play Services, Huawei Media Services) on device or because the provider returned null.
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
