using System.Collections.Generic;
using System.Linq;
using Io.AppMetrica.Ecommerce;
using Io.AppMetrica.Internal;
using JetBrains.Annotations;

namespace Io.AppMetrica.Native.Utils.Serializer {
    internal static class ECommerceOrderSerializer {
        [NotNull]
        public static string ToJsonString([NotNull] this ECommerceOrder self) {
            return JSONEncoder.Encode(new Dictionary<string, object> {
                { "CartItems", self.CartItems.Select(ECommerceCartItemSerializer.ToJsonString) },
                { "Identifier", self.Identifier },
                { "Payload", self.Payload },
            });
        }
    }
}
