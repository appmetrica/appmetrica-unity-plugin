using Io.AppMetrica.Ecommerce;
using JetBrains.Annotations;

namespace Io.AppMetrica.Internal.Ecommerce {
    /// <summary>
    /// INTERNAL CLASS.
    /// Use <see cref="ECommerceEvent.ShowProductCardEvent">ECommerceEvent.ShowProductCardEvent()</see> for create this event.
    /// </summary>
    internal class ShowProductCardECommerceEvent : ECommerceEvent {
        [NotNull]
        public readonly ECommerceProduct Product;

        [NotNull]
        public readonly ECommerceScreen Screen;

        public ShowProductCardECommerceEvent([NotNull] ECommerceProduct product, [NotNull] ECommerceScreen screen) {
            Product = product;
            Screen = screen;
        }
    }
}
