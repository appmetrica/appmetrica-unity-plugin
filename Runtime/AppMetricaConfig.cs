using Io.AppMetrica.Native.Utils.Serializer;
using JetBrains.Annotations;
using System.Collections.Generic;

namespace Io.AppMetrica {
    /// <summary>
    /// Contains configuration of analytic processing.
    /// </summary>
    public class AppMetricaConfig {
        /// <summary>
        /// Unique identifier of app in AppMetrica.
        ///
        /// <p><b>Platforms</b>: Android, iOS.</p>
        /// </summary>
        [NotNull]
        public string ApiKey { get; }

        /// <summary>
        /// Build number of application.
        ///
        /// <p><b>Platforms</b>: Android, iOS.</p>
        /// </summary>
        [CanBeNull]
        public int? AppBuildNumber { get; set; }

        /// <summary>
        /// Key - value pair to be used as additional information, associated
        /// with your application runtime environment. This environment is unique for every unique
        /// APIKey and shared between processes. Application's environment persists to storage and
        /// retained between application launches. To reset environment use <see cref="AppMetrica.ClearAppEnvironment"/>.
        /// <p><b>WARNING:</b> Application's environment is a global permanent state and can't be changed too often.
        /// For frequently changed parameters use extended reportMessage methods.</p>
        ///
        /// <p><b>Platforms</b>: Android, iOS.</p>
        /// </summary>
        [CanBeNull]
        public IDictionary<string, string> AppEnvironment { get; set; }

        /// <summary>
        /// Sets whether app open auto tracking is enabled.
        /// Default value is true.
        /// <p><b>NOTE: </b> Auto tracking will only capture links that open app.
        /// Those that are clicked on while app is opened will be ignored.
        /// To track them call <see cref="AppMetrica.ReportAppOpen"/>.</p>
        ///
        /// <p><b>Platforms</b>: Android, iOS.</p>
        /// </summary>
        [CanBeNull]
        public bool? AppOpenTrackingEnabled { get; set; }

        /// <summary>
        /// Application version.
        ///
        /// <p><b>Platforms</b>: Android, iOS.</p>
        /// </summary>
        [CanBeNull]
        public string AppVersion { get; set; }

        /// <summary>
        /// Indicates whether to capture and send reports about crashes automatically.
        /// Default value is true.
        /// <p>True if we need to send reports about crashes, otherwise false.</p>
        ///
        /// <p><b>Platforms</b>: Android, iOS.</p>
        /// </summary>
        [CanBeNull]
        public bool? CrashReporting { get; set; }

        /// <summary>
        /// Enables/disables data sending to the AppMetrica server. By default, the sending is enabled.
        /// <p><b>NOTE:</b> Disabling this option also turns off data sending from the reporters that initialized for different apiKey.</p>
        ///
        /// <p><b>Platforms</b>: Android, iOS.</p>
        /// </summary>
        [CanBeNull]
        public bool? DataSendingEnabled { get; set; }

        /// <summary>
        /// Device type based on screen size: phone, tablet, TV.
        ///
        /// <p><b>Platforms</b>: Android.</p>
        /// </summary>
        [CanBeNull]
        public string DeviceType { get; set; }

        /// <summary>
        /// Timeout for sending reports.
        /// Default value is 90 seconds.
        /// If you set a non-positive value, then automatic sending by timer will be disabled.
        ///
        /// <p><b>Platforms</b>: Android, iOS.</p>
        /// </summary>
        [CanBeNull]
        public int? DispatchPeriodSeconds { get; set; }

        /// <summary>
        /// Key - value data to be used as additional information, associated with your unhandled exception and error reports.
        ///
        /// <p><b>Platforms</b>: Android, iOS.</p>
        /// </summary>
        [CanBeNull]
        public IDictionary<string, string> ErrorEnvironment { get; set; }

        /// <summary>
        /// Whether first activation of AppMetrica should be considered as app update or new app install.
        /// <p>True if first call of <see cref="AppMetrica.Activate"/> should be considered as app update, false otherwise.</p>
        ///
        /// <p><b>Platforms</b>: Android, iOS.</p>
        /// </summary>
        [CanBeNull]
        public bool? FirstActivationAsUpdate { get; set; }

