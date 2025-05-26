namespace Io.AppMetrica.Editor.Features {
    internal abstract class Feature {
        protected Feature(string featureName) {
            _featureName = featureName;
        }

        private readonly string _featureName;
        internal abstract string DefineName { get; }
        internal abstract bool IsAutoEnableable { get; }

        internal virtual void AutoEnableFeatureIfAvailable() {}

        internal virtual void OnChangedAction() {}

        internal bool IsManualEnabled {
            get {
                var settingsValue = AppMetricaSettings.GetString(GetFeatureKeyForSettings());
                return settingsValue == nameof(FeatureState.Manual) || settingsValue == nameof(FeatureState.True);
            }
            set {
                var settingsValue = value ? nameof(FeatureState.Manual) : nameof(FeatureState.False);
                AppMetricaSettings.SetString(GetFeatureKeyForSettings(), settingsValue);
            }
        }

        internal bool IsAutoEnabled {
            get => AppMetricaSettings.GetString(GetFeatureKeyForSettings()) == nameof(FeatureState.Auto);
            private set {
                if (value) {
                    AppMetricaSettings.SetString(GetFeatureKeyForSettings(), nameof(FeatureState.Auto));
                }
            }
        }

        internal string AutoEnabledDefineName => $"{DefineName}_AUTO_ENABLED";

        internal bool IsEnabled => IsManualEnabled || IsAutoEnabled;

        protected void AutoEnableFeatureIfNeeded() {
            if (AppMetricaSettings.GetString(GetFeatureKeyForSettings()) != "") return;
            IsAutoEnabled = true;
        }

        private string GetFeatureKeyForSettings() {
            return $"Feature.{_featureName}.Enabled";
        }

        private enum FeatureState {
            True, // Deprecated type for backward compatibility
            Manual,
            Auto,
            False
        }
    }
}
