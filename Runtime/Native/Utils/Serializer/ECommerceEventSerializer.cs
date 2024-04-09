using System.Collections.Generic;
using Io.AppMetrica.Ecommerce;
using Io.AppMetrica.Internal;
using Io.AppMetrica.Internal.Ecommerce;
using JetBrains.Annotations;

namespace Io.AppMetrica.Native.Utils.Serializer {
    internal static class ECommerceEventSerializer {
        [CanBeNull]
        public static string ToJsonString([NotNull] this ECommerceEvent self) {
            switch (self) {
                case AddCartItemECommerceEvent @event:
                    return JSONEncoder.Encode(new Dictionary<string, object> {
                        { "Type", "AddCartItemECommerceEvent" },
                        { "CartItem", @event.CartItem.ToJsonString() },
                    });
                case BeginCheckoutECommerceEvent @event:
                    return JSONEncoder.Encode(new Dictionary<string, object> {
                        { "Type", "BeginCheckoutECommerceEvent" },
                        { "Order", @event.Order.ToJsonString() },
                    });
                case PurchaseECommerceEvent @event:
                    return JSONEncoder.Encode(new Dictionary<string, object> {
                        { "Type", "PurchaseECommerceEvent" },
                        { "Order", @event.Order.ToJsonString() },
                    });
                case RemoveCartItemECommerceEvent @event:
                    return JSONEncoder.Encode(new Dictionary<string, object> {
                        { "Type", "RemoveCartItemECommerceEvent" },
                        { "CartItem", @event.CartItem.ToJsonString() },
                    });
                case ShowProductCardECommerceEvent @event:
                    return JSONEncoder.Encode(new Dictionary<string, object> {
                        { "Type", "ShowProductCardECommerceEvent" },
                        { "Product", @event.Product.ToJsonString() },
                        { "Screen", @event.Screen.ToJsonString() },
                    });
                case ShowProductDetailsECommerceEvent @event:
                    return JSONEncoder.Encode(new Dictionary<string, object> {
                        { "Type", "ShowProductDetailsECommerceEvent" },
                        { "Product", @event.Product.ToJsonString() },
                        { "Referrer", @event.Referrer?.ToJsonString() },
                    });
                case ShowScreenECommerceEvent @event:
                    return JSONEncoder.Encode(new Dictionary<string, object> {
                        { "Type", "ShowScreenECommerceEvent" },
                        { "Screen", @event.Screen.ToJsonString() },
                    });
                default:
                    return null;
            }
        }
    }
}
