using Io.AppMetrica.Editor.Features.Utils;

namespace Io.AppMetrica.Editor.Features {
    internal class IronSourceAdRevenueV8 : Feature {
        public IronSourceAdRevenueV8(string featureName) : base(featureName) {}

        internal override string DefineName => "APPMETRICA_FEATURES_ADREVENUE_IRONSOURCE_V8";

        internal override bool IsAutoEnableable => true;

        internal override void AutoEnableFeatureIfAvailable() {
            if (FeatureUtils.IsAssetInProject("IronSourceAdInfo")) {
                AutoEnableFeatureIfNeeded();
            }
        }
    }
}
