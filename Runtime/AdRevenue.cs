using Io.AppMetrica.Internal;
using JetBrains.Annotations;
using System.Collections.Generic;

namespace Io.AppMetrica {
    /// <summary>
    /// The class to store Ad Revenue data.
    /// <p>The Ad Revenue object should be passed to the AppMetrica by using
    /// the <see cref="AppMetrica.ReportAdRevenue">AppMetrica.ReportAdRevenue()</see>
    /// or <see cref="IReporter.ReportAdRevenue">IReporter.ReportAdRevenue()</see> methods.</p>
    /// </summary>
    public class AdRevenue {
        /// <summary>
        /// Amount of money received via ad string.
        /// It cannot be negative.
        ///
        /// <p><b>Platforms</b>: Android, iOS.</p>
        /// </summary>
        public string AdRevenueValue { get; }

        /// <summary>
        /// Currency in which money from <see cref="AdRevenueValue"/> is represented.
        ///
        /// <p><b>Platforms</b>: Android, iOS.</p>
        /// </summary>
        [NotNull]
        public string Currency { get; }

        /// <summary>
        /// Ad network.
        /// Maximum length is 100 symbols.
        /// If the value exceeds this limit it will be truncated by AppMetrica.
        ///
        /// <p><b>Platforms</b>: Android, iOS.</p>
        /// </summary>
        [CanBeNull]
        public string AdNetwork { get; set; }

        /// <summary>
        /// Id of ad placement.
        /// Maximum length is 100 symbols.
        /// If the value exceeds this limit it will be truncated by AppMetrica.
        ///
        /// <p><b>Platforms</b>: Android, iOS.</p>
        /// </summary>
        [CanBeNull]
        public string AdPlacementId { get; set; }

        /// <summary>
        /// Name of ad placement.
        /// Maximum length is 100 symbols.
        /// If the value exceeds this limit it will be truncated by AppMetrica.
        ///
        /// <p><b>Platforms</b>: Android, iOS.</p>
        /// </summary>
        [CanBeNull]
        public string AdPlacementName { get; set; }

        /// <summary>
        /// Ad type. See possible values in <see cref="Io.AppMetrica.AdType"/>.
        ///
        /// <p><b>Platforms</b>: Android, iOS.</p>
        /// </summary>
        [CanBeNull]
        public AdType? AdType { get; set; }

        /// <summary>
        /// Id of ad unit.
        /// Maximum length is 100 symbols.
        /// If the value exceeds this limit it will be truncated by AppMetrica.
        ///
        /// <p><b>Platforms</b>: Android, iOS.</p>
        /// </summary>
        [CanBeNull]
        public string AdUnitId { get; set; }

        /// <summary>
        /// Name of ad unit.
        /// Maximum length is 100 symbols.
        /// If the value exceeds this limit it will be truncated by AppMetrica.
        ///
        /// <p><b>Platforms</b>: Android, iOS.</p>
        /// </summary>
        [CanBeNull]
        public string AdUnitName { get; set; }

        /// <summary>
        /// Arbitrary payload: additional info represented as key-value pairs.
        /// Maximum size is 30 KB.
        /// If the value exceeds this limit it will be truncated by AppMetrica.
        ///
        /// <p><b>Platforms</b>: Android, iOS.</p>
        /// </summary>
        [CanBeNull]
        public IDictionary<string, string> Payload { get; set; }

        /// <summary>
        /// Precision.
        /// Example: "publisher_defined", "estimated".
        /// Maximum length is 100 symbols.
        /// If the value exceeds this limit it will be truncated by AppMetrica.
        ///
        /// <p><b>Platforms</b>: Android, iOS.</p>
        /// </summary>
        [CanBeNull]
        public string Precision { get; set; }

        /// <summary>
        /// Creates a AdRevenue.
        /// </summary>
        /// <param name="adRevenue">Amount of money received via ad revenue.</param>
        /// <param name="currency">Currency.</param>
        public AdRevenue(decimal adRevenue, [NotNull] string currency) {
            AdRevenueValue = NumberUtils.SerializeDecimal(adRevenue);
            Currency = currency;
        }

        /// <summary>
        /// Creates a AdRevenue.
        /// </summary>
        /// <param name="adRevenueMicros">Amount of money received via ad revenue represented
        ///                               as micros (actual value multiplied by 10^6).</param>
        /// <param name="currency">Currency.</param>
        public AdRevenue(long adRevenueMicros, [NotNull] string currency) {
            AdRevenueValue = NumberUtils.SerializeMicros(adRevenueMicros);
            Currency = currency;
        }

        /// <summary>
        /// Creates a AdRevenue.
        /// </summary>
        /// <param name="adRevenue">Amount of money received via ad revenue represented as double.</param>
        /// <param name="currency">Currency.</param>
        public AdRevenue(double adRevenue, [NotNull] string currency) {
            AdRevenueValue = NumberUtils.SerializeDouble(adRevenue);
            Currency = currency;
        }
    }

    /// <summary>
    /// Enum containing possible Ad Type values.
    /// </summary>
    /// <seealso cref="AdRevenue.AdType"/>
    public enum AdType {
        /// <summary>
        /// Banner Ad Type.
        /// </summary>
        Banner,

        /// <summary>
        /// Interstitial Ad Type.
        /// </summary>
        Interstitial,

        /// <summary>
        /// Mrec Ad Type.
        /// </summary>
        Mrec,

        /// <summary>
        /// Native Ad Type.
        /// </summary>
        Native,

        /// <summary>
        /// Rewarded Ad Type.
        /// </summary>
        Rewarded,

        /// <summary>
        /// Other Ad Type.
        /// </summary>
        Other,
    }
}
