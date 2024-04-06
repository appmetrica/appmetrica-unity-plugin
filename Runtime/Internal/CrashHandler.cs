using UnityEngine;

namespace Io.AppMetrica.Internal {
    internal static class CrashHandler {
        private const string Source = "[AppMetrica] From log using Application.logMessageReceivedThreaded";

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
        private static void Init() {
            Application.logMessageReceived += HandleLog;
        }

        private static void HandleLog(string condition, string stackTrace, LogType type) {
            if (type == LogType.Exception) {
                if (AppMetrica.IsActivated()) {
                    AppMetrica.ReportExceptionFromLog(condition, stackTrace, Source);
                }
            }
        }
    }
}