        /// <summary>
        /// Sets <see cref="Io.AppMetrica.Location"/> to be used as location for reports of AppMetrica.
        /// <p>If location is set using this method, it will be used instead of auto collected location.</p>
        ///
        /// <p><b>Platforms</b>: Android, iOS.</p>
        /// </summary>
        [CanBeNull]
        public Location? Location { get; set; }

        /// <summary>
        /// Sets whether AppMetrica should include location information within its reports.
        /// Default value is false.
        ///
        /// <p><b>Platforms</b>: Android, iOS.</p>
        /// </summary>
        [CanBeNull]
        public bool? LocationTracking { get; set; }

        /// <summary>
        /// Enable AppMetrica logging.
        /// <p>True if enabled, false if not.</p>
        ///
        /// <p><b>Platforms</b>: Android, iOS.</p>
        /// </summary>
        [CanBeNull]
        public bool? Logs { get; set; }

        /// <summary>
        /// Maximum buffer size for reports.
        /// Default value is 7.
        /// If you set a non-positive value, then automatic sending will be disabled.
        ///
        /// <p><b>Platforms</b>: Android, iOS.</p>
        /// </summary>
        [CanBeNull]
        public int? MaxReportsCount { get; set; }

        /// <summary>
        /// Sets maximum number of reports to store in database.
        /// If this number is exceeded, some reports will be removed.
        /// Default value is 1000.
        /// Must be in range from 100 to 10000.
        /// If not, closest possible value will be used.
        ///
        /// <p><b>Platforms</b>: Android, iOS.</p>
        /// </summary>
        [CanBeNull]
        public int? MaxReportsInDatabaseCount { get; set; }

        /// <summary>
        /// Indicates whether to capture and send reports about native crashes automatically
        /// Default value is true.
        /// <p>True if we need to send reports about native crashes, otherwise false.</p>
        ///
        /// <p><b>Platforms</b>: Android.</p>
        /// </summary>
        [CanBeNull]
        public bool? NativeCrashReporting { get; set; }

        /// <summary>
        /// Sets preload info for tracking preloaded apps.
        ///
        /// <p><b>Platforms</b>: Android, iOS.</p>
        /// </summary>
        [CanBeNull]
        public PreloadInfo PreloadInfo { get; set; }

        /// <summary>
        /// Enables/disables auto tracking of in-app purchases.
        /// Default value is true.
        ///
        /// <p><b>Platforms</b>: Android, iOS.</p>
        /// </summary>
        [CanBeNull]
        public bool? RevenueAutoTrackingEnabled { get; set; }

        /// <summary>
        /// Duration of AppMetrica session.
        /// By default, the session times out if the app is inactive for 10 seconds.
        /// The minimum acceptable value is 10 seconds. If a value less than 10 is set, the value will automatically
        /// be 10 seconds.
        /// <p>Under the duration of sessions, in the concept of <b>AppMetrica</b>, means the following:</p>
        /// <p>Let the duration of sessions is 2 minutes.
        /// Then, if interaction with your application started after 2 minutes of inactivity with the application,
        /// then a new session will be created, otherwise the session will continue.</p>
        ///
        /// <p><b>Platforms</b>: Android, iOS.</p>
        /// </summary>
        [CanBeNull]
        public int? SessionTimeout { get; set; }

        /// <summary>
        /// Sets whether sessions auto tracking is enabled.
        /// Default value is true.
        ///
        /// <p><b>Platforms</b>: Android, iOS.</p>
        /// </summary>
        [CanBeNull]
        public bool? SessionsAutoTrackingEnabled { get; set; }

        /// <summary>
        /// The ID of the user profile.
        /// <p><b>NOTE:</b> The string value can contain up to 200 characters.</p>
        ///
        /// <p><b>Platforms</b>: Android, iOS.</p>
        /// </summary>
        [CanBeNull]
        public string UserProfileID { get; set; }

        /// <summary>
        /// Initializes the AppMetricaConfig object.
        /// </summary>
        /// <param name="apiKey">Application key that is issued during application registration in AppMetrica.</param>
        public AppMetricaConfig([NotNull] string apiKey) {
            ApiKey = apiKey;
        }

        [NotNull]
        public string ToJsonString() {
            return AppMetricaConfigSerializer.ToJsonString(this);
        }
    }
}
