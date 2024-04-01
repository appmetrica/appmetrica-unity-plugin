using System.Collections.Generic;
using Io.AppMetrica.Ecommerce;
using Io.AppMetrica.Internal;
using JetBrains.Annotations;

namespace Io.AppMetrica.Native.Utils.Serializer {
    internal static class ECommerceCartItemSerializer {
        [NotNull]
        public static string ToJsonString([NotNull] this ECommerceCartItem self) {
            return JSONEncoder.Encode(new Dictionary<string, object> {
                { "Product", self.Product.ToJsonString() },
                { "Quantity", self.Quantity },
                { "Referrer", self.Referrer?.ToJsonString() },
                { "Revenue", self.Revenue.ToJsonString() },
            });
        }
    }
}
