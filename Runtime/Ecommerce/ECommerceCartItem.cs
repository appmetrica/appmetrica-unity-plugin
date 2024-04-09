using Io.AppMetrica.Internal;
using JetBrains.Annotations;

namespace Io.AppMetrica.Ecommerce {
    /// <summary>
    /// Describes an item in a cart.
    /// </summary>
    public class ECommerceCartItem {
        /// <summary>
        /// Item product.
        /// 
        /// <p><b>Platforms</b>: Android, iOS.</p>
        /// </summary>
        [NotNull]
        public ECommerceProduct Product { get; }

        /// <summary>
        /// Quantity of item product as string.
        /// 
        /// <p><b>Platforms</b>: Android, iOS.</p>
        /// </summary>
        public string Quantity { get; }

        /// <summary>
        /// Cart item referrer which describes a way item was added to cart.
        /// 
        /// <p><b>Platforms</b>: Android, iOS.</p>
        /// </summary>
        [CanBeNull]
        public ECommerceReferrer Referrer { get; set; }

        /// <summary>
        /// Total price of the cart item. Considers quantity, applied discounts, etc.
        /// 
        /// <p><b>Platforms</b>: Android, iOS.</p>
        /// </summary>
        [NotNull]
        public ECommercePrice Revenue { get; }

        /// <summary>
        /// Creates CartItem.
        /// </summary>
        /// <param name="product">Item product.</param>
        /// <param name="revenue">Total price of the cart item. Considers quantity, applied discounts, etc.</param>
        /// <param name="quantityMicros">Quantity of item product in micros (actual quantity multiplied by 10^6).</param>
        public ECommerceCartItem(
            [NotNull] ECommerceProduct product,
            [NotNull] ECommercePrice revenue,
            long quantityMicros
        ) {
            Product = product;
            Revenue = revenue;
            Quantity = NumberUtils.SerializeMicros(quantityMicros);
        }

        /// <summary>
        /// Creates CartItem.
        /// </summary>
        /// <param name="product">Item product.</param>
        /// <param name="revenue">Total price of the cart item. Considers quantity, applied discounts, etc.</param>
        /// <param name="quantity">Quantity of item product as double.</param>
        public ECommerceCartItem(
            [NotNull] ECommerceProduct product,
            [NotNull] ECommercePrice revenue,
            double quantity
        ) {
            Product = product;
            Revenue = revenue;
            Quantity = NumberUtils.SerializeDouble(quantity);
        }

        /// <summary>
        /// Creates CartItem.
        /// </summary>
        /// <param name="product">Item product.</param>
        /// <param name="revenue">Total price of the cart item. Considers quantity, applied discounts, etc.</param>
        /// <param name="quantity">Quantity of item product as decimal.</param>
        public ECommerceCartItem(
            [NotNull] ECommerceProduct product,
            [NotNull] ECommercePrice revenue,
            decimal quantity
        ) {
            Product = product;
            Revenue = revenue;
            Quantity = NumberUtils.SerializeDecimal(quantity);
        }
    }
}
