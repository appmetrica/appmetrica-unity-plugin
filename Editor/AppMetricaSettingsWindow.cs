using System;
using UnityEditor;
using UnityEngine;

namespace Io.AppMetrica.Editor {
    internal class AppMetricaSettingsWindow : EditorWindow {

        private Settings _settings;
        private GUIStyle _titleLabelStyle;
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

        public void Awake() {
            _titleLabelStyle = new GUIStyle(EditorStyles.label) {
                fontSize = 14,
                fontStyle = FontStyle.Bold,
                fixedHeight = 20
            };
        }

        public new void Repaint() {
            if (Application.isBatchMode) return;
            base.Repaint();
        }
        
        private void LoadSettings() => _settings = new Settings();

        private void OnGUI() {
                
            EditorGUILayout.BeginVertical();
            GUILayout.Space(10);
            
            EditorGUILayout.LabelField("Settings", _titleLabelStyle);;
            using (new EditorGUILayout.VerticalScope("box")) {
                HorizontalLayout(() => {  
                    GUILayout.Label("Enable AppHud integration", GUILayout.Width(300));
                    _settings.IsAppHudEnabled = EditorGUILayout.Toggle(_settings.IsAppHudEnabled);
                });
                GUILayout.Space(5);
                HorizontalLayout(() => {
                    GUILayout.Label("Enable Auto Detection Of Features", GUILayout.Width(300));
                    _settings.IsAutoFeaturesDetectionEnabled = EditorGUILayout.Toggle(_settings.IsAutoFeaturesDetectionEnabled);
                });
            }
            
            GUILayout.Space(10);
            EditorGUILayout.LabelField("AdRevenue AutoCollection Networks", _titleLabelStyle);
            using (new EditorGUILayout.VerticalScope("box")) {
                
                _settings.IsAppLovinAdRevenueV8Enabled = AutoEnabledToggle("AppLovin", _settings.IsAppLovinAdRevenueV8Enabled, _settings.IsAppLovinAdRevenueV8AutoEnabled);
                GUILayout.Space(5);
                
                _settings.IsIronSourceAdRevenueV8Enabled = AutoEnabledToggle("IronSource", _settings.IsIronSourceAdRevenueV8Enabled, _settings.IsIronSourceAdRevenueV8AutoEnabled);
                GUILayout.Space(5);
                
                _settings.IsFyberAdRevenueV3Enabled = AutoEnabledToggle("Fyber", _settings.IsFyberAdRevenueV3Enabled, _settings.IsFyberAdRevenueV3AutoEnabled);
                GUILayout.Space(5);
                
                _settings.IsTopOnAdRevenueV2Enabled = AutoEnabledToggle("TopOn", _settings.IsTopOnAdRevenueV2Enabled, _settings.IsTopOnAdRevenueV2AutoEnabled);
            }

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
        
        private static bool AutoEnabledToggle(string name, bool isEnabled, bool isAutoEnabled) {
            var newValue = isEnabled;
            HorizontalLayout(() => {
                GUILayout.Label("Enable " + name, GUILayout.Width(300));
                newValue = EditorGUILayout.Toggle(isEnabled);
            });
            if (isAutoEnabled) {
                EditorGUILayout.HelpBox(name + " network was auto enabled. You can turn this off", MessageType.None);
            }
            return newValue;
        }

        private class Settings {
            internal bool IsAppHudEnabled;
            internal bool IsAppLovinAdRevenueV8Enabled;
            internal bool IsAppLovinAdRevenueV8AutoEnabled;
            internal bool IsIronSourceAdRevenueV8Enabled;
            internal bool IsIronSourceAdRevenueV8AutoEnabled;
            internal bool IsFyberAdRevenueV3Enabled;
            internal bool IsFyberAdRevenueV3AutoEnabled;
            internal bool IsTopOnAdRevenueV2Enabled;
            internal bool IsTopOnAdRevenueV2AutoEnabled;
            internal bool IsAutoFeaturesDetectionEnabled;

            internal Settings() {
                IsAppHudEnabled = AppMetricaResolver.SupportedFeatures[SupportedFeatureNames.AppHudAdapter].IsEnabled;
                IsAppLovinAdRevenueV8Enabled = AppMetricaResolver.SupportedFeatures[SupportedFeatureNames.AppLovinAdRevenueV8].IsEnabled;
                IsAppLovinAdRevenueV8AutoEnabled = AppMetricaResolver.SupportedFeatures[SupportedFeatureNames.AppLovinAdRevenueV8].IsAutoEnabled;
                IsIronSourceAdRevenueV8Enabled = AppMetricaResolver.SupportedFeatures[SupportedFeatureNames.IronSourceAdRevenueV8].IsEnabled;
                IsIronSourceAdRevenueV8AutoEnabled = AppMetricaResolver.SupportedFeatures[SupportedFeatureNames.IronSourceAdRevenueV8].IsAutoEnabled;
                IsFyberAdRevenueV3Enabled = AppMetricaResolver.SupportedFeatures[SupportedFeatureNames.FyberAdRevenueV3].IsEnabled;
                IsFyberAdRevenueV3AutoEnabled = AppMetricaResolver.SupportedFeatures[SupportedFeatureNames.FyberAdRevenueV3].IsAutoEnabled;
                IsTopOnAdRevenueV2Enabled = AppMetricaResolver.SupportedFeatures[SupportedFeatureNames.TopOnAdRevenueV2].IsEnabled;
                IsTopOnAdRevenueV2AutoEnabled = AppMetricaResolver.SupportedFeatures[SupportedFeatureNames.TopOnAdRevenueV2].IsAutoEnabled;
                IsAutoFeaturesDetectionEnabled = AppMetricaSettings.GetBool("AutoFeaturesDetection.Enabled", true);
            }

            internal void Save() {
                try {
                    AppMetricaSettings.DisableWatcher();
                    AppMetricaResolver.SupportedFeatures[SupportedFeatureNames.AppHudAdapter].IsManualEnabled = IsAppHudEnabled;
                    AppMetricaResolver.SupportedFeatures[SupportedFeatureNames.AppLovinAdRevenueV8].IsManualEnabled = IsAppLovinAdRevenueV8Enabled;
                    AppMetricaResolver.SupportedFeatures[SupportedFeatureNames.IronSourceAdRevenueV8].IsManualEnabled = IsIronSourceAdRevenueV8Enabled;
                    AppMetricaResolver.SupportedFeatures[SupportedFeatureNames.FyberAdRevenueV3].IsManualEnabled = IsFyberAdRevenueV3Enabled;
                    AppMetricaResolver.SupportedFeatures[SupportedFeatureNames.TopOnAdRevenueV2].IsManualEnabled = IsTopOnAdRevenueV2Enabled;
                    AppMetricaSettings.SetBool("AutoFeaturesDetection.Enabled", IsAutoFeaturesDetectionEnabled);
                    AppMetricaResolver.OnSettingsChanged();
                } finally {
                    AppMetricaSettings.EnableWatcher();
                } 
            }
        }
    }


}
