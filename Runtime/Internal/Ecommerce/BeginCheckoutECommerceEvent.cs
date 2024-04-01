using Io.AppMetrica.Ecommerce;
using JetBrains.Annotations;

namespace Io.AppMetrica.Internal.Ecommerce {
    /// <summary>
    /// INTERNAL CLASS.
    /// Use <see cref="ECommerceEvent.BeginCheckoutEvent">ECommerceEvent.BeginCheckoutEvent()</see> for create this event.
    /// </summary>
    internal class BeginCheckoutECommerceEvent : ECommerceEvent {
        [NotNull]
        public readonly ECommerceOrder Order;

        public BeginCheckoutECommerceEvent([NotNull] ECommerceOrder order) {
            Order = order;
        }
    }
}
