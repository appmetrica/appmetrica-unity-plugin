using JetBrains.Annotations;
using System.Collections.Generic;

namespace Io.AppMetrica {
    public static class StartupParams {
        public const string AppmetricaUuid = "appmetrica_uuid";
        public const string AppmetricaDeviceID = "appmetrica_device_id";
        public const string AppmetricaDeviceIDHash = "appmetrica_device_id_hash";

        public delegate void Delegate([CanBeNull] Result result, [CanBeNull] ErrorReason errorReason);

        public class ErrorReason {
            [NotNull]
            public string Value { get; }

            internal ErrorReason([NotNull] string value) {
                Value = value;
            }
        }

        public class Result {
            [CanBeNull]
            public string DeviceId { get; }

            [CanBeNull]
            public string DeviceIdHash { get; }

            [NotNull]
            public IDictionary<string, StartupParamsItem> Parameters { get; }

            [CanBeNull]
            public string Uuid { get; }

            internal Result([NotNull] IDictionary<string, StartupParamsItem> parameters) {
                Parameters = parameters;
                DeviceId = ParameterForKey(AppmetricaDeviceID);
                DeviceIdHash = ParameterForKey(AppmetricaDeviceIDHash);
                Uuid = ParameterForKey(AppmetricaUuid);
            }

            [CanBeNull]
            public string ParameterForKey([NotNull] string key) {
                return Parameters.TryGetValue(key, out var value) ? value.Id : null;
            }
        }
    }
}
