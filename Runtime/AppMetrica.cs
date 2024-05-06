using Io.AppMetrica.Ecommerce;
using Io.AppMetrica.Internal;
using Io.AppMetrica.Native;
using Io.AppMetrica.Profile;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

#if UNITY_ANDROID && !UNITY_EDITOR
using Io.AppMetrica.Native.Android;
#elif (UNITY_IPHONE || UNITY_IOS) && !UNITY_EDITOR
using Io.AppMetrica.Native.Ios;
#else
using Io.AppMetrica.Native.Dummy;
#endif

namespace Io.AppMetrica {
    public delegate void ActivationListener([NotNull] AppMetricaConfig config);
    
    /// <summary>
    /// Class assistant for analytic processing.
    /// </summary>
    public static class AppMetrica {
        private static bool _isActivated = false;
        [NotNull]
        private static readonly IAppMetricaNative Native;
        [NotNull]
        private static readonly object ReportersLock = new Object();
        [NotNull]
        private static readonly IDictionary<string, IReporter> Reporters = new Dictionary<string, IReporter>();

        [CanBeNull]
        public static AppMetricaConfig ActivationConfig;
        public static event ActivationListener OnActivation;

        static AppMetrica() {
#if UNITY_ANDROID && !UNITY_EDITOR
            Native = new AppMetricaAndroid();
#elif (UNITY_IPHONE || UNITY_IOS) && !UNITY_EDITOR
            Native = new AppMetricaIos();
#else
            Native = new AppMetricaDummy();
#endif
        }

        /// <summary>
        /// Initializes <see cref="AppMetrica"/> with <see cref="AppMetricaConfig"/>.
        ///
        /// <p><b>Platforms</b>: Android, iOS.</p>
        /// </summary>
        /// <param name="config">AppMetrica configuration object.</param>
        public static void Activate([NotNull] AppMetricaConfig config) {
            Native.Activate(config);
            _isActivated = true;
            CrashHandler.SetAutoCrashReporting(config.CrashReporting);
            ActivationConfig = config;
            OnActivation?.Invoke(config);
        }

        /// <summary>
        /// Activates the reporter with <see cref="ReporterConfig"/>.
        ///
        /// <p><b>Platforms</b>: Android, iOS.</p>
        /// </summary>
        /// <param name="config">the ReporterConfig object.</param>
        public static void ActivateReporter([NotNull] ReporterConfig config) {
            Native.ActivateReporter(config);
        }

        /// <summary>
        /// Clears app environment and removes it from storage.
        /// <p>If called before metrica initialization, app environment will be cleared right after init</p>
        ///
        /// <p><b>Platforms</b>: Android, iOS.</p>
        /// </summary>
        public static void ClearAppEnvironment() {
            Native.ClearAppEnvironment();
        }

        /// <summary>
        /// <p><b>Platforms</b>: Android, iOS.</p>
        /// </summary>
        /// <returns>deviceId if present, null otherwise.</returns>
        [CanBeNull]
        public static string GetDeviceId() {
            return Native.GetDeviceId();
        }

        /// <summary>
        /// <p><b>Platforms</b>: Android, iOS.</p>
        /// </summary>
        /// <returns><b>VERSION</b> of library.</returns>
        [NotNull]
        public static string GetLibraryVersion() {
            return Native.GetLibraryVersion();
        }

        /// <summary>
        /// Creates an <see cref="IReporter"/> that can send events to an alternative api key.
        /// <p>For every api key only one <see cref="IReporter"/> instance is created.</p>
        /// <p>You can either query it each time you need it, or save the reference by yourself.</p>
        ///
        /// <p><b>Platforms</b>: Android, iOS.</p>
        /// </summary>
        /// <param name="apiKey">APIKey of the reporter.</param>
        /// <returns>reporter instance for given api key.</returns>
        [NotNull]
        public static IReporter GetReporter([NotNull] string apiKey) {
            if (!Reporters.TryGetValue(apiKey, out var reporter)) {
                lock (ReportersLock) {
                    if (!Reporters.TryGetValue(apiKey, out reporter)) {
                        reporter = Native.GetReporter(apiKey);
                        Reporters[apiKey] = reporter;
                    }
                }
            }
            return reporter;
        }

        /// <summary>
        /// <p><b>Platforms</b>: Android, iOS.</p>
        /// </summary>
        /// <returns>uuid if present, null otherwise.</returns>
        [CanBeNull]
        public static string GetUuid() {
            return Native.GetUuid();
        }

        /// <summary>
        /// <p><b>Platforms</b>: Android, iOS.</p>
        /// </summary>
        /// <returns>indicates whether AppMetrica has been activated.</returns>
        public static bool IsActivated() {
            if (!_isActivated && Native.IsActivated()) {
                _isActivated = true;
            }
            return _isActivated;
        }

