using System.Collections.Generic;
using Io.AppMetrica.Internal;
using JetBrains.Annotations;

namespace Io.AppMetrica.Native.Utils.Serializer {
    internal static class AppMetricaConfigSerializer {
        [NotNull]
        public static string ToJsonString([NotNull] this AppMetricaConfig self) {
            return JSONEncoder.Encode(new Dictionary<string, object> {
                { "ApiKey", self.ApiKey },
                { "AppBuildNumber", self.AppBuildNumber },
                { "AppEnvironment", self.AppEnvironment },
                { "AppOpenTrackingEnabled", self.AppOpenTrackingEnabled },
                { "AppVersion", self.AppVersion },
                { "CrashReporting", self.CrashReporting },
                { "DataSendingEnabled", self.DataSendingEnabled },
                { "DeviceType", self.DeviceType },
                { "DispatchPeriodSeconds", self.DispatchPeriodSeconds },
                { "ErrorEnvironment", self.ErrorEnvironment },
                { "FirstActivationAsUpdate", self.FirstActivationAsUpdate },
                { "Location", self.Location?.ToJsonString() },
                { "LocationTracking", self.LocationTracking },
                { "Logs", self.Logs },
                { "MaxReportsCount", self.MaxReportsCount },
                { "MaxReportsInDatabaseCount", self.MaxReportsInDatabaseCount },
                { "NativeCrashReporting", self.NativeCrashReporting },
                { "PreloadInfo", self.PreloadInfo?.ToJsonString() },
                { "RevenueAutoTrackingEnabled", self.RevenueAutoTrackingEnabled },
                { "SessionTimeout", self.SessionTimeout },
                { "SessionsAutoTrackingEnabled", self.SessionsAutoTrackingEnabled },
                { "UserProfileID", self.UserProfileID },
            });
        }
    }
}
