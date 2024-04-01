using Io.AppMetrica.Internal;
using JetBrains.Annotations;
using System.Collections.Generic;

namespace Io.AppMetrica.Native.Utils.Serializer {
    internal static class PreloadInfoSerializer {
        [NotNull]
        public static string ToJsonString([NotNull] this PreloadInfo self) {
            return JSONEncoder.Encode(new Dictionary<string, object> {
                { "AdditionalParams", self.AdditionalParams },
                { "TrackingId", self.TrackingId },
            });
        }
    }
}
