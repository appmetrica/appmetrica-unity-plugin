using JetBrains.Annotations;

namespace Io.AppMetrica {
    /// Android: io.appmetrica.analytics.StartupParamsItem
    public class StartupParamsItem {
        /// Android:
        ///   java.lang.String getErrorDetails()
        [CanBeNull]
        public string ErrorDetails { get; }

        /// Android:
        ///   java.lang.String getId()
        [CanBeNull]
        public string Id { get; }

        /// Android:
        ///   io.appmetrica.analytics.StartupParamsItemStatus getStatus()
        [NotNull]
        public StartupParamsItemStatus Status { get; }

        /// Android: (java.lang.String, io.appmetrica.analytics.StartupParamsItemStatus, java.lang.String)
        internal StartupParamsItem([CanBeNull] string id, [NotNull] StartupParamsItemStatus status, [CanBeNull] string errorDetails) {
            Id = id;
            Status = status;
            ErrorDetails = errorDetails;
        }
    }
}
