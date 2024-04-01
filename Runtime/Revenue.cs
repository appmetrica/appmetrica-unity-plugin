using JetBrains.Annotations;

namespace Io.AppMetrica {
    /// Android: io.appmetrica.analytics.Revenue
    public class Revenue {
        /// Android: io.appmetrica.analytics.Revenue$Receipt
        public class Receipt {
            /// <summary>
            /// <p><b>Platforms</b>: Android, iOS.</p>
            /// </summary>
            [CanBeNull]
            public string Data { get; set; }

            /// <summary>
            /// <p><b>Platforms</b>: Android.</p>
            /// </summary>
            [CanBeNull]
            public string Signature { get; set; }

            /// <summary>
            /// <p><b>Platforms</b>: iOS.</p>
            /// </summary>
            [CanBeNull]
            public string TransactionID { get; set; }

            /// Android: static io.appmetrica.analytics.Revenue$Receipt$Builder newBuilder()
            public Receipt() { }
        }

        /// <summary>
        /// <p><b>Platforms</b>: Android, iOS.</p>
        /// </summary>
        [NotNull]
        public string Currency { get; }

        /// <summary>
        /// <p><b>Platforms</b>: Android, iOS.</p>
        /// </summary>
        [CanBeNull]
        public string Payload { get; set; }

        /// <summary>
        /// <p><b>Platforms</b>: Android, iOS.</p>
        /// </summary>
        public long PriceMicros { get; }

        /// <summary>
        /// <p><b>Platforms</b>: Android, iOS.</p>
        /// </summary>
        [CanBeNull]
        public string ProductID { get; set; }

        /// <summary>
        /// <p><b>Platforms</b>: Android, iOS.</p>
        /// </summary>
        [CanBeNull]
        public int? Quantity { get; set; }

        /// <summary>
        /// <p><b>Platforms</b>: Android, iOS.</p>
        /// </summary>
        [CanBeNull]
        public Receipt ReceiptValue { get; set; }

        /// Android: static io.appmetrica.analytics.Revenue$Builder newBuilder(long, java.util.Currency)
        public Revenue(long priceMicros, [NotNull] string currency) {
            PriceMicros = priceMicros;
            Currency = currency;
        }
    }
}
