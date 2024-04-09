using JetBrains.Annotations;

namespace Io.AppMetrica {
    /// <summary>
    /// The class to store revenue data.
    /// <p>It enables revenue tracking from in-app purchases and other purchases in your application.</p>
    ///
    /// <p>The Revenue object should be passed to the AppMetrica server by using the <see cref="AppMetrica.ReportRevenue"/> method.</p>
    /// </summary>
    public class Revenue {
        /// <summary>
        /// Price of the products purchased in micros (price * 10^6).
        /// <p>It can be negative, e.g. for refunds.</p>
        ///
        /// <p><b>Platforms</b>: Android, iOS.</p>
        /// </summary>
        /// <example>990000 (equivalent to 0.99 in real currency)</example>
        public long PriceMicros { get; }

        /// <summary>
        /// Currency code of the purchase in the ISO 4217 format.
        /// The value should contain 3 Latin letters in uppercase.
        ///
        /// <p><b>Platforms</b>: Android, iOS.</p>
        /// </summary>
        [NotNull]
        public string Currency { get; }

        /// <summary>
        /// Additional information to be passed about the purchase.
        /// <p>It should contain the valid JSON string.</p>
        /// <p>For instance, it can be used for categorizing your products.</p>
        /// <p><b>NOTE:</b> The maximum size of the value is 30 KB.</p>
        ///
        /// <p><b>Platforms</b>: Android, iOS.</p>
        /// </summary>
        [CanBeNull]
        public string Payload { get; set; }

        /// <summary>
        /// ID of the product purchased.
        /// <p><b>NOTE:</b> The string value can contain up to 200 characters.</p>
        ///
        /// <p><b>Platforms</b>: Android, iOS.</p>
        /// </summary>
        /// <example>com.yandex.service.299</example>
        [CanBeNull]
        public string ProductID { get; set; }

        /// <summary>
        /// Quantity of products purchased.
        /// <p>The value cannot be negative. If the value is less than 0, the purchase is ignored.</p>
        /// <p><b>NOTE:</b> Revenue = quantity * price.</p>
        ///
        /// <p><b>Platforms</b>: Android, iOS.</p>
        /// </summary>
        [CanBeNull]
        public int? Quantity { get; set; }

        /// <summary>
        /// Information about the in-app purchase order from Google Play.
        ///
        /// <p><b>Platforms</b>: Android, iOS.</p>
        /// </summary>
        [CanBeNull]
        public Receipt ReceiptValue { get; set; }

        /// <summary>
        /// Initializes the Revenue object.
        /// </summary>
        /// <param name="priceMicros">Price of the products purchased. It can be negative, e.g. for refunds. EXAMPLE: 0.99</param>
        /// <param name="currency">Currency code of the purchase in the ISO 4217 format. The value should contain 3 Latin letters in uppercase. EXAMPLE: RUB</param>
        public Revenue(long priceMicros, [NotNull] string currency) {
            PriceMicros = priceMicros;
            Currency = currency;
        }

        /// <summary>
        /// The class to store in-app purchases data.
        /// <p>It is used for verifying Google Play purchases.</p>
        /// </summary>
        public class Receipt {
            /// <summary>
            /// Details about the in-app purchase order from Google Play or App Store.
            ///
            /// <p><b>Platforms</b>: Android, iOS.</p>
            /// </summary>
            [CanBeNull]
            public string Data { get; set; }

            /// <summary>
            /// Signature of the in-app purchase order from Google Play.
            ///
            /// <p><b>Platforms</b>: Android.</p>
            /// </summary>
            [CanBeNull]
            public string Signature { get; set; }

            /// <summary>
            /// Information about the in-app purchase order from App Store.
            ///
            /// <p><b>Platforms</b>: iOS.</p>
            /// </summary>
            [CanBeNull]
            public string TransactionID { get; set; }
        }
    }
}
