using System.Collections.Generic;
using Io.AppMetrica.Ecommerce;
using Io.AppMetrica.Internal;
using JetBrains.Annotations;

namespace Io.AppMetrica.Native.Utils.Serializer {
    internal static class ECommerceAmountSerializer {
        [NotNull]
        public static string ToJsonString([NotNull] this ECommerceAmount self) {
            return JSONEncoder.Encode(new Dictionary<string, object> {
                { "Amount", self.Amount },
                { "Unit", self.Unit },
            });
        }
    }
}
