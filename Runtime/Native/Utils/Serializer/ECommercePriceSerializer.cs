using System.Collections.Generic;
using System.Linq;
using Io.AppMetrica.Ecommerce;
using Io.AppMetrica.Internal;
using JetBrains.Annotations;

namespace Io.AppMetrica.Native.Utils.Serializer {
    internal static class ECommercePriceSerializer {
        [NotNull]
        public static string ToJsonString([NotNull] this ECommercePrice self) {
            return JSONEncoder.Encode(new Dictionary<string, object> {
                { "Fiat", self.Fiat.ToJsonString() },
                { "InternalComponents", self.InternalComponents?.Select(ECommerceAmountSerializer.ToJsonString) },
            });
        }
    }
}
