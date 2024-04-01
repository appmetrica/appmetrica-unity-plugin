using System.Collections.Generic;
using Io.AppMetrica.Ecommerce;
using Io.AppMetrica.Internal;
using JetBrains.Annotations;

namespace Io.AppMetrica.Native.Utils.Serializer {
    internal static class ECommerceProductSerializer {
        [NotNull]
        public static string ToJsonString([NotNull] this ECommerceProduct self) {
            return JSONEncoder.Encode(new Dictionary<string, object> {
                { "ActualPrice", self.ActualPrice?.ToJsonString() },
                { "CategoriesPath", self.CategoriesPath },
                { "Name", self.Name },
                { "OriginalPrice", self.OriginalPrice?.ToJsonString() },
                { "Payload", self.Payload },
                { "Promocodes", self.Promocodes },
                { "Sku", self.Sku },
            });
        }
    }
}
