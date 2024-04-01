using JetBrains.Annotations;

namespace Io.AppMetrica {
    /// <summary>
    /// Advertising identifiers (google and huawei) information.
    /// Information about one identifier is independent on information about others.
    ///
    /// To get advertising identifiers use TODO: where method? method.
    /// </summary>
    public class AdvIdentifiersResult {
        /// <summary>
        /// Object of this class holds information about one specific identifier.
        /// </summary>
        public class AdvId {
            /// <summary>
            /// Value of advertising identifier.
            /// Can be null if it could not be retrieved.
            /// See <see cref="AdvId.Details"/> and <see cref="AdvId.ErrorExplanation"/> for details.
            /// </summary>
            [CanBeNull]
            public string AdvIdValue { get; }

            /// <summary>
            /// Information about the request status.
            /// States if identifier was retrieved without problems or there were some errors.
            /// </summary>
            [NotNull]
            public Details Details { get; }

            /// <summary>
            /// A string that explains what exactly went wrong while retrieving identifier.
            /// It will be null if <see cref="AdvId.Details"/> is <see cref="AdvIdentifiersResult.Details.Ok"/>
            /// </summary>
            [CanBeNull]
            public string ErrorExplanation { get; }

            /// <summary>
            /// INTERNAL CONSTRUCTOR.
            /// Creates a AdvId.
            /// </summary>
            /// <param name="advId">Value of advertising identifier.</param>
            /// <param name="details">Information about the request status.</param>
            /// <param name="errorExplanation">A string that explains what exactly went wrong while retrieving identifier.</param>
            internal AdvId([CanBeNull] string advId, [NotNull] Details details, [CanBeNull] string errorExplanation) {
                AdvIdValue = advId;
                Details = details;
                ErrorExplanation = errorExplanation;
            }
        }

        /// <summary>
        /// Describes information about request status.
        /// </summary>
        public enum Details {
            /// <summary>
            /// Identifier could not be retrieved because access to adv_id is forbidden by startup.
            /// </summary>
            FeatureDisabled,

            /// <summary>
            /// Identifier could not be retrieved because providing services are either absent or unavailable.
            /// </summary>
            IdentifierProviderUnavailable,

            /// <summary>
            /// Identifier could not be retrieved due to some unknown error.
            /// </summary>
            InternalError,

            /// <summary>
            /// Identifier was retrieved successfully, but its value equals to default value,
            /// so it can't be used to identify device.
            /// </summary>
            InvalidAdvId,

            /// <summary>
            /// Identifier could not be retrieved because there was no startup yet
            /// so we cannot know if access to adv_id is forbidden.
            /// </summary>
            NoStartup,

            /// <summary>
            /// Identifier was retrieved and the value in <see cref="AdvId.AdvIdValue"/> is not null and valid.
            /// </summary>
            Ok
        }

        /// <summary>
        /// Information about google adv_id.
        /// </summary>
        [NotNull]
        public AdvId GoogleAdvId { get; }

        /// <summary>
        /// Information about huawei oaid.
        /// </summary>
        [NotNull]
        public AdvId HuaweiAdvId { get; }

        /// <summary>
        /// Information about yandex adv_id.
        /// </summary>
        [NotNull]
        public AdvId YandexAdvId { get; }

        /// <summary>
        /// INTERNAL CONSTRUCTOR.
        /// Creates a AdvIdentifiersResult.
        /// TODO: where get method?.
        /// </summary>
        /// <param name="googleAdvId">Information about google adv_id.</param>
        /// <param name="huaweiAdvId">Information about huawei oaid.</param>
        /// <param name="yandexAdvId">Information about yandex adv_id.</param>
        internal AdvIdentifiersResult(
            [NotNull] AdvId googleAdvId,
            [NotNull] AdvId huaweiAdvId,
            [NotNull] AdvId yandexAdvId
        ) {
            GoogleAdvId = googleAdvId;
            HuaweiAdvId = huaweiAdvId;
            YandexAdvId = yandexAdvId;
        }
    }
}
