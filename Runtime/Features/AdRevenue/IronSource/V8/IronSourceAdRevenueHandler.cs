#if APPMETRICA_FEATURES_ADREVENUE_IRONSOURCE_V8
using System.Collections.Generic;
using UnityEngine;

namespace Io.AppMetrica.Features.AdRevenue.IronSource.V8 {	
    internal static class IronSourceAdRevenueHandler {
        
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void Start() {
            IronSourceRewardedVideoEvents.onAdRewardedEvent += OnIronSourceRewarded;
            IronSourceInterstitialEvents.onAdShowSucceededEvent += OnIronSourceInterstitial;
            IronSourceBannerEvents.onAdScreenPresentedEvent += OnIronSourceBanner;
        }

        private static void OnIronSourceRewarded(IronSourcePlacement placement, IronSourceAdInfo adInfo) {
            ReportIronSourceAdRevenue(AdType.Rewarded, adInfo, placement);
        }

        private static void OnIronSourceInterstitial(IronSourceAdInfo adInfo) {
            ReportIronSourceAdRevenue(AdType.Interstitial, adInfo);
        }

        private static void OnIronSourceBanner(IronSourceAdInfo adInfo) {
            ReportIronSourceAdRevenue(AdType.Banner, adInfo);
        }

        private static void ReportIronSourceAdRevenue(AdType adType, IronSourceAdInfo adInfo, IronSourcePlacement placement = null) {
            if (adInfo == null) {
                return;
            }

            if (!AppMetrica.IsActivated()) {
                return;
            }
            
            var payload = new Dictionary<string, string> {
                { "countryCode", adInfo.country },
                { "original_ad_type", adType.ToString() },
                { "original_source", "unity-ad-revenue-ironsource-v8" },
#if APPMETRICA_FEATURES_ADREVENUE_IRONSOURCE_V8_AUTO_ENABLED
                { "auto_enabled_in_unity", "true" },
#endif
            };

            AppMetrica.ReportAutoCollectedAdRevenue(new Io.AppMetrica.AdRevenue(adInfo.revenue ?? 0d, "USD") {
                AdUnitId = adInfo.adUnit,
                AdType = adType,
                AdNetwork = adInfo.adNetwork,
                AdPlacementName = placement?.getPlacementName(),
                Precision = adInfo.precision,
                Payload = payload
            });
        }
    }
}
#endif
