using System;
using UnityEditor;
using UnityEngine;

namespace Io.AppMetrica.Editor {
    internal class AppMetricaSettingsWindow : EditorWindow {

        private Settings _settings;
        private const string SettingsTitle = "AppMetrica Settings";

        public static void Run() {
            var window = Application.isBatchMode
                ? CreateInstance<AppMetricaSettingsWindow>()
                : (AppMetricaSettingsWindow)GetWindow(typeof(AppMetricaSettingsWindow), true, SettingsTitle, true);
            window.titleContent.text = SettingsTitle;
            window.Show();
        }

        public void OnEnable() {
            LoadSettings();
        }

        public new void Repaint() {
            if (Application.isBatchMode) return;
            base.Repaint();
        }
        
        private void LoadSettings() => _settings = new Settings();

        private void OnGUI() {
            EditorGUILayout.BeginVertical();
            HorizontalLayout(() => {  
                GUILayout.Label("Enable AppHud integration", EditorStyles.boldLabel);
                _settings.IsAppHudEnabled = EditorGUILayout.Toggle(_settings.IsAppHudEnabled);
            });
            EditorGUILayout.EndVertical();
            HorizontalLayout(() => {
                if (GUILayout.Button("Apply")) Save();
            });
        }

        private void Save() {
            _settings.Save();
        }

        private static void HorizontalLayout(Action innerLayout) {
            GUILayout.BeginHorizontal();
            innerLayout();
            GUILayout.EndHorizontal();
        }

        private class Settings {
            internal bool IsAppHudEnabled;

            internal Settings() {
                IsAppHudEnabled = AppMetricaResolver.SupportedFeatures[SupportedFeatureNames.AppHudAdapter].IsEnabled;
            }

            internal void Save() {
                try {
                    AppMetricaSettings.DisableWatcher();
                    AppMetricaResolver.SupportedFeatures[SupportedFeatureNames.AppHudAdapter].IsEnabled =
                        IsAppHudEnabled;
                    AppMetricaResolver.OnSettingsChanged();
                } finally {
                    AppMetricaSettings.EnableWatcher();
                } 
            }
        }
    }


}
