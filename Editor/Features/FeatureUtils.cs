using System;
using UnityEditor;

namespace Io.AppMetrica.Editor.Features {
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
    }
}
