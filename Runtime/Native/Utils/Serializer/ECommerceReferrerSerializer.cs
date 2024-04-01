using System.Collections.Generic;
using Io.AppMetrica.Ecommerce;
using Io.AppMetrica.Internal;
using JetBrains.Annotations;

namespace Io.AppMetrica.Native.Utils.Serializer {
    internal static class ECommerceReferrerSerializer {
        [NotNull]
        public static string ToJsonString([NotNull] this ECommerceReferrer self) {
            return JSONEncoder.Encode(new Dictionary<string, object> {
                { "Identifier", self.Identifier },
                { "Screen", self.Screen?.ToJsonString() },
                { "Type", self.Type },
            });
        }
    }
}
