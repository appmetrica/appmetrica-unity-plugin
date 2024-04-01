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
            return self switch {
                AdType.Banner => "Banner",
                AdType.Interstitial => "Interstitial",
                AdType.Mrec => "Mrec",
                AdType.Native => "Native",
                AdType.Other => "Other",
                AdType.Rewarded => "Rewarded",
                _ => null,
            };
        }
    }
}
