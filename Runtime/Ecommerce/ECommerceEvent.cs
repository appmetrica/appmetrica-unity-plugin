using Io.AppMetrica.Internal.Ecommerce;
using JetBrains.Annotations;

namespace Io.AppMetrica.Ecommerce {
    /// <summary>
    /// ECommerce event object.
    /// <p>Use static methods of this class to form e-commerce event.
    /// There are several different types of e-commerce events for different user actions.
    /// Each method corresponds to one specific type. See method descriptions for more info.</p>
    /// </summary>
    public abstract class ECommerceEvent {
        /// <summary>
        /// Creates e-commerce AddCartItemEvent.
        /// Use this method to report user adding an item to cart.
        /// 
        /// <p><b>Platforms</b>: Android, iOS.</p>
        /// </summary>
        /// <param name="cartItem">Item that has been added to cart.</param>
        /// <returns>e-commerce AddCartItemEvent.</returns>
        [NotNull]
        public static ECommerceEvent AddCartItemEvent([NotNull] ECommerceCartItem cartItem) {
            return new AddCartItemECommerceEvent(cartItem);
        }

        /// <summary>
        /// Creates e-commerce BeginCheckoutEvent.
        /// Use this event to report user begin checkout a purchase.
        /// 
        /// <p><b>Platforms</b>: Android, iOS.</p>
        /// </summary>
        /// <param name="order">Various info about purchase.</param>
        /// <returns>e-commerce BeginCheckoutEvent.</returns>
        [NotNull]
        public static ECommerceEvent BeginCheckoutEvent([NotNull] ECommerceOrder order) {
            return new BeginCheckoutECommerceEvent(order);
        }

        /// <summary>
        /// Creates e-commerce PurchaseEvent.
        /// Use this event to report user complete a purchase.
        /// 
        /// <p><b>Platforms</b>: Android, iOS.</p>
        /// </summary>
        /// <param name="order">Various info about purchase.</param>
        /// <returns>e-commerce PurchaseEvent.</returns>
        [NotNull]
        public static ECommerceEvent PurchaseEvent([NotNull] ECommerceOrder order) {
            return new PurchaseECommerceEvent(order);
        }

        /// <summary>
        /// Creates e-commerce RemoveCartItemEvent.
        /// Use this method to report user removing an item form cart.
        /// 
        /// <p><b>Platforms</b>: Android, iOS.</p>
        /// </summary>
        /// <param name="cartItem">Item that has been removed from cart.</param>
        /// <returns>e-commerce RemoveCartItemEvent.</returns>
        [NotNull]
        public static ECommerceEvent RemoveCartItemEvent([NotNull] ECommerceCartItem cartItem) {
            return new RemoveCartItemECommerceEvent(cartItem);
        }

        /// <summary>
        /// Creates e-commerce ShowProductCardEvent.
        /// Use this event to report user viewing product card among others in a list.
        /// Best practise is to consider product card viewed if it has been shown on screen for more than N seconds.
        /// 
        /// <p><b>Platforms</b>: Android, iOS.</p>
        /// </summary>
        /// <param name="product">Product that has been viewed.</param>
        /// <param name="screen">Screen where the product is shown.</param>
        /// <returns>e-commerce ShowProductCardEvent.</returns>
        [NotNull]
        public static ECommerceEvent ShowProductCardEvent(
            [NotNull] ECommerceProduct product,
            [NotNull] ECommerceScreen screen
        ) {
            return new ShowProductCardECommerceEvent(product, screen);
        }

        /// <summary>
        /// Creates e-commerce ShowProductDetailsEvent.
        /// Use this method to report user viewing product card by opening its own page.
        /// 
        /// <p><b>Platforms</b>: Android, iOS.</p>
        /// </summary>
        /// <param name="product">Product that has been viewed.</param>
        /// <param name="referrer">Info about the source of transition to shown product card.</param>
        /// <returns>e-commerce ShowProductDetailsEvent.</returns>
        [NotNull]
        public static ECommerceEvent ShowProductDetailsEvent(
            [NotNull] ECommerceProduct product,
            [CanBeNull] ECommerceReferrer referrer
        ) {
            return new ShowProductDetailsECommerceEvent(product, referrer);
        }

        /// <summary>
        /// Creates e-commerce ShowScreenEvent.
        /// Use this event to report user opening some page: product list, search screen, main page, etc.
        /// 
        /// <p><b>Platforms</b>: Android, iOS.</p>
        /// </summary>
        /// <param name="screen">Screen that has been opened.</param>
        /// <returns>e-commerce ShowScreenEvent.</returns>
        [NotNull]
        public static ECommerceEvent ShowScreenEvent([NotNull] ECommerceScreen screen) {
            return new ShowScreenECommerceEvent(screen);
        }
    }
}
