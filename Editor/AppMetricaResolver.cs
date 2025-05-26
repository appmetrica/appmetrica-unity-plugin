using System.Collections.Generic;
using System.IO;
using System.Linq;
using GooglePlayServices;
using Io.AppMetrica.Editor.Features;
using UnityEditor;
using UnityEditor.Build;
using UnityEngine;

namespace Io.AppMetrica.Editor {
    internal static class AppMetricaResolver {

        private const string TAG = "AppMetricaResolver";

        private static readonly NamedBuildTarget[] SupportedBuildTargets = {
            NamedBuildTarget.iOS,
            NamedBuildTarget.Android,
        };

        internal static readonly Dictionary<string, Feature> SupportedFeatures = new Dictionary<string, Feature>
        {
            [SupportedFeatureNames.AppHudAdapter] = new AppHudAdapter("AppHudAdapter"),
            [SupportedFeatureNames.AppLovinAdRevenueV8] = new AppLovinAdRevenueV8("AppLovinAdRevenueV8"),
            [SupportedFeatureNames.IronSourceAdRevenueV8] = new IronSourceAdRevenueV8("IronSourceAdRevenueV8"),
            [SupportedFeatureNames.FyberAdRevenueV3] = new FyberAdRevenueV3("FyberAdRevenueV3"),
            [SupportedFeatureNames.TopOnAdRevenueV2] = new TopOnAdRevenueV2("TopOnAdRevenueV2"),
        };

        internal static void OnSettingsChanged() {
            foreach (var feature in SupportedFeatures.Values) {
                feature.OnChangedAction();
            }
            
            ApplyDefines();
            PlayServicesResolver.Resolve(forceResolution: true);
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
        }
        
        internal static void UpdateDependencyState(string name, bool isEnabled) {
            string[] assets = AssetDatabase.FindAssets(name);

            if (assets.Length == 0) {
                Log($"Cannot find dependency file with name - {name}");
                return;
            }

            if (assets.Length == 2 && isEnabled) {
                return;
            }

            string asset = assets[0];
            string path = AssetDatabase.GUIDToAssetPath(asset);
            
            string filePath = $"{Application.dataPath}/Editor/{name}.xml";
            if (isEnabled && !File.Exists(filePath)) {
                Directory.CreateDirectory(Path.GetDirectoryName(filePath));
                File.Copy(path, filePath);
            } else if (!isEnabled && File.Exists(filePath)) {
                File.Delete(filePath);
                File.Delete(filePath + ".meta");
            }
        }

        private static void ApplyDefines() {
            foreach (var supportedTarget in SupportedBuildTargets) {
                PlayerSettings.GetScriptingDefineSymbols(supportedTarget, out var currentDefines);
                var enabledDefines = SupportedFeatures.Values
                    .Where(feature => feature.IsEnabled)
                    .Select(feature => feature.DefineName)
                    .ToArray();

                var autoEnabledDefines = SupportedFeatures.Values
                    .Where(feature => feature.IsAutoEnabled)
                    .Select(feature => feature.AutoEnabledDefineName)
                    .ToArray();
                
                var disabledDefines = SupportedFeatures.Values
                    .Where(feature => !feature.IsEnabled)
                    .Select(feature => feature.DefineName)
                    .ToArray();
                
                var autoDisabledDefines = SupportedFeatures.Values
                    .Where(feature => !feature.IsAutoEnabled)
                    .Select(feature => feature.AutoEnabledDefineName)
                    .ToArray();

                var newDefines = currentDefines
                    .Union(enabledDefines)
                    .Union(autoEnabledDefines)
                    .Except(disabledDefines)
                    .Except(autoDisabledDefines)
                    .ToArray();

                PlayerSettings.SetScriptingDefineSymbols(supportedTarget, newDefines);
                AssetDatabase.SaveAssets();
            }
        }
        
        private static void Log(string message) {
            Debug.Log($"{TAG}: {message}");
        }
    }

    internal static class SupportedFeatureNames {
        internal const string AppHudAdapter = nameof(AppHudAdapter);
        internal const string AppLovinAdRevenueV8 = nameof(AppLovinAdRevenueV8);
        internal const string IronSourceAdRevenueV8 = nameof(IronSourceAdRevenueV8);
        internal const string FyberAdRevenueV3 = nameof(FyberAdRevenueV3);
        internal const string TopOnAdRevenueV2 = nameof(TopOnAdRevenueV2);
    }
}
