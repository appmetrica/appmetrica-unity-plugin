using JetBrains.Annotations;
using System;
using System.Globalization;
using System.Text;

namespace Io.AppMetrica.Internal {
    internal static class NumberUtils {
        [NotNull]
        public static string SerializeMicros(long micros) {
            var builder = new StringBuilder();
            if (micros < 0) builder.Append("-");
            builder.Append(Math.Abs(micros / 1_000_000));
            builder.Append(".");
            builder.Append(Math.Abs(micros % 1_000_000).ToString().PadLeft(6, '0'));
            return builder.ToString();
        }

        [NotNull]
        public static string SerializeDouble(double value) {
            return double.IsInfinity(value) | double.IsNaN(value) ? "0" : value.ToString("F99", CultureInfo.CreateSpecificCulture("en-US"));
        }

        [NotNull]
        public static string SerializeDecimal(decimal value) {
            return value.ToString(CultureInfo.CreateSpecificCulture("en-US"));
        }
    }
}
