#if UNITY_IPHONE || UNITY_IOS
using Io.AppMetrica.Ecommerce;
using Io.AppMetrica.Native.Ios.Proxy;
using Io.AppMetrica.Native.Utils.Serializer;
using Io.AppMetrica.Profile;
using JetBrains.Annotations;
using System;

namespace Io.AppMetrica.Native.Ios {
    internal class ReporterIos : IReporterNative {
        private readonly string _apiKey;

        public ReporterIos([NotNull] string apiKey) {
            _apiKey = apiKey;
        }

        public void ClearAppEnvironment() {
            ReporterProxy.amau_reporterClearAppEnvironment(_apiKey);
        }

        public void PauseSession() {
            ReporterProxy.amau_reporterPauseSession(_apiKey);
        }

        public void PutAppEnvironmentValue([NotNull] string key, [CanBeNull] string value) {
            ReporterProxy.amau_reporterPutAppEnvironmentValue(_apiKey, key, value);
        }

        public void ReportAdRevenue([NotNull] AdRevenue adRevenue) {
            ReporterProxy.amau_reporterReportAdRevenue(_apiKey, adRevenue.ToJsonString());
        }

        public void ReportECommerce([NotNull] ECommerceEvent ecommerce) {
            var json = ecommerce.ToJsonString();
            if (json != null) {
                ReporterProxy.amau_reporterReportECommerce(_apiKey, json);
            }
        }

        public void ReportError([NotNull] string message, [CanBeNull] Exception error) {
            ReporterProxy.amau_reporterReportErrorWithoutIdentifier(_apiKey, message, error?.ToJsonString());
        }

        public void ReportError([NotNull] string identifier, [CanBeNull] string message, [CanBeNull] Exception error) {
            ReporterProxy.amau_reporterReportError(_apiKey, identifier, message, error?.ToJsonString());
        }

        public void ReportEvent([NotNull] string eventName) {
            ReporterProxy.amau_reporterReportEvent(_apiKey, eventName, null);
        }

        public void ReportEvent([NotNull] string eventName, [CanBeNull] string jsonValue) {
            ReporterProxy.amau_reporterReportEvent(_apiKey, eventName, jsonValue);
        }

        public void ReportRevenue([NotNull] Revenue revenue) {
            ReporterProxy.amau_reporterReportRevenue(_apiKey, revenue.ToJsonString());
        }

        public void ReportUnhandledException([NotNull] Exception exception) {
            ReporterProxy.amau_reporterReportUnhandledException(_apiKey, exception.ToJsonString());
        }

        public void ReportUserProfile([NotNull] UserProfile profile) {
            ReporterProxy.amau_reporterReportUserProfile(_apiKey, profile.ToJsonString());
        }

        public void ResumeSession() {
            ReporterProxy.amau_reporterResumeSession(_apiKey);
        }

        public void SendEventsBuffer() {
            ReporterProxy.amau_reporterSendEventsBuffer(_apiKey);
        }

        public void SetDataSendingEnabled(bool enabled) {
            ReporterProxy.amau_reporterSetDataSendingEnabled(_apiKey, enabled);
        }

        public void SetUserProfileID([CanBeNull] string profileID) {
            ReporterProxy.amau_reporterSetUserProfileID(_apiKey, profileID);
        }
    }
}
#endif
