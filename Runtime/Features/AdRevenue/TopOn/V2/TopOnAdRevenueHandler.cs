#if APPMETRICA_FEATURES_ADREVENUE_TOPON_V2
using System;
using System.Collections.Generic;
using AnyThinkAds.Api;
using JetBrains.Annotations;
using UnityEngine;

namespace Io.AppMetrica.Features.AdRevenue.TopOn.V2 {
    internal static class TopOnAdRevenueHandler {
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void Start() {
            ATRewardedAutoVideo.Instance.client.onRewardEvent += OnAdReward;
            ATInterstitialAutoAd.Instance.client.onAdVideoEndEvent += OnAdReward;
            ATBannerAd.Instance.client.onAdImpressEvent += OnAdReward;
            ATNativeAd.Instance.client.onAdImpressEvent += OnAdReward;
            ATSplashAd.Instance.client.onAdCloseEvent += OnAdReward;
        }

        private static void OnAdReward(object sender, ATAdEventArgs adEvent) {
            if (adEvent?.callbackInfo == null) {
                return;
            }

            if (!AppMetrica.IsActivated()) {
                return;
            }

            var adType = ConvertTopOnAdType(adEvent.callbackInfo.adunit_format);
            var payload = new Dictionary<string, string> {
                { "countryCode", adEvent.callbackInfo.country },
                { "original_ad_type", adEvent.callbackInfo.adunit_format },
                { "original_source", "unity-ad-revenue-topon-v2" },
#if APPMETRICA_FEATURES_ADREVENUE_TOPON_V2_AUTO_ENABLED
                { "auto_enabled_in_unity", "true" },
#endif
            };

            AppMetrica.ReportAutoCollectedAdRevenue(new Io.AppMetrica.AdRevenue(
                adEvent.callbackInfo.publisher_revenue,
                adEvent.callbackInfo.currency
            ) {
                AdUnitId = adEvent.callbackInfo.adunit_id,
                AdType = adType,
                AdNetwork = adEvent.callbackInfo.network_name,
                AdPlacementName = adEvent.callbackInfo.network_placement_id,
                Precision = adEvent.callbackInfo.precision,
                Payload = payload
            });
        }

        private static AdType ConvertTopOnAdType([CanBeNull] string adUnitFormat) {
            switch (adUnitFormat) {
                case "Native":
                    return AdType.Native;
                case "Banner":
                    return AdType.Banner;
                case "RewardedVideo":
                    return AdType.Rewarded;
                case "Interstitial":
                    return AdType.Interstitial;
                default:
                    return AdType.Other;
            }
        }
    }
}
#endif
