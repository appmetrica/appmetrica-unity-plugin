using Io.AppMetrica.Ecommerce;
using JetBrains.Annotations;

namespace Io.AppMetrica.Internal.Ecommerce {
    /// <summary>
    /// INTERNAL CLASS.
    /// Use <see cref="ECommerceEvent.RemoveCartItemEvent">ECommerceEvent.RemoveCartItemEvent()</see> for create this event.
    /// </summary>
    internal class RemoveCartItemECommerceEvent : ECommerceEvent {
        [NotNull]
        public readonly ECommerceCartItem CartItem;

        public RemoveCartItemECommerceEvent([NotNull] ECommerceCartItem cartItem) {
            CartItem = cartItem;
        }
    }
}
