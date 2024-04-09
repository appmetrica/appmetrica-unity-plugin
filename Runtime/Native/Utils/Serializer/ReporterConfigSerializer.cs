using System.Collections.Generic;
using Io.AppMetrica.Internal;
using JetBrains.Annotations;

namespace Io.AppMetrica.Native.Utils.Serializer {
    internal static class ReporterConfigSerializer {
        [NotNull]
        public static string ToJsonString([NotNull] this ReporterConfig self) {
            return JSONEncoder.Encode(new Dictionary<string, object> {
                { "ApiKey", self.ApiKey },
                { "AppEnvironment", self.AppEnvironment },
                { "DataSendingEnabled", self.DataSendingEnabled },
                { "DispatchPeriodSeconds", self.DispatchPeriodSeconds },
                { "Logs", self.Logs },
                { "MaxReportsCount", self.MaxReportsCount },
                { "MaxReportsInDatabaseCount", self.MaxReportsInDatabaseCount },
                { "SessionTimeout", self.SessionTimeout },
                { "UserProfileID", self.UserProfileID },
            });
        }
    }
}
