using Io.AppMetrica.Internal;
using JetBrains.Annotations;
using System.Collections.Generic;

namespace Io.AppMetrica {
    public class ExternalAttribution {
        [NotNull]
        public string Source { get; }

        [CanBeNull]
        public string Value { get; }

        internal ExternalAttribution([NotNull] string source, [CanBeNull] string value) {
            Source = source;
            Value = value;
        }
    }

    public static class ExternalAttributions {
        [NotNull]
        public static ExternalAttribution AppsFlyer([CanBeNull] string value) {
            return new ExternalAttribution("AppsFlyer", value);
        }

        [NotNull]
        public static ExternalAttribution Adjust([CanBeNull] object value) {
            return new ExternalAttribution("Adjust", ObjectToJsonString(value));
        }

        [NotNull]
        public static ExternalAttribution Kochava([CanBeNull] string value) {
            return new ExternalAttribution("Kochava", value);
        }

        [NotNull]
        public static ExternalAttribution Tenjin([CanBeNull] Dictionary<string, string> value) {
            return new ExternalAttribution("Tenjin", JSONEncoder.Encode(value));
        }

        [NotNull]
        public static ExternalAttribution Airbridge([CanBeNull] string value) {
            return new ExternalAttribution("Airbridge", value);
        }

        [CanBeNull]
        private static string ObjectToJsonString([CanBeNull] object value) {
            if (value == null) return null;
            
            var dict = new Dictionary<string, object>();
            foreach (var propertyInfo in value.GetType().GetProperties()) {
                dict[propertyInfo.Name] = propertyInfo.GetValue(value);
            }
            return JSONEncoder.Encode(dict);
        }
    }
}
