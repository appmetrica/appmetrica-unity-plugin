using Io.AppMetrica.Internal;
using JetBrains.Annotations;
using System.Collections.Generic;

namespace Io.AppMetrica {
    /// <summary>
    /// Class to create <see cref="ExternalAttribution"/> object.
    /// </summary>
    /// <seealso cref="AppMetrica.ReportExternalAttribution"/>
    public static class ExternalAttributions {
        /// <summary>
        /// Create an object of <see cref="ExternalAttribution"/> class with AppsFlyer attribution.
        /// </summary>
        /// <param name="value">data from AppsFlyer library.</param>
        /// <returns><see cref="ExternalAttribution"/> object with AppsFlyer attribution.</returns>
        [NotNull]
        public static ExternalAttribution AppsFlyer([CanBeNull] string value) {
            return new ExternalAttribution("AppsFlyer", value);
        }

        /// <summary>
        /// Create an object of <see cref="ExternalAttribution"/> class with Adjust attribution.
        /// </summary>
        /// <param name="value">data from Adjust library.</param>
        /// <returns><see cref="ExternalAttribution"/> object with Adjust attribution.</returns>
        [NotNull]
        public static ExternalAttribution Adjust([CanBeNull] object value) {
            return new ExternalAttribution("Adjust", ObjectToJsonString(value));
        }

        /// <summary>
        /// Create an object of <see cref="ExternalAttribution"/> class with Kochava attribution.
        /// </summary>
        /// <param name="value">data from Kochava library.</param>
        /// <returns><see cref="ExternalAttribution"/> object with Kochava attribution.</returns>
        [NotNull]
        public static ExternalAttribution Kochava([CanBeNull] string value) {
            return new ExternalAttribution("Kochava", value);
        }

        /// <summary>
        /// Create an object of <see cref="ExternalAttribution"/> class with Tenjin attribution.
        /// </summary>
        /// <param name="value">data from Tenjin library.</param>
        /// <returns><see cref="ExternalAttribution"/> object with Tenjin attribution.</returns>
        [NotNull]
        public static ExternalAttribution Tenjin([CanBeNull] Dictionary<string, string> value) {
            return new ExternalAttribution("Tenjin", JSONEncoder.Encode(value));
        }

        /// <summary>
        /// Create an object of <see cref="ExternalAttribution"/> class with Airbridge attribution.
        /// </summary>
        /// <param name="value">data from Airbridge library.</param>
        /// <returns><see cref="ExternalAttribution"/> object with Airbridge attribution.</returns>
        [NotNull]
        public static ExternalAttribution Airbridge([CanBeNull] string value) {
            return new ExternalAttribution("Airbridge", value);
        }

        /// <summary>
        /// Create an object of <see cref="ExternalAttribution"/> class with Singular attribution.
        /// </summary>
        /// <param name="value">data from Singular library.</param>
        /// <returns><see cref="ExternalAttribution"/> object with Singular attribution.</returns>
        [NotNull]
        public static ExternalAttribution Singular([CanBeNull] Dictionary<string, object> value) {
            return new ExternalAttribution("Singular", JSONEncoder.Encode(value));
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

    /// <summary>
    /// External attribution object.
    /// To create this class use the methods from <see cref="ExternalAttributions"/> class.
    /// </summary>
    /// <seealso cref="AppMetrica.ReportExternalAttribution"/>
    public class ExternalAttribution {
        /// <summary>
        /// The source of the attribution data.
        /// Possible values: AppsFlyer, Adjust, Kochava, Tenjin, Airbridge.
        /// </summary>
        [NotNull]
        public string Source { get; }

        /// <summary>
        /// The json-string containing the attribution data.
        /// </summary>
        [CanBeNull]
        public string Value { get; }

        internal ExternalAttribution([NotNull] string source, [CanBeNull] string value) {
            Source = source;
            Value = value;
        }
    }
}
