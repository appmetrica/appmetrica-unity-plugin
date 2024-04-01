using Io.AppMetrica.Ecommerce;
using JetBrains.Annotations;

namespace Io.AppMetrica.Internal.Ecommerce {
    /// <summary>
    /// INTERNAL CLASS.
    /// Use <see cref="ECommerceEvent.ShowProductDetailsEvent">ECommerceEvent.ShowProductDetailsEvent()</see> for create this event.
    /// </summary>
    internal class ShowProductDetailsECommerceEvent : ECommerceEvent {
        [NotNull]
        public readonly ECommerceProduct Product;

        [CanBeNull]
        public readonly ECommerceReferrer Referrer;

        public ShowProductDetailsECommerceEvent(
            [NotNull] ECommerceProduct product,
            [CanBeNull] ECommerceReferrer referrer
        ) {
            Product = product;
            Referrer = referrer;
        }
    }
}