        /// <summary>
        /// Helper method for tracking the life cycle of the application.
        ///
        /// <p><b>Platforms</b>: Android, iOS.</p>
        /// </summary>
        public static void PauseSession() {
            Native.PauseSession();
        }

        /// <summary>
        /// Sets key - value pair to be used as additional information, associated
        /// with your application runtime environment. This environment is unique for every unique
        /// APIKey and shared between processes. Application's environment persists to storage and
        /// retained between application launches. To reset environment use <see cref="AppMetrica.ClearAppEnvironment"/>.
        /// <p>If called before metrica initialization, environment will be added right after metrica initialize</p>
        /// <p><b>WARNING:</b> Application's environment is a global permanent state and can't be changed too often.
        /// For frequently changed parameters use extended reportMessage methods.</p>
        ///
        /// <p><b>Platforms</b>: Android, iOS.</p>
        /// </summary>
        /// <param name="key">the environment key.</param>
        /// <param name="value">the environment value. To remove pair from environment pass null value.</param>
        public static void PutAppEnvironmentValue([NotNull] string key, [CanBeNull] string value) {
            Native.PutAppEnvironmentValue(key, value);
        }

        /// <summary>
        /// Sets key - value data to be used as additional information, associated
        /// with your unhandled exception and error reports.
        ///
        /// <p><b>Platforms</b>: Android, iOS.</p>
        /// </summary>
        /// <param name="key">the environment key.</param>
        /// <param name="value">the environment value. To remove pair from environment pass null value.</param>
        public static void PutErrorEnvironmentValue([NotNull] string key, [CanBeNull] string value) {
            Native.PutErrorEnvironmentValue(key, value);
        }

        /// <summary>
        /// Sends information about ad revenue.
        ///
        /// <p><b>Platforms</b>: Android, iOS.</p>
        /// </summary>
        /// <param name="adRevenue">the information about ad revenue.</param>
        public static void ReportAdRevenue([NotNull] AdRevenue adRevenue) {
            Native.ReportAdRevenue(adRevenue);
        }

        /// <summary>
        /// Sends report about open app via deeplink. Null and empty values will be ignored.
        ///
        /// <p><b>Platforms</b>: Android, iOS.</p>
        /// </summary>
        /// <param name="deeplink">deeplink value.</param>
        public static void ReportAppOpen([NotNull] string deeplink) {
            Native.ReportAppOpen(deeplink);
        }

        /// <summary>
        /// Sends e-commerce event.
        ///
        /// <p><b>Platforms</b>: Android, iOS.</p>
        /// </summary>
        /// <param name="ecommerce">e-commerce event to be sent.</param>
        public static void ReportECommerce([NotNull] ECommerceEvent ecommerce) {
            Native.ReportECommerce(ecommerce);
        }

        /// <summary>
        /// Sends an error. Use this method to report un unexpected situation.
        /// If you use this method errors will be grouped by <paramref name="error"/> stacktrace.
        /// If you want to influence the way errors are grouped use
        /// <see cref="AppMetrica.ReportError(string, string, Exception)"/>.
        ///
        /// <p><b>Platforms</b>: Android, iOS.</p>
        /// </summary>
        /// <param name="message">short name or description of the error.</param>
        /// <param name="error"><see cref="Exception"/> object for the error.</param>
        public static void ReportError([NotNull] string message, [NotNull] Exception error) {
            Native.ReportError(message, error);
        }

        /// <summary>
        /// Sends an error. Use this method to report un unexpected situation.
        /// This method should be used if you want to customize error grouping.
        /// If not use <see cref="AppMetrica.ReportError(string, Exception)"/>.
        /// <p><paramref name="error"/> stacktrace will NOT be used for grouping, only <paramref name="identifier"/>.</p>
        ///
        /// <p><b>Platforms</b>: Android, iOS.</p>
        /// </summary>
        /// <param name="identifier">an identifier used for grouping errors.
        ///                          Errors that have the same identifiers will belong in one group.
        ///                          Do not use dynamically formed strings or exception messages as identifiers
        ///                          to avoid having too many small crash groups.</param>
        /// <param name="message">short name or description of the error.</param>
        /// <param name="error"><see cref="Exception"/> object for the error.
        ///                     Its stacktrace will not be considered for error grouping.</param>
        public static void ReportError([NotNull] string identifier, [CanBeNull] string message = null, [CanBeNull] Exception error = null) {
            Native.ReportError(identifier, message, error);
        }

