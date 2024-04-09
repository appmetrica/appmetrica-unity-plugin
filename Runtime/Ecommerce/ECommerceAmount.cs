using Io.AppMetrica.Internal;
using JetBrains.Annotations;

namespace Io.AppMetrica.Ecommerce {
    /// <summary>
    /// Describes an amount of something - number and unit.
    /// </summary>
    public class ECommerceAmount {
        /// <summary>
        /// Amount value as string.
        /// 
        /// <p><b>Platforms</b>: Android, iOS.</p>
        /// </summary>
        public string Amount { get; }

        /// <summary>
        /// Amount unit. For example, "USD" "RUB", etc.
        /// 
        /// <p><b>Platforms</b>: Android, iOS.</p>
        /// </summary>
        [NotNull]
        public string Unit { get; }

        /// <summary>
        /// Creates an amount with its value in micros.
        /// </summary>
        /// <param name="amountMicros">Amount value in micros (actual amount multiplied by 10^6).</param>
        /// <param name="unit">Amount unit. For example, "USD" "RUB", etc.</param>
        public ECommerceAmount(long amountMicros, [NotNull] string unit) {
            Amount = NumberUtils.SerializeMicros(amountMicros);
            Unit = unit;
        }

        /// <summary>
        /// Creates an amount with double value.
        /// </summary>
        /// <param name="amount">Amount value as double.</param>
        /// <param name="unit">Amount unit. For example, "USD", "RUB", etc.</param>
        public ECommerceAmount(double amount, [NotNull] string unit) {
            Amount = NumberUtils.SerializeDouble(amount);
            Unit = unit;
        }

        /// <summary>
        /// Creates an amount with decimal value.
        /// </summary>
        /// <param name="amount">Amount value as decimal.</param>
        /// <param name="unit">Amount unit. For example, "USD", "RUB", etc.</param>
        public ECommerceAmount(decimal amount, [NotNull] string unit) {
            Amount = NumberUtils.SerializeDecimal(amount);
            Unit = unit;
        }
    }
}
