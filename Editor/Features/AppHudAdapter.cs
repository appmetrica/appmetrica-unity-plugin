using System;

namespace Io.AppMetrica.Editor.Features {
    internal class AppHudAdapter : Feature {
        public AppHudAdapter(string featureName) : base(featureName) {}

        internal override string DefineName => "APPMETRICA_APPHUD_ADAPTER_ENABLED";

        internal override bool IsAutoEnableable => false;

        internal override void OnChangedAction() {
            AppMetricaResolver.UpdateDependencyState("AppMetricaAppHudAdapterDependencies", IsEnabled);
        }
    }
}
