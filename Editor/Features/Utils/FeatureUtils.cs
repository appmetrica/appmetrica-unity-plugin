using System;
using System.Collections.Generic;
using UnityEditor;

namespace Io.AppMetrica.Editor.Features.Utils {
    internal static class FeatureUtils {

        internal static bool IsAssetInProject(string assetName) {
            try {
                var assets = AssetDatabase.FindAssets(assetName);
                if (assets.Length != 0) {
                    return true;
                }
            } catch (Exception) {
                return false;
            }

            return false;
        }

        public static string GetAdRevenueSources() {
            var adRevenueSources = new List<string>();

#if APPMETRICA_FEATURES_ADREVENUE_FYBER_V3
            adRevenueSources.Add("fyber");
#endif
            
#if APPMETRICA_FEATURES_ADREVENUE_APPLOVIN_V8
            adRevenueSources.Add("applovin");
#endif
            
#if APPMETRICA_FEATURES_ADREVENUE_TOPON_V2
            adRevenueSources.Add("topon");
#endif
            
#if APPMETRICA_FEATURES_ADREVENUE_IRONSOURCE_V8
            adRevenueSources.Add("ironsource");
#endif

            return JSONEncoder.Encode(adRevenueSources);
        }
    }
}
