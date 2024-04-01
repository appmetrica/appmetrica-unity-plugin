using System.Collections.Generic;

namespace Io.AppMetrica {
    /// Android: io.appmetrica.analytics.PreloadInfo
    public class PreloadInfo {
        /// Android:
        ///   java.util.Map getAdditionalParams()
        ///   io.appmetrica.analytics.PreloadInfo$Builder setAdditionalParams(java.lang.String, java.lang.String)
        public IDictionary<string, string> AdditionalParams { get; set; }

        /// Android:
        ///   java.lang.String getTrackingId()
        public string TrackingId { get; }

        /// Android: static io.appmetrica.analytics.PreloadInfo$Builder newBuilder(java.lang.String)
        public PreloadInfo(string trackingId) {
            TrackingId = trackingId;
        }
    }
}
