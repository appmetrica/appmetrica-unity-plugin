#if APPMETRICA_FEATURES_ADREVENUE_IRONSOURCE_V9
using System.Collections.Generic;
using Unity.Services.LevelPlay;
using UnityEngine;

namespace Io.AppMetrica.Features.AdRevenue.IronSource.V9 {
    internal static class IronSourceAdRevenueHandler {
        
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void Start() {
            LevelPlay.OnImpressionDataReady += ReportIronSourceAdRevenue;
        }

        private static void ReportIronSourceAdRevenue(LevelPlayImpressionData impressionData) {
            if (impressionData == null) {
                return;
            }

            if (!AppMetrica.IsActivated()) {
                return;
            }

            var adType = ConvertIronSourceAdFormat(impressionData.AdFormat);
            
            var payload = new Dictionary<string, string> {
                { "countryCode", impressionData.Country },
                { "original_ad_type", impressionData.AdFormat },
                { "original_source", "unity-ad-revenue-ironsource-v9" },
#if APPMETRICA_FEATURES_ADREVENUE_IRONSOURCE_V9_AUTO_ENABLED
                { "auto_enabled_in_unity", "true" },
#endif
            };

            AppMetrica.ReportAutoCollectedAdRevenue(new Io.AppMetrica.AdRevenue(impressionData.Revenue ?? 0d, "USD") {
                AdUnitId = impressionData.MediationAdUnitId,
                AdUnitName = impressionData.MediationAdUnitName,
                AdType = adType,
                AdNetwork = impressionData.AdNetwork,
                AdPlacementName = impressionData.Placement,
                Precision = impressionData.Precision,
                Payload = payload
            });
        }

        private static AdType ConvertIronSourceAdFormat(string adFormat) {
            switch (adFormat.ToLowerInvariant()) {
                case "rewarded_video":
                    return AdType.Rewarded;
                case "interstitial":
                    return AdType.Interstitial;
                case "banner":
                    return AdType.Banner;
                default:
                    return AdType.Other;
            }
        }
    }
}
#endif
