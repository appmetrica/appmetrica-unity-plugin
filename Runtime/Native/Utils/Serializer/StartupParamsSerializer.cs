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
            foreach (var entry in parametersJson) {
                parameters[entry.Key] = ItemFromJson(entry.Value);
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
            switch (str) {
                case "OK":
                    return StartupParamsItemStatus.Ok;
                case "PROVIDER_UNAVAILABLE":
                    return StartupParamsItemStatus.ProviderUnavailable;
                case "INVALID_VALUE_FROM_PROVIDER":
                    return StartupParamsItemStatus.InvalidValueFromProvider;
                case "NETWORK_ERROR":
                    return StartupParamsItemStatus.NetworkError;
                case "FEATURE_DISABLED":
                    return StartupParamsItemStatus.FeatureDisabled;
                default:
                    return StartupParamsItemStatus.UnknownError;
            }
        }

        [CanBeNull]
        private static JObject Opt([NotNull] this JObject json, [NotNull] string key) {
            return json.ObjectValue.TryGetValue(key, out var value) ? value : null; 
        }
    }
}
