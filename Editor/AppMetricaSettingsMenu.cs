using UnityEditor;
using UnityEngine;

namespace Io.AppMetrica.Editor {
    internal static class AppMetricaSettingsMenu {

        [MenuItem("Assets/AppMetrica/Documentation")]
        public static void OpenDocumentation() {
            Application.OpenURL("https://appmetrica.io/docs/en/sdk/unity/analytics/quick-start");
        }

        [MenuItem("Assets/AppMetrica/Settings")]
        public static void OpenSettings() {
            AppMetricaSettingsWindow.Run();
        }
    }
}
