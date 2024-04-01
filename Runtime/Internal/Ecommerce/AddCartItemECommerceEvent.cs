using Io.AppMetrica.Ecommerce;
using JetBrains.Annotations;

namespace Io.AppMetrica.Internal.Ecommerce {
    /// <summary>
    /// INTERNAL CLASS.
    /// Use <see cref="ECommerceEvent.AddCartItemEvent">ECommerceEvent.AddCartItemEvent()</see> for create this event.
    /// </summary>
    internal class AddCartItemECommerceEvent : ECommerceEvent {
        [NotNull]
        public readonly ECommerceCartItem CartItem;

        public AddCartItemECommerceEvent([NotNull] ECommerceCartItem cartItem) {
            CartItem = cartItem;
        }
    }
}
