using Io.AppMetrica.Ecommerce;
using JetBrains.Annotations;

namespace Io.AppMetrica.Internal.Ecommerce {
    /// <summary>
    /// INTERNAL CLASS.
    /// Use <see cref="ECommerceEvent.PurchaseEvent">ECommerceEvent.PurchaseEvent()</see> for create this event.
    /// </summary>
    internal class PurchaseECommerceEvent : ECommerceEvent {
        [NotNull]
        public readonly ECommerceOrder Order;

        public PurchaseECommerceEvent([NotNull] ECommerceOrder order) {
            Order = order;
        }
    }
}
