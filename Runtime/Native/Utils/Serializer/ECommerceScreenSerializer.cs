using System.Collections.Generic;
using Io.AppMetrica.Ecommerce;
using Io.AppMetrica.Internal;
using JetBrains.Annotations;

namespace Io.AppMetrica.Native.Utils.Serializer {
    internal static class ECommerceScreenSerializer {
        [NotNull]
        public static string ToJsonString([NotNull] this ECommerceScreen self) {
            return JSONEncoder.Encode(new Dictionary<string, object> {
                { "CategoriesPath", self.CategoriesPath },
                { "Name", self.Name },
                { "Payload", self.Payload },
                { "SearchQuery", self.SearchQuery },
            });
        }
    }
}
