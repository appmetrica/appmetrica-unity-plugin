using System.Collections.Generic;
using Io.AppMetrica.Internal;
using JetBrains.Annotations;

namespace Io.AppMetrica.Native.Utils.Serializer {
    internal static class AdRevenueSerializer {
        [NotNull]
        public static string ToJsonString([NotNull] this AdRevenue self) {
            return JSONEncoder.Encode(new Dictionary<string, object> {
                { "AdNetwork", self.AdNetwork },
                { "AdPlacementId", self.AdPlacementId },
                { "AdPlacementName", self.AdPlacementName },
                { "AdRevenue", self.AdRevenueValue },
                { "AdType", self.AdType?.ToStringValue() },
                { "AdUnitId", self.AdUnitId },
                { "AdUnitName", self.AdUnitName },
                { "Currency", self.Currency },
                { "Payload", self.Payload },
                { "Precision", self.Precision },
            });
        }

        [CanBeNull]
        private static string ToStringValue(this AdType self) {
            switch (self) {
                case AdType.Banner:
                    return "Banner";
                case AdType.Interstitial:
                    return "Interstitial";
                case AdType.Mrec:
                    return "Mrec";
                case AdType.Native:
                    return "Native";
                case AdType.Other:
                    return "Other";
                case AdType.Rewarded:
                    return "Rewarded";
                default:
                    return null;
            }
        }
    }
}
