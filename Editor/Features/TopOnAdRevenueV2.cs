using System;
using System.IO;
using System.Linq;
using Io.AppMetrica.Editor.Features.Utils;
using UnityEngine;

namespace Io.AppMetrica.Editor.Features {
    internal class TopOnAdRevenueV2 : Feature {
        public TopOnAdRevenueV2(string featureName) : base(featureName) {}

        internal override string DefineName => "APPMETRICA_FEATURES_ADREVENUE_TOPON_V2";

        internal override bool IsAutoEnableable => true;

        internal override void OnChangedAction() {

            var tpnPluginAssembly = AppDomain.CurrentDomain
                .GetAssemblies()
                .FirstOrDefault(assembly => assembly.GetName().Name == "TpnPlugin.AnyThinkAds");
            
            string filePath = $"{Application.dataPath}/TpnPlugin/AnyThinkAds/AppMetrica.TpnPlugin.asmdef";

            if (!File.Exists(filePath) && tpnPluginAssembly != null) {
                return; // do nothing if TpnPlugin assembly is already added by TopOn
            }

            if (IsEnabled && !File.Exists(filePath)) {
                Directory.CreateDirectory(Path.GetDirectoryName(filePath));
                File.WriteAllText(filePath, "{\n  \"name\": \"TpnPlugin.AnyThinkAds\",\n  \"autoReferenced\": true\n}\n");
            } else if (!IsEnabled && File.Exists(filePath)) {
                File.Delete(filePath);
            }
        }

        internal override void AutoEnableFeatureIfAvailable() {
            if (FeatureUtils.IsAssetInProject("ATSDKAPI")) {
                AutoEnableFeatureIfNeeded();
            }
        }
    }
}
