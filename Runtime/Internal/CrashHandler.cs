using UnityEngine;

namespace Io.AppMetrica.Internal {
    internal static class CrashHandler {
        private static bool _isAutoCrashReportingEnabled = true;
        private const string Source = "[AppMetrica] From log using Application.logMessageReceivedThreaded";

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void Init() {
            Application.logMessageReceived += HandleLog;
        }

        public static void SetAutoCrashReporting(bool? value) {
            _isAutoCrashReportingEnabled = value != false;
        }

        private static void HandleLog(string condition, string stackTrace, LogType type) {
            if (type == LogType.Exception) {
                if (_isAutoCrashReportingEnabled && AppMetrica.IsActivated()) {
                    AppMetrica.ReportExceptionFromLog(condition, stackTrace, Source);
                }
            }
        }
    }
}
