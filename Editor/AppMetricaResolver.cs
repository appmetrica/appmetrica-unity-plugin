using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using GooglePlayServices;
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

        internal static readonly Dictionary<string, SupportedFeature> SupportedFeatures = new Dictionary<string, SupportedFeature>()
        {
            [SupportedFeatureNames.AppHudAdapter] = new SupportedFeature("APPMETRICA_APPHUD_ADAPTER_ENABLED", feature => {
                UpdateDependencyState("AppMetricaAppHudAdapterDependencies", feature.IsEnabled);
            }),
        };

        public static void OnSettingsChanged() {
            foreach (var feature in SupportedFeatures.Values) {
                feature.OnChangedAction(feature);
            }
            
            ApplyDefines();
            PlayServicesResolver.Resolve(forceResolution: true);
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
        }
        
        private static void UpdateDependencyState(string name, bool isEnabled) {
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
                
                var disabledDefines = SupportedFeatures.Values
                    .Where(feature => !feature.IsEnabled)
                    .Select(feature => feature.DefineName)
                    .ToArray();

                var newDefines = currentDefines
                    .Union(enabledDefines)
                    .Except(disabledDefines)
                    .ToArray();

                PlayerSettings.SetScriptingDefineSymbols(supportedTarget, newDefines);
                AssetDatabase.SaveAssets();
            }
        }
        
        private static void Log(string message) {
            Debug.Log($"{TAG}: {message}");
        }
        
        internal class SupportedFeature {
            internal readonly string DefineName;
            internal bool IsEnabled {
                get => AppMetricaSettings.GetBool(GetFeatureNameForSettings());
                set => AppMetricaSettings.SetBool(GetFeatureNameForSettings(), value);
            }

            internal readonly Action<SupportedFeature> OnChangedAction;

            public SupportedFeature(string defineName, Action<SupportedFeature> onChangedAction) {
                DefineName = defineName;
                OnChangedAction = onChangedAction;
            }
        
            public SupportedFeature(string defineName) : this(defineName, (_) => {}) {}

            private string GetFeatureNameForSettings() {
                return $"Feature.{SupportedFeatures.FirstOrDefault(x => x.Value == this).Key}.Enabled";
            }
        }
    }

    internal static class SupportedFeatureNames {
        internal const string AppHudAdapter = "AppHudAdapter";
    }
}
