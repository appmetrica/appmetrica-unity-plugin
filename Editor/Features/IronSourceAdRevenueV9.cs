using Io.AppMetrica.Editor.Features.Utils;

namespace Io.AppMetrica.Editor.Features {
    internal class IronSourceAdRevenueV9 : Feature {
        public IronSourceAdRevenueV9(string featureName) : base(featureName) {}

        internal override string DefineName => "APPMETRICA_FEATURES_ADREVENUE_IRONSOURCE_V9";

        internal override bool IsAutoEnableable => true;

        internal override void AutoEnableFeatureIfAvailable() {
            if (FeatureUtils.IsAssetInProject("LevelPlayImpressionData")) {
                AutoEnableFeatureIfNeeded();
            }
        }
    }
}
