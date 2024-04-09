using JetBrains.Annotations;
using System.Collections.Generic;

namespace Io.AppMetrica.Ecommerce {
    /// <summary>
    /// Describes an order - info about a cart purchase.
    /// </summary>
    public class ECommerceOrder {
        /// <summary>
        /// List of items in the cart.
        /// 
        /// <p><b>Platforms</b>: Android, iOS.</p>
        /// </summary>
        [NotNull]
        public IEnumerable<ECommerceCartItem> CartItems { get; }

        /// <summary>
        /// Order identifier.
        /// 
        /// <p><b>Platforms</b>: Android, iOS.</p>
        /// </summary>
        [NotNull]
        public string Identifier { get; }

        /// <summary>
        /// Additional key-value structured data with various content.
        /// 
        /// <p><b>Platforms</b>: Android, iOS.</p>
        /// </summary>
        [CanBeNull]
        public IDictionary<string, string> Payload { get; set; }

        /// <summary>
        /// Creates an order.
        /// </summary>
        /// <param name="identifier">Order identifier.</param>
        /// <param name="cartItems">List of items in the cart.</param>
        public ECommerceOrder([NotNull] string identifier, [NotNull] IEnumerable<ECommerceCartItem> cartItems) {
            Identifier = identifier;
            CartItems = cartItems;
        }
    }
}
