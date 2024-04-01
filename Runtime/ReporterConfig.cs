using JetBrains.Annotations;
using System.Collections.Generic;

namespace Io.AppMetrica {
    public class ReporterConfig {
        /// <summary>
        /// <p><b>Platforms</b>: Android, iOS.</p>
        /// </summary>
        [NotNull]
        public string ApiKey { get; }

        /// <summary>
        /// <p><b>Platforms</b>: Android.</p>
        /// </summary>
        [CanBeNull]
        public IDictionary<string, string> AppEnvironment { get; set; }

        /// <summary>
        /// <p><b>Platforms</b>: Android, iOS.</p>
        /// </summary>
        [CanBeNull]
        public bool? DataSendingEnabled { get; set; }

        /// <summary>
        /// <p><b>Platforms</b>: Android, iOS.</p>
        /// </summary>
        [CanBeNull]
        public int? DispatchPeriodSeconds { get; set; }

        /// <summary>
        /// <p><b>Platforms</b>: Android, iOS.</p>
        /// </summary>
        [CanBeNull]
        public bool? Logs { get; set; }

        /// <summary>
        /// <p><b>Platforms</b>: Android, iOS.</p>
        /// </summary>
        [CanBeNull]
        public int? MaxReportsCount { get; set; }

        /// <summary>
        /// <p><b>Platforms</b>: Android, iOS.</p>
        /// </summary>
        [CanBeNull]
        public int? MaxReportsInDatabaseCount { get; set; }

        /// <summary>
        /// <p><b>Platforms</b>: Android, iOS.</p>
        /// </summary>
        [CanBeNull]
        public int? SessionTimeout { get; set; }

        /// <summary>
        /// <p><b>Platforms</b>: Android, iOS.</p>
        /// </summary>
        [CanBeNull]
        public string UserProfileID { get; set; }

        public ReporterConfig([NotNull] string apiKey) {
            ApiKey = apiKey;
        }
    }
}
