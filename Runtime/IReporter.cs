using Io.AppMetrica.Ecommerce;
using Io.AppMetrica.Profile;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;

namespace Io.AppMetrica {
    /// Android: io.appmetrica.analytics.IReporter
    public interface IReporter {
        /// Android: void clearAppEnvironment()
        public void ClearAppEnvironment();

        /// Android: void pauseSession()
        public void PauseSession();

        /// Android: void putAppEnvironmentValue(java.lang.String, java.lang.String)
        public void PutAppEnvironmentValue([NotNull] string key, [CanBeNull] string value);

        /// Android: void reportAdRevenue(io.appmetrica.analytics.AdRevenue)
        public void ReportAdRevenue([NotNull] AdRevenue adRevenue);

        /// Android: void reportECommerce(io.appmetrica.analytics.ecommerce.ECommerceEvent)
        public void ReportECommerce([NotNull] ECommerceEvent ecommerce);

        /// Android: void reportError(java.lang.String, java.lang.Throwable)
        public void ReportError([NotNull] string message, [NotNull] Exception error);

        /// Android: void reportError(java.lang.String, java.lang.String, java.lang.Throwable)
        public void ReportError([NotNull] string identifier, [CanBeNull] string message = null, [CanBeNull] Exception error = null);

        /// Android: void reportEvent(java.lang.String)
        public void ReportEvent([NotNull] string eventName);

        /// Android: void reportEvent(java.lang.String, java.lang.String)
        public void ReportEvent([NotNull] string eventName, [CanBeNull] string jsonValue);

        /// Android: void reportRevenue(io.appmetrica.analytics.Revenue)
        public void ReportRevenue([NotNull] Revenue revenue);

        /// Android: void reportUnhandledException(java.lang.Throwable)
        public void ReportUnhandledException([NotNull] Exception exception);

        /// Android: void reportUserProfile(io.appmetrica.analytics.profile.UserProfile)
        public void ReportUserProfile([NotNull] UserProfile profile);

        /// Android: void resumeSession()
        public void ResumeSession();

        /// Android: void sendEventsBuffer()
        public void SendEventsBuffer();

        /// Android: void setDataSendingEnabled(boolean)
        public void SetDataSendingEnabled(bool enabled);

        /// Android: void setUserProfileID(java.lang.String)
        public void SetUserProfileID([CanBeNull] string profileID);
    }
}
