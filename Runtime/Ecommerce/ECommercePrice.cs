using JetBrains.Annotations;
using System.Collections.Generic;

namespace Io.AppMetrica.Ecommerce {
    /// <summary>
    /// Describes price of a product.
    /// </summary>
    public class ECommercePrice {
        /// <summary>
        /// Amount in fiat money.
        /// 
        /// <p><b>Platforms</b>: Android, iOS.</p>
        /// </summary>
        [NotNull]
        public ECommerceAmount Fiat { get; }

        /// <summary>
        /// Sets price internal components - amounts in internal currency.
        /// 
        /// <p><b>Platforms</b>: Android, iOS.</p>
        /// </summary>
        [CanBeNull]
        public IEnumerable<ECommerceAmount> InternalComponents { get; set; }

        /// <summary>
        /// Creates a price.
        /// 
        /// <p><b>Platforms</b>: Android, iOS.</p>
        /// </summary>
        /// <param name="fiat">Amount in fiat money.</param>
        public ECommercePrice([NotNull] ECommerceAmount fiat) {
            Fiat = fiat;
        }
    }
}
