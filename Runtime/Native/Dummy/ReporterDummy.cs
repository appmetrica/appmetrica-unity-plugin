using Io.AppMetrica.Ecommerce;
using Io.AppMetrica.Profile;
using JetBrains.Annotations;
using System;

namespace Io.AppMetrica.Native.Dummy {
    internal class ReporterDummy : IReporterNative {
        public void ClearAppEnvironment() { }

        public void PauseSession() { }

        public void PutAppEnvironmentValue([NotNull] string key, [CanBeNull] string value) { }

        public void ReportAdRevenue([NotNull] AdRevenue adRevenue) { }

        public void ReportECommerce([NotNull] ECommerceEvent @event) { }

        public void ReportError([NotNull] string message, [NotNull] Exception error) { }

        public void ReportError([NotNull] string identifier, [CanBeNull] string message, [CanBeNull] Exception error) { }

        public void ReportEvent([NotNull] string eventName) { }

        public void ReportEvent([NotNull] string eventName, [CanBeNull] string jsonValue) { }

        public void ReportRevenue([NotNull] Revenue revenue) { }

        public void ReportUnhandledException([NotNull] Exception exception) { }

        public void ReportUserProfile([NotNull] UserProfile profile) { }

        public void ResumeSession() { }

        public void SendEventsBuffer() { }

        public void SetDataSendingEnabled(bool enabled) { }

        public void SetUserProfileID([CanBeNull] string profileID) { }
    }
}
