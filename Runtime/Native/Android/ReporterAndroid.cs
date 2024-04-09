#if UNITY_ANDROID
using Io.AppMetrica.Ecommerce;
using Io.AppMetrica.Native.Android.Proxy;
using Io.AppMetrica.Native.Utils.Serializer;
using Io.AppMetrica.Profile;
using JetBrains.Annotations;
using System;

namespace Io.AppMetrica.Native.Android {
    internal class ReporterAndroid : IReporterNative {
        private readonly string _apiKey;

        public ReporterAndroid([NotNull] string apiKey) {
            _apiKey = apiKey;
        }

        public void ClearAppEnvironment() {
            ReporterProxy.ClearAppEnvironment(_apiKey);
        }

        public void PauseSession() {
            ReporterProxy.PauseSession(_apiKey);
        }

        public void PutAppEnvironmentValue([NotNull] string key, [CanBeNull] string value) {
            ReporterProxy.PutAppEnvironmentValue(_apiKey, key, value);
        }

        public void ReportAdRevenue([NotNull] AdRevenue adRevenue) {
            ReporterProxy.ReportAdRevenue(_apiKey, adRevenue.ToJsonString());
        }

        public void ReportECommerce([NotNull] ECommerceEvent ecommerce) {
            var jsonString = ecommerce.ToJsonString();
            if (jsonString != null) {
                ReporterProxy.ReportECommerce(_apiKey, jsonString);
            }
        }

        public void ReportError([NotNull] string message, [NotNull] Exception error) {
            ReporterProxy.ReportErrorWithoutIdentifier(_apiKey, message, error.ToJsonString());
        }

        public void ReportError([NotNull] string identifier, [CanBeNull] string message, [CanBeNull] Exception error) {
            ReporterProxy.ReportError(_apiKey, identifier, message, error?.ToJsonString());
        }

        public void ReportEvent([NotNull] string eventName) {
            ReporterProxy.ReportEvent(_apiKey, eventName, null);
        }

        public void ReportEvent([NotNull] string eventName, [CanBeNull] string jsonValue) {
            ReporterProxy.ReportEvent(_apiKey, eventName, jsonValue);
        }

        public void ReportRevenue([NotNull] Revenue revenue) {
            ReporterProxy.ReportRevenue(_apiKey, revenue.ToJsonString());
        }

        public void ReportUnhandledException([NotNull] Exception exception) {
            ReporterProxy.ReportUnhandledException(_apiKey, exception.ToJsonString());
        }

        public void ReportUserProfile([NotNull] UserProfile profile) {
            ReporterProxy.ReportUserProfile(_apiKey, profile.ToJsonString());
        }

        public void ResumeSession() {
            ReporterProxy.ResumeSession(_apiKey);
        }

        public void SendEventsBuffer() {
            ReporterProxy.SendEventsBuffer(_apiKey);
        }

        public void SetDataSendingEnabled(bool enabled) {
            ReporterProxy.SetDataSendingEnabled(_apiKey, enabled);
        }

        public void SetUserProfileID([CanBeNull] string profileID) {
            ReporterProxy.SetUserProfileID(_apiKey, profileID);
        }
    }
}
#endif
