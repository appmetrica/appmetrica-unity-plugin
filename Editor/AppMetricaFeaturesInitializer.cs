using UnityEditor;

namespace Io.AppMetrica.Editor {
    internal class AppMetricaFeaturesInitializer : AssetPostprocessor {
        static void OnPostprocessAllAssets(string[] importedAssets, string[] deletedAssets, string[] movedAssets,
            string[] movedFromAssetPaths, bool didDomainReload) {
            if (!didDomainReload || !AppMetricaSettings.GetBool("AutoFeaturesDetection.Enabled", true)) return;
            foreach (var feature in AppMetricaResolver.SupportedFeatures.Values) {
                if (feature.IsAutoEnableable) {
                    feature.AutoEnableFeatureIfAvailable();
                }
            }

            AppMetricaResolver.OnSettingsChanged();
        }
    }
}
