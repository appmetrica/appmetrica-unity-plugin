namespace Io.AppMetrica.Editor.Features {
    internal class FyberAdRevenueV3 : Feature {
        public FyberAdRevenueV3(string featureName) : base(featureName) {}

        internal override string DefineName => "APPMETRICA_FEATURES_ADREVENUE_FYBER_V3";

        internal override bool IsAutoEnableable => false;
    }
}
