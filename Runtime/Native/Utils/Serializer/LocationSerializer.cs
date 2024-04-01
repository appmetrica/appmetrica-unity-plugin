using Io.AppMetrica.Internal;
using JetBrains.Annotations;
using System.Collections.Generic;

namespace Io.AppMetrica.Native.Utils.Serializer {
    internal static class LocationSerializer {
        [NotNull]
        public static string ToJsonString(this Location self) {
            return JSONEncoder.Encode(new Dictionary<string, object> {
                { "Latitude", self.Latitude },
                { "Longitude", self.Longitude },
            });
        }
    }
}
