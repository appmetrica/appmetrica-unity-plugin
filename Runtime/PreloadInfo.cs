using System.Collections.Generic;

namespace Io.AppMetrica {
    /// <summary>
    /// Contains information for tracking preloaded apps.
    /// </summary>
    public class PreloadInfo {
        /// <summary>
        /// Tracking Id for tracking preloaded apps.
        /// </summary>
        public string TrackingId { get; }

        /// <summary>
        /// Additional parameters for tracking preloaded apps.
        /// </summary>
        public IDictionary<string, string> AdditionalParams { get; set; }

        /// <summary>
        /// Initializes the PreloadInfo object.
        /// </summary>
        /// <param name="trackingId">the Tracking Id for tracking preloaded apps.</param>
        public PreloadInfo(string trackingId) {
            TrackingId = trackingId;
        }
    }
}
