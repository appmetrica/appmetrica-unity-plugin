#if UNITY_IPHONE || UNITY_IOS
using System.IO;
using Io.AppMetrica.Editor.Features.Utils;
using UnityEditor.Build;
using UnityEditor.Build.Reporting;
using UnityEditor.iOS.Xcode;

namespace Io.AppMetrica.Editor {
    internal class IosPostProcessBuild : IPostprocessBuildWithReport {
        
        public int callbackOrder => 0;

        public void OnPostprocessBuild(BuildReport report) {

            var plistPath = Path.Combine(report.summary.outputPath, "Info.plist");
            var plist = new PlistDocument();
            plist.ReadFromFile(plistPath);

            var rootDict = plist.root;
            rootDict.SetString("io.appmetrica.analytics.plugin_supported_ad_revenue_sources",
                FeatureUtils.GetAdRevenueSources());
            File.WriteAllText(plistPath, plist.WriteToString());
        }
    }
}
#endif