        /// <summary>
        /// Sends report by event name.
        ///
        /// <p><b>Platforms</b>: Android, iOS.</p>
        /// </summary>
        /// <param name="eventName">short name or description of the event.</param>
        public static void ReportEvent([NotNull] string eventName) {
            Native.ReportEvent(eventName);
        }

        /// <summary>
        /// Sends report by event name and event value.
        ///
        /// <p><b>Platforms</b>: Android, iOS.</p>
        /// </summary>
        /// <param name="eventName">short name or description of the event.</param>
        /// <param name="jsonValue">a string represented in JSON format.
        ///                         Maximum level of nesting (for JSON object) - <b>5</b>.</param>
        public static void ReportEvent([NotNull] string eventName, [CanBeNull] string jsonValue) {
            Native.ReportEvent(eventName, jsonValue);
        }

        /// <summary>
        /// Sends information about the external attribution from other SDKs.
        ///
        /// <p><b>Platforms</b>: Android, iOS.</p>
        /// </summary>
        /// <param name="externalAttribution">an object that implements <see cref="ExternalAttribution"/> interface.</param>
        /// <seealso cref="ExternalAttributions"/>
        public static void ReportExternalAttribution([NotNull] ExternalAttribution externalAttribution) {
            if (externalAttribution.Value != null) {
                Native.ReportExternalAttribution(externalAttribution.Source, externalAttribution.Value);
            }
        }

        /// <summary>
        /// Sends information about the purchase.
        ///
        /// <p><b>Platforms</b>: Android, iOS.</p>
        /// </summary>
        /// <param name="revenue">purchase information</param>
        public static void ReportRevenue([NotNull] Revenue revenue) {
            Native.ReportRevenue(revenue);
        }

        /// <summary>
        /// Sends unhandled exception by <see cref="Exception"/> object.
        ///
        /// <p><b>Platforms</b>: Android, iOS.</p>
        /// </summary>
        /// <param name="exception"><see cref="Exception"/> object for the unhandled exception.</param>
        public static void ReportUnhandledException([NotNull] Exception exception) {
            Native.ReportUnhandledException(exception);
        }

        /// <summary>
        /// Sends information about the user profile.
        ///
        /// <p><b>Platforms</b>: Android, iOS.</p>
        /// </summary>
        /// <param name="profile">user profile information.</param>
        public static void ReportUserProfile([NotNull] UserProfile profile) {
            Native.ReportUserProfile(profile);
        }

        /// <summary>
        /// Requests deferred deeplink. It will be available after receiving
        /// Requests deferred deeplink parameters. Parameters will be available after receiving
        /// <a href = "https://developers.google.com/analytics/devguides/collection/android/v4/campaigns">
        /// Google Play installation referrer from Google Play</a>.
        /// Google Play installation referrer is usually received soon after first launch of application.
        /// After Google Play installation referrer is received, deferred deeplink will be extracted
        /// and delivered to <see cref="DeferredDeeplink.DeeplinkDelegate"/> listener.
        /// If error occurs it will be delivered to <see cref="DeferredDeeplink.ErrorDelegate"/>.
        ///
        /// <p><b>Platforms</b>: Android.</p>
        /// </summary>
        /// <param name="onDeeplinkLoaded">the object that receives callbacks when Google Play referrer is received.</param>
        /// <param name="onError">the object that receives error.</param>
        public static void RequestDeferredDeeplink(
            [NotNull] DeferredDeeplink.DeeplinkDelegate onDeeplinkLoaded,
            [CanBeNull] DeferredDeeplink.ErrorDelegate onError = null
        ) {
            Native.RequestDeferredDeeplink(onDeeplinkLoaded, onError);
        }

        /// <summary>
        /// Requests deferred deeplink parameters. Parameters will be available after receiving
        /// <a href = "https://developers.google.com/analytics/devguides/collection/android/v4/campaigns">
        /// Google Play installation referrer from Google Play</a>.
        /// Google Play installation referrer is usually received soon after first launch of application.
        /// After Google Play installation referrer is received, deferred deeplink parameters will be extracted
        /// and delivered to <see cref="DeferredDeeplinkParameters.ParametersDelegate"/> listener.
        /// If error occurs it will be delivered to <see cref="DeferredDeeplinkParameters.ErrorDelegate"/>.
        ///
        /// <p><b>Platforms</b>: Android.</p>
        /// </summary>
        /// <param name="onParametersLoaded">the object that receives callbacks when Google Play referrer is received.</param>
        /// <param name="onError">the object that receives error.</param>
        public static void RequestDeferredDeeplinkParameters(
            [NotNull] DeferredDeeplinkParameters.ParametersDelegate onParametersLoaded,
            [CanBeNull] DeferredDeeplinkParameters.ErrorDelegate onError = null
        ) {
            Native.RequestDeferredDeeplinkParameters(onParametersLoaded, onError);
        }

