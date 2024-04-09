using JetBrains.Annotations;
using System.Collections.Generic;

namespace Io.AppMetrica {
    /// <summary>
    /// Delegate for receiving startup parameters.
    /// </summary>
    /// <param name="result">the <see cref="StartupParamsResult"/> containing startup params.</param>
    /// <param name="errorReason">the reason explaining why startup params could not be obtained.</param>
    public delegate void StartupParamsDelegate([CanBeNull] StartupParamsResult result, [CanBeNull] StartupParamsErrorReason errorReason);

    /// <summary>
    /// Constants for <see cref="AppMetrica.RequestStartupParams"/> method.
    /// </summary>
    public static class StartupParamsKey {
        /// <summary>
        /// The key for uuid for identifiers param in <see cref="AppMetrica.RequestStartupParams"/> method.
        /// </summary>
        public const string AppMetricaUuid = "appmetrica_uuid";

        /// <summary>
        /// The key for device id for identifiers param in <see cref="AppMetrica.RequestStartupParams"/> method.
        /// </summary>
        public const string AppMetricaDeviceID = "appmetrica_device_id";

        /// <summary>
        /// The key for device id hash for identifiers param in <see cref="AppMetrica.RequestStartupParams"/> method.
        /// </summary>
        public const string AppMetricaDeviceIDHash = "appmetrica_device_id_hash";
    }

    /// <summary>
    /// Objects of this class contain the reason explaining why startup params could not be obtained.
    /// </summary>
    public class StartupParamsErrorReason {
        /// <summary>
        /// Text value of Reason.
        /// </summary>
        [NotNull]
        public string Value { get; }

        internal StartupParamsErrorReason([NotNull] string value) {
            Value = value;
        }
    }

    /// <summary>
    /// Objects of this class contain information about retrieved startup parameters.
    /// </summary>
    public class StartupParamsResult {
        /// <summary>
        /// UUID value or null.
        /// </summary>
        [CanBeNull]
        public string Uuid { get; }

        /// <summary>
        /// Device ID value or null.
        /// </summary>
        [CanBeNull]
        public string DeviceId { get; }

        /// <summary>
        /// Device ID hash or null.
        /// </summary>
        [CanBeNull]
        public string DeviceIdHash { get; }

        /// <summary>
        /// Values for all requested parameters if they are present.
        /// </summary>
        [NotNull]
        public IDictionary<string, StartupParamsItem> Parameters { get; }

        internal StartupParamsResult([NotNull] IDictionary<string, StartupParamsItem> parameters) {
            Parameters = parameters;
            Uuid = ParameterForKey(StartupParamsKey.AppMetricaUuid);
            DeviceId = ParameterForKey(StartupParamsKey.AppMetricaDeviceID);
            DeviceIdHash = ParameterForKey(StartupParamsKey.AppMetricaDeviceIDHash);
        }

        /// <summary>
        /// Get startup parameter value as <see cref="string"/> by <paramref name="key"/>.
        /// </summary>
        /// <param name="key">startup parameter key from identifiers param in <see cref="AppMetrica.RequestStartupParams"/> method.</param>
        /// <returns>startup parameter value for key or null if no such key in params.</returns>
        [CanBeNull]
        public string ParameterForKey([NotNull] string key) {
            return Parameters.TryGetValue(key, out var value) ? value.Id : null;
        }
    }

    /// <summary>
    /// Startup value with status and error description.
    /// </summary>
    public class StartupParamsItem {
        /// <summary>
        /// Startup value if it is present or null otherwise.
        /// </summary>
        [CanBeNull]
        public string Id { get; }

        /// <summary>
        /// Startup value error details.
        /// </summary>
        [CanBeNull]
        public string ErrorDetails { get; }

        /// <summary>
        /// Startup value status.
        /// </summary>
        public StartupParamsItemStatus Status { get; }

        internal StartupParamsItem([CanBeNull] string id, StartupParamsItemStatus status, [CanBeNull] string errorDetails) {
            Id = id;
            Status = status;
            ErrorDetails = errorDetails;
        }
    }

    /// <summary>
    /// Status of <see cref="StartupParamsItem"/>.
    /// </summary>
    public enum StartupParamsItemStatus {
        /// <summary>
        /// Value is present.
        /// </summary>
        Ok,

        /// <summary>
        /// Value is absent because feature is disabled.
        /// </summary>
        FeatureDisabled,

        /// <summary>
        /// Value is absent because it is invalid.
        /// </summary>
        InvalidValueFromProvider,

        /// <summary>
        /// Value is absent because some network error happened.
        /// </summary>
        NetworkError,

        /// <summary>
        /// Value is absent because provider is unavailable.
        /// </summary>
        ProviderUnavailable,

        /// <summary>
        /// Value is absent because some unknown error happened.
        /// </summary>
        UnknownError,
    }
}
