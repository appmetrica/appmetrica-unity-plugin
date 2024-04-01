using Io.AppMetrica.Ecommerce;
using JetBrains.Annotations;

namespace Io.AppMetrica.Internal.Ecommerce {
    /// <summary>
    /// INTERNAL CLASS.
    /// Use <see cref="ECommerceEvent.ShowScreenEvent">ECommerceEvent.ShowScreenEvent()</see> for create this event.
    /// </summary>
    internal class ShowScreenECommerceEvent : ECommerceEvent {
        [NotNull]
        public readonly ECommerceScreen Screen;

        public ShowScreenECommerceEvent([NotNull] ECommerceScreen screen) {
            Screen = screen;
        }
    }
}
