using Io.AppMetrica.Internal;
using JetBrains.Annotations;
using System.Collections.Generic;

namespace Io.AppMetrica.Native.Utils.Serializer {
    internal static class StartupParamsSerializer {
        [CanBeNull]
        public static StartupParamsResult ResultFromJsonString([CanBeNull] string jsonStr) {
            if (string.IsNullOrEmpty(jsonStr)) return null;
            var json = JSONDecoder.Decode(jsonStr);
            var parametersJson = json["parameters"].ObjectValue;
            var parameters = new Dictionary<string, StartupParamsItem>();
            foreach (var (key, value) in parametersJson) {
                parameters[key] = ItemFromJson(value);
            }
            return new StartupParamsResult(parameters);
        }

        [CanBeNull]
        public static StartupParamsErrorReason ErrorReasonFromJsonString([CanBeNull] string jsonStr) {
            if (string.IsNullOrEmpty(jsonStr)) return null;
            var json = JSONDecoder.Decode(jsonStr);
            return new StartupParamsErrorReason(json["value"].StringValue);
        }

        [NotNull]
        private static StartupParamsItem ItemFromJson([NotNull] JObject json) {
            return new StartupParamsItem(
                json.Opt("id")?.StringValue,
                StatusFromString(json.Opt("status")?.StringValue),
                json.Opt("errorDetails")?.StringValue
            );
        }

        private static StartupParamsItemStatus StatusFromString([CanBeNull] string str) {
            return str switch {
                "OK" => StartupParamsItemStatus.Ok,
                "PROVIDER_UNAVAILABLE" => StartupParamsItemStatus.ProviderUnavailable,
                "INVALID_VALUE_FROM_PROVIDER" => StartupParamsItemStatus.InvalidValueFromProvider,
                "NETWORK_ERROR" => StartupParamsItemStatus.NetworkError,
                "FEATURE_DISABLED" => StartupParamsItemStatus.FeatureDisabled,
                _ => StartupParamsItemStatus.UnknownError,
            };
        }

        [CanBeNull]
        private static JObject Opt([NotNull] this JObject json, [NotNull] string key) {
            return json.ObjectValue.GetValueOrDefault(key);
        }
    }
}
