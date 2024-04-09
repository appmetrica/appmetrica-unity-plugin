using JetBrains.Annotations;
using System.Collections.Generic;

namespace Io.AppMetrica {
    /// <summary>
    /// Contains configuration of analytic processing in <see cref="IReporter"/>.
    /// </summary>
    public class ReporterConfig {
        /// <summary>
        /// Unique identifier of app in AppMetrica.
        ///
        /// <p><b>Platforms</b>: Android, iOS.</p>
        /// </summary>
        [NotNull]
        public string ApiKey { get; }

        /// <summary>
        /// Key - value pair to be used as additional information, associated with your application runtime environment.
        /// This environment is unique for every unique APIKey and shared between processes.
        /// Application's environment persists to storage and retained between application launches.
        /// The values set in the config, will be set right after metrica initialization.
        /// To reset environment use <see cref="IReporter.ClearAppEnvironment"/>.
        /// <p><b>WARNING:</b> Application's environment is a global permanent state and can't be changed too often.
        /// For frequently changed parameters use extended reportMessage methods.</p>
        ///
        /// <p><b>Platforms</b>: Android, iOS.</p>
        /// </summary>
        [CanBeNull]
        public IDictionary<string, string> AppEnvironment { get; set; }

        /// <summary>
        /// Enables/disables data sending to the AppMetrica server. By default, the sending is enabled.
        /// <p><b>NOTE:</b> Disabling this option doesn't affect data sending from the main apiKey and other reporters.</p>
        ///
        /// <p><b>Platforms</b>: Android, iOS.</p>
        /// </summary>
        [CanBeNull]
        public bool? DataSendingEnabled { get; set; }

        /// <summary>
        /// Timeout of events sending if the number of events is less than <see cref="MaxReportsCount"/>.
        /// <p>Default value is 90 seconds.</p>
        /// <p>If you set a non-positive value, then automatic sending by timer will be disabled.</p>
        ///
        /// <p><b>Platforms</b>: Android, iOS.</p>
        /// </summary>
        [CanBeNull]
        public int? DispatchPeriodSeconds { get; set; }

        /// <summary>
        /// Indicates whether logging for appropriate <see cref="IReporter"/> enabled.
        /// <p><b>true</b> if enabled, <b>false</b> if not.</p>
        /// <p>Should be called before <see cref="AppMetrica.GetReporter"/></p>
        ///
        /// <p><b>Platforms</b>: Android, iOS.</p>
        /// </summary>
        [CanBeNull]
        public bool? Logs { get; set; }

        /// <summary>
        /// Maximum buffer size for reports.
        /// <p>Default value is 7.</p>
        /// <p>If you set a non-positive value, then automatic sending will be disabled for the situation when the events buffer is full.</p>
        ///
        /// <p><b>Platforms</b>: Android, iOS.</p>
        /// </summary>
        [CanBeNull]
        public int? MaxReportsCount { get; set; }

        /// <summary>
        /// Maximum number of reports to store in database. If this number is exceeded, some reports will be removed.
        /// <p>Default value is 1000. Must be in range [100, 10000].</p>
        /// <p>If not, closest possible value will be used.</p>
        ///
        /// <p><b>Platforms</b>: Android, iOS.</p>
        /// </summary>
        [CanBeNull]
        public int? MaxReportsInDatabaseCount { get; set; }

        /// <summary>
        /// Timeout for an expiring session.
        /// <p>By default, the session times out if the app is inactive for 10 seconds.</p>
        /// <p>The minimum acceptable value is 10 seconds. If a value less than 10 is set, the value will automatically be 10 seconds.</p>
        ///
        /// <p>Under the duration of sessions, in the concept of <b>Metrica</b>, means the following:</p>
        /// <p>Let the duration of session timeout is 2 minutes.
        /// Then, if interaction with your application started
        /// after 2 minutes of inactivity with the application,
        /// then a new session will be created,
        /// otherwise the session will continue.
        /// </p>
        /// 
        /// <p><b>Platforms</b>: Android, iOS.</p>
        /// </summary>
        [CanBeNull]
        public int? SessionTimeout { get; set; }

        /// <summary>
        /// The ID of the user profile.
        /// <p><b>NOTE:</b> The string value can contain up to 200 characters.</p>
        ///
        /// <p><b>Platforms</b>: Android, iOS.</p>
        /// </summary>
        [CanBeNull]
        public string UserProfileID { get; set; }

        /// <summary>
        /// Initializes the ReporterConfig object.
        /// </summary>
        /// <param name="apiKey">Application key that is issued during application registration in AppMetrica.</param>
        public ReporterConfig([NotNull] string apiKey) {
            ApiKey = apiKey;
        }
    }
}
