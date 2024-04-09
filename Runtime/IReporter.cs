using Io.AppMetrica.Ecommerce;
using Io.AppMetrica.Profile;
using JetBrains.Annotations;
using System;

namespace Io.AppMetrica {
    /// <summary>
    /// <see cref="IReporter"/> can send events to an alternative api key, differ from api key, passed to <see cref="AppMetrica.Activate"/>.
    /// <p>Instance of object, implements <see cref="IReporter"/>, can be obtained via <see cref="AppMetrica.GetReporter"/> method call.</p>
    /// <p>For every api key only one <see cref="IReporter"/> instance is created. You can either query it each time you need it, or save the reference by yourself.</p>
    /// </summary>
    /// <seealso cref="AppMetrica.ActivateReporter"/>
    /// <seealso cref="AppMetrica.GetReporter"/>
    public interface IReporter {
        /// <summary>
        /// Clears app environment and removes it from storage.
        ///
        /// <p><b>Platforms</b>: Android, iOS.</p>
        /// </summary>
        void ClearAppEnvironment();

        /// <summary>
        /// Pauses current session.
        /// All events reported after calling this method and till the session timeout will still join this session.
        ///
        /// <p><b>Platforms</b>: Android, iOS.</p>
        /// </summary>
        void PauseSession();

        /// <summary>
        /// Sets key - value pair to be used as additional information, associated with your application runtime environment.
        /// This environment is unique for every unique APIKey and shared between processes.
        /// Application's environment persists to storage and retained between application launches.
        /// To reset environment use <see cref="ClearAppEnvironment"/>.
        /// <p><b>WARNING:</b> Application's environment is a global permanent state and can't be changed too often.
        /// For frequently changed parameters use extended reportMessage methods.</p>
        ///
        /// <p><b>Platforms</b>: Android, iOS.</p>
        /// </summary>
        /// <param name="key">the environment key.</param>
        /// <param name="value">the environment value. To remove pair from environment pass <b>null</b> value.</param>
        void PutAppEnvironmentValue([NotNull] string key, [CanBeNull] string value);

        /// <summary>
        /// Sends information about ad revenue.
        ///
        /// <p><b>Platforms</b>: Android, iOS.</p>
        /// </summary>
        /// <param name="adRevenue">the <see cref="AdRevenue"/> object. It containing the information about ad revenue.</param>
        void ReportAdRevenue([NotNull] AdRevenue adRevenue);

        /// <summary>
        /// Sends e-commerce event.
        ///
        /// <p><b>Platforms</b>: Android, iOS.</p>
        /// </summary>
        /// <param name="ecommerce">the <see cref="ECommerceEvent"/> object to sent.</param>
        void ReportECommerce([NotNull] ECommerceEvent ecommerce);

        /// <summary>
        /// Sends an error. Use this method to report un unexpected situation.
        /// If you use this method errors will be grouped by <paramref name="error"/> stacktrace.
        /// If you want to influence the way errors are grouped use <see cref="ReportError(string,string,System.Exception)"/>.
        ///
        /// <p><b>Platforms</b>: Android, iOS.</p>
        /// </summary>
        /// <param name="message">short description or name of the error.</param>
        /// <param name="error"><see cref="Exception"/> object for the error.</param>
        void ReportError([NotNull] string message, [NotNull] Exception error);

        /// <summary>
        /// Sends an error. Use this method to report un unexpected situation.
        /// This method should be used if you want to customize error grouping.
        /// If not use <see cref="ReportError(string,System.Exception)"/>.
        ///
        /// <p><b>Platforms</b>: Android, iOS.</p>
        /// </summary>
        /// <param name="identifier">an identifier used for grouping errors.
        ///                          Errors that have the same identifiers will belong in one group.
        ///                          Do not use dynamically formed strings or exception messages as identifiers
        ///                          to avoid having too many small crash groups.</param>
        /// <param name="message">short description or name of the error. Can be null</param>
        /// <param name="error"><see cref="Exception"/> object for the error. Can be null.</param>
        void ReportError([NotNull] string identifier, [CanBeNull] string message = null, [CanBeNull] Exception error = null);

        /// <summary>
        /// Sends report by event name.
        ///
        /// <p><b>Platforms</b>: Android, iOS.</p>
        /// </summary>
        /// <param name="eventName">short name or description of the event.</param>
        void ReportEvent([NotNull] string eventName);

        /// <summary>
        /// Sends report by event name and event value.
        ///
        /// <p><b>Platforms</b>: Android, iOS.</p>
        /// </summary>
        /// <param name="eventName">short name or description of the event.</param>
        /// <param name="jsonValue">JSON object represented as a string. Maximum level of nesting (for JSON object) - <b>5.</b></param>
        void ReportEvent([NotNull] string eventName, [CanBeNull] string jsonValue);

        /// <summary>
        /// Sends information about the purchase.
        ///
        /// <p><b>Platforms</b>: Android, iOS.</p>
        /// </summary>
        /// <param name="revenue">the <see cref="Revenue"/> object. It contains purchase information.</param>
        void ReportRevenue([NotNull] Revenue revenue);

        /// <summary>
        /// Sends unhandled exception by <see cref="Exception"/> object.
        ///
        /// <p><b>Platforms</b>: Android, iOS.</p>
        /// </summary>
        /// <param name="exception"><see cref="Exception"/> object for the unhandled exception</param>
        void ReportUnhandledException([NotNull] Exception exception);

        /// <summary>
        /// Sends information about the user profile.
        ///
        /// <p><b>Platforms</b>: Android, iOS.</p>
        /// </summary>
        /// <param name="profile">the <see cref="UserProfile"/> object. Contains user profile information.</param>
        void ReportUserProfile([NotNull] UserProfile profile);

        /// <summary>
        /// Resumes last session or creates a new one if it has been expired.
        ///
        /// <p><b>Platforms</b>: Android, iOS.</p>
        /// </summary>
        void ResumeSession();

        /// <summary>
        /// Initiates forced sending of all stored events from the buffer.
        /// AppMetrica SDK doesn't send events immediately after they occurred. It stores events data in the buffer.
        /// This method forcibly initiates sending all the data from the buffer and flushes it.
        /// Use the method after important checkpoints of user scenarios.
        /// <p><b>WARNING:</b> Frequent use of the method can lead to increasing outgoing internet traffic and energy consumption.</p>
        ///
        /// <p><b>Platforms</b>: Android, iOS.</p>
        /// </summary>
        void SendEventsBuffer();

        /// <summary>
        /// Enables/disables data sending to the AppMetrica server. By default, the sending is enabled.
        /// <p><b>NOTE:</b> Disabling this option doesn't affect data sending from the main apiKey and other reporters.</p>
        ///
        /// <p><b>Platforms</b>: Android, iOS.</p>
        /// </summary>
        /// <param name="enabled"><b>true</b> to allow AppMetrica sending data, otherwise <b>false</b>.</param>
        void SetDataSendingEnabled(bool enabled);

        /// <summary>
        /// Sets the ID of the user profile.
        /// <p><b>NOTE:</b> The string value can contain up to 200 characters.</p>
        ///
        /// <p><b>Platforms</b>: Android, iOS.</p>
        /// </summary>
        /// <param name="profileID">the custom user profile ID.</param>
        void SetUserProfileID([CanBeNull] string profileID);
    }
}
