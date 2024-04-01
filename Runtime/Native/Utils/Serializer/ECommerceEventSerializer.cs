using System.Collections.Generic;
using Io.AppMetrica.Ecommerce;
using Io.AppMetrica.Internal;
using Io.AppMetrica.Internal.Ecommerce;
using JetBrains.Annotations;

namespace Io.AppMetrica.Native.Utils.Serializer {
    internal static class ECommerceEventSerializer {
        [CanBeNull]
        public static string ToJsonString([NotNull] this ECommerceEvent self) {
            return self switch {
                AddCartItemECommerceEvent @event =>
                    JSONEncoder.Encode(new Dictionary<string, object> {
                        { "Type", "AddCartItemECommerceEvent" },
                        { "CartItem", @event.CartItem.ToJsonString() },
                    }),
                BeginCheckoutECommerceEvent @event =>
                    JSONEncoder.Encode(new Dictionary<string, object> {
                        { "Type", "BeginCheckoutECommerceEvent" },
                        { "Order", @event.Order.ToJsonString() },
                    }),
                PurchaseECommerceEvent @event =>
                    JSONEncoder.Encode(new Dictionary<string, object> {
                        { "Type", "PurchaseECommerceEvent" },
                        { "Order", @event.Order.ToJsonString() },
                    }),
                RemoveCartItemECommerceEvent @event =>
                    JSONEncoder.Encode(new Dictionary<string, object> {
                        { "Type", "RemoveCartItemECommerceEvent" },
                        { "CartItem", @event.CartItem.ToJsonString() },
                    }),
                ShowProductCardECommerceEvent @event =>
                    JSONEncoder.Encode(new Dictionary<string, object> {
                        { "Type", "ShowProductCardECommerceEvent" },
                        { "Product", @event.Product.ToJsonString() },
                        { "Screen", @event.Screen.ToJsonString() },
                    }),
                ShowProductDetailsECommerceEvent @event =>
                    JSONEncoder.Encode(new Dictionary<string, object> {
                        { "Type", "ShowProductDetailsECommerceEvent" },
                        { "Product", @event.Product.ToJsonString() },
                        { "Referrer", @event.Referrer?.ToJsonString() },
                    }),
                ShowScreenECommerceEvent @event =>
                    JSONEncoder.Encode(new Dictionary<string, object> {
                        { "Type", "ShowScreenECommerceEvent" },
                        { "Screen", @event.Screen.ToJsonString() },
                    }),
                _ => null,
            };
        }
    }
}