        /// <summary>
        /// Gets specific startup parameters based on the options in <see cref="StartupParamsDelegate"/>.
        ///
        /// <p>Parameters might not be available right away. When they do arrive,
        /// the <paramref name="action"/> is informed instantly. If the parameters are already there,
        /// the <paramref name="action"/> also gets notified right away.
        /// After one notification, the <paramref name="action"/> is removed.</p>
        ///
        /// <p><b>NOTE:</b> This method can be called even without initializing via
        /// <see cref="AppMetrica.Activate"/>, but it will take more time to get the startup identifiers.</p>
        ///
        /// <p><b>Platforms</b>: Android, iOS.</p>
        /// </summary>
        /// <param name="action">object that implements the <see cref="StartupParamsDelegate"/> interface.</param>
        /// <param name="identifiers">list of parameters to request.
        ///                           If the list is empty, the default request is for
        ///                           <see cref="StartupParamsKey.AppMetricaUuid"/>,
        ///                           <see cref="StartupParamsKey.AppMetricaDeviceID"/>,
        ///                           <see cref="StartupParamsKey.AppMetricaDeviceIDHash"/></param>
        public static void RequestStartupParams([NotNull] StartupParamsDelegate action, [NotNull] IEnumerable<string> identifiers) {
            Native.RequestStartupParams(action, identifiers);
        }

        /// <summary>
        /// Helper method for tracking the life cycle of the application.
        ///
        /// <p><b>Platforms</b>: Android, iOS.</p>
        /// </summary>
        public static void ResumeSession() {
            Native.ResumeSession();
        }

        /// <summary>
        /// Initiates forced sending of all stored events from the buffer.
        /// <p>AppMetrica SDK doesn't send events immediately after they occurred. It stores events data in the buffer.
        /// This method forcibly initiates sending all the data from the buffer and flushes it.</p>
        /// <p>Use the method after important checkpoints of user scenarios.</p>
        /// <p><b>WARNING:</b> Frequent use of the method can lead to increasing outgoing internet traffic and
        /// energy consumption.</p>
        ///
        /// <p><b>Platforms</b>: Android, iOS.</p>
        /// </summary>
        public static void SendEventsBuffer() {
            Native.SendEventsBuffer();
        }

        /// <summary>
        /// Enables/disables data sending to the AppMetrica server. By default, the sending is enabled.
        /// <p><b>NOTE:</b> Disabling this option also turns off data sending from the reporters that initialized
        /// for different apiKey.</p>
        ///
        /// <p><b>Platforms</b>: Android, iOS.</p>
        /// </summary>
        /// <param name="enabled">true to allow AppMetrica sending data, otherwise false.</param>
        public static void SetDataSendingEnabled(bool enabled) {
            Native.SetDataSendingEnabled(enabled);
        }

        /// <summary>
        /// Sets <see cref="LocationInfo"/> to be used as location for reports of AppMetrica.
        /// <p>If location is set using this method, it will be used instead of auto collected location.
        /// To switch back to auto collected location, pass null to <see cref="AppMetrica.SetLocation"/>.</p>
        ///
        /// <p><b>Platforms</b>: Android, iOS.</p>
        /// </summary>
        /// <param name="location">location that will be used instead of auto collected.</param>
        /// <seealso cref="AppMetrica.SetLocationTracking"/>
        public static void SetLocation([CanBeNull] Location? location) {
            Native.SetLocation(location);
        }

        /// <summary>
        /// Sets whether AppMetrica should include location information within its reports.
        /// <p><b>NOTE:</b> Default value is false.</p>
        ///
        /// <p><b>Platforms</b>: Android, iOS.</p>
        /// </summary>
        /// <param name="enabled">true to allow AppMetrica to record location information in reports, otherwise false.</param>
        /// <seealso cref="AppMetrica.SetLocation"/>
        public static void SetLocationTracking(bool enabled) {
            Native.SetLocationTracking(enabled);
        }

        /// <summary>
        /// Sets the ID of the user profile.
        /// <p><b>NOTE:</b> The string value can contain up to 200 characters.</p>
        ///
        /// <p><b>Platforms</b>: Android, iOS.</p>
        /// </summary>
        /// <param name="userProfileID">the custom user profile ID.</param>
        public static void SetUserProfileID([CanBeNull] string userProfileID) {
            Native.SetUserProfileID(userProfileID);
        }

        internal static void ReportExceptionFromLog(string condition, string exception, string source) {
            Native.ReportExceptionFromLog(condition, exception, source);
        }
    }
}
