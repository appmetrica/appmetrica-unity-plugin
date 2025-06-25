#if APPMETRICA_FEATURES_ADREVENUE_APPLOVIN_V8
using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

namespace Io.AppMetrica.Features.AdRevenue.AppLovin.V8 {
    internal static class AppLovinAdRevenueHandler {
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void Start() {
            MaxSdkCallbacks.AppOpen.OnAdRevenuePaidEvent += ReportAppLovinAdRevenue;
            MaxSdkCallbacks.Interstitial.OnAdRevenuePaidEvent += ReportAppLovinAdRevenue;
            MaxSdkCallbacks.Rewarded.OnAdRevenuePaidEvent += ReportAppLovinAdRevenue;
            MaxSdkCallbacks.Banner.OnAdRevenuePaidEvent += ReportAppLovinAdRevenue;
            MaxSdkCallbacks.MRec.OnAdRevenuePaidEvent += ReportAppLovinAdRevenue;
        }

        private static void ReportAppLovinAdRevenue(string adUnitId, MaxSdkBase.AdInfo adInfo) {
            if (adInfo == null) {
                return;
            }

            if (!AppMetrica.IsActivated()) {
                return;
            }

            var adType = ConvertAppLovinAdType(adInfo.AdFormat);
            var payload = new Dictionary<string, string> {
                { "countryCode", MaxSdk.GetSdkConfiguration().CountryCode },
                { "original_ad_type", adInfo.AdFormat },
                { "original_source", "unity-ad-revenue-applovin-v8" },
#if APPMETRICA_FEATURES_ADREVENUE_APPLOVIN_V8_AUTO_ENABLED
                { "auto_enabled_in_unity", "true" },
#endif                
            };

            AppMetrica.ReportAutoCollectedAdRevenue(new Io.AppMetrica.AdRevenue(adInfo.Revenue, "USD") {
                AdUnitId = adInfo.AdUnitIdentifier,
                AdType = adType,
                AdNetwork = adInfo.NetworkName,
                AdPlacementName = adInfo.Placement,
                AdPlacementId = adInfo.NetworkPlacement,
                Precision = adInfo.RevenuePrecision,
                Payload = payload
            });
        }

        private static AdType ConvertAppLovinAdType([CanBeNull] string adFormat) {
            switch (adFormat) {
                case "NATIVE":
                    return AdType.Native;
                case "BANNER":
                    return AdType.Banner;
                case "REWARDED":
                    return AdType.Rewarded;
                case "INTER":
                    return AdType.Interstitial;
                case "MREC":
                    return AdType.Mrec;
                default:
                    return AdType.Other;
            }
        }
    }
}
#endif
