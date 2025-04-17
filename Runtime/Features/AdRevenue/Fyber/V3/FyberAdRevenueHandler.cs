#if APPMETRICA_FEATURES_ADREVENUE_FYBER_V3
using System;
using System.Collections.Generic;
using Fyber;
using UnityEngine;

namespace Io.AppMetrica.Features.AdRevenue.Fyber.V3 {   
    internal static class FyberAdRevenueHandler {
        
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void Start() {
            Banner.SetBannerListener(new FyberBannerListener(ReportFyberAdRevenue));
            Interstitial.SetInterstitialListener(new FyberInterstitialListener(ReportFyberAdRevenue));
            Rewarded.SetRewardedListener(new FyberRewardedListener(ReportFyberAdRevenue));
        }

        private static void ReportFyberAdRevenue(AdType adType, ImpressionData impressionData) {
            if (impressionData == null) {
                return;
            }

            if (!AppMetrica.IsActivated()) {
                return;
            }
            
            var payload = new Dictionary<string, string> {
                { "countryCode", impressionData.countryCode },
                { "advertiserDomain", impressionData.advertiserDomain },
                { "campaignId", impressionData.campaignId },
                { "creativeId", impressionData.creativeId },
                { "impressionDepth", impressionData.impressionDepth.ToString() },
                { "impressionId", impressionData.impressionId },
                { "renderingSDK", impressionData.renderingSDK },
                { "renderingSDKVersion", impressionData.renderingSDKVersion },
                { "variantId", impressionData.variantId },
                { "original_ad_type", adType.ToString() },
                { "original_source", "unity-ad-revenue-fyber-v3" },
#if APPMETRICA_FEATURES_ADREVENUE_FYBER_V3_AUTO_ENABLED
                { "auto_enabled_in_unity", "true" },
#endif 
            };

            AppMetrica.ReportAutoCollectedAdRevenue(new Io.AppMetrica.AdRevenue(impressionData.netPayout, impressionData.currency) {
                AdType = adType,
                AdNetwork = impressionData.demandSource,
                AdPlacementId = impressionData.networkInstanceId,
                Precision = impressionData.priceAccuracy.ToString(),
                Payload = payload
            });
        }
        
    }
    
    internal class FyberBannerListener : BannerListener {
        private readonly Action<AdType, ImpressionData> _action;

        public FyberBannerListener(Action<AdType,ImpressionData> action) {
            _action = action;
        }

        public void OnError(string placementId, string error) {}

        public void OnLoad(string placementId) {}

        public void OnShow(string placementId, ImpressionData impressionData) {
            _action(AdType.Banner, impressionData);
        }

        public void OnClick(string placementId) {}

        public void OnRequestStart(string placementId, string requestId) {}
    }

    internal class FyberInterstitialListener : InterstitialListener {
        private readonly Action<AdType, ImpressionData> _action;

        public FyberInterstitialListener(Action<AdType, ImpressionData> action) {
            _action = action;
        }
        
        public void OnShow(string placementId, ImpressionData impressionData) {
            _action(AdType.Interstitial, impressionData);
        }

        public void OnClick(string placementId) {}

        public void OnHide(string placementId) {}

        public void OnShowFailure(string placementId, ImpressionData impressionData) {}

        public void OnAvailable(string placementId) {}

        public void OnUnavailable(string placementId) {}

        public void OnRequestStart(string placementId, string requestId) {}
    }
    
    internal class FyberRewardedListener : RewardedListener {
        private readonly Action<AdType, ImpressionData> _action;

        public FyberRewardedListener(Action<AdType, ImpressionData> action) {
            _action = action;
        }

        public void OnShow(string placementId, ImpressionData impressionData) {
            _action(AdType.Rewarded, impressionData);
        }

        public void OnClick(string placementId) {}

        public void OnHide(string placementId) {}

        public void OnShowFailure(string placementId, ImpressionData impressionData) {}

        public void OnAvailable(string placementId) {}

        public void OnUnavailable(string placementId) {}

        public void OnCompletion(string placementId, bool userRewarded) {}

        public void OnRequestStart(string placementId, string requestId) {}
    }
}
#endif
