using JetBrains.Annotations;
using System.Collections.Generic;

namespace Io.AppMetrica.Ecommerce {
    /// <summary>
    /// Describes a product.
    /// </summary>
    public class ECommerceProduct {
        /// <summary>
        /// Actual price of the product - price after all discounts and promocodes are applied.
        /// 
        /// <p><b>Platforms</b>: Android, iOS.</p>
        /// </summary>
        [CanBeNull]
        public ECommercePrice ActualPrice { get; set; }

        /// <summary>
        /// Categories-wise path to the product.
        /// 
        /// <p><b>Platforms</b>: Android, iOS.</p>
        /// </summary>
        [CanBeNull]
        public IEnumerable<string> CategoriesPath { get; set; }

        /// <summary>
        /// Name of the product.
        /// 
        /// <p><b>Platforms</b>: Android, iOS.</p>
        /// </summary>
        [CanBeNull]
        public string Name { get; set; }

        /// <summary>
        /// Original price of the product.
        /// 
        /// <p><b>Platforms</b>: Android, iOS.</p>
        /// </summary>
        [CanBeNull]
        public ECommercePrice OriginalPrice { get; set; }

        /// <summary>
        /// Additional key-value structured data with various content.
        /// 
        /// <p><b>Platforms</b>: Android, iOS.</p>
        /// </summary>
        [CanBeNull]
        public IDictionary<string, string> Payload { get; set; }

        /// <summary>
        /// List of promocodes applied to the product.
        /// 
        /// <p><b>Platforms</b>: Android, iOS.</p>
        /// </summary>
        [CanBeNull]
        public IEnumerable<string> Promocodes { get; set; }

        /// <summary>
        /// Product SKU (Stock Keeping Unit).
        /// 
        /// <p><b>Platforms</b>: Android, iOS.</p>
        /// </summary>
        [NotNull]
        public string Sku { get; }

        /// <summary>
        /// Creates a product.
        /// </summary>
        /// <param name="sku">product SKU (Stock Keeping Unit).</param>
        public ECommerceProduct([NotNull] string sku) {
            Sku = sku;
        }
    }
}
