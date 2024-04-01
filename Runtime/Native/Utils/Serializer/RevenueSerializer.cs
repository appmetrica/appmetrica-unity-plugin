using System.Collections.Generic;
using Io.AppMetrica.Internal;
using JetBrains.Annotations;

namespace Io.AppMetrica.Native.Utils.Serializer {
    internal static class RevenueSerializer {
        [NotNull]
        public static string ToJsonString([NotNull] this Revenue self) {
            return JSONEncoder.Encode(new Dictionary<string, object> {
                { "Currency", self.Currency },
                { "Payload", self.Payload },
                { "PriceMicros", self.PriceMicros },
                { "ProductID", self.ProductID },
                { "Quantity", self.Quantity },
                { "ReceiptData", self.ReceiptValue?.Data },
                { "Signature", self.ReceiptValue?.Signature },
                { "TransactionID", self.ReceiptValue?.TransactionID },
            });
        }
    }
}
