package io.appmetrica.analytics.plugin.unity;

import androidx.annotation.NonNull;
import org.json.JSONException;
import org.json.JSONObject;
import io.appmetrica.analytics.ecommerce.ECommerceEvent;

final class ECommerceEventSerializer {
    private ECommerceEventSerializer() {}

    @NonNull
    public static ECommerceEvent fromJsonString(@NonNull String ecommerce) throws JSONException {
        JSONObject json = new JSONObject(ecommerce);
        String type = json.getString("Type");
        switch (type) {
            case "AddCartItemECommerceEvent":
                return ECommerceEvent.addCartItemEvent(
                    ECommerceCartItemSerializer.fromJsonString(json.getString("CartItem"))
                );
            case "BeginCheckoutECommerceEvent":
                return ECommerceEvent.beginCheckoutEvent(
                    ECommerceOrderSerializer.fromJsonString(json.getString("Order"))
                );
            case "PurchaseECommerceEvent":
                return ECommerceEvent.purchaseEvent(
                    ECommerceOrderSerializer.fromJsonString(json.getString("Order"))
                );
            case "RemoveCartItemECommerceEvent":
                return ECommerceEvent.removeCartItemEvent(
                    ECommerceCartItemSerializer.fromJsonString(json.getString("CartItem"))
                );
            case "ShowProductCardECommerceEvent":
                return ECommerceEvent.showProductCardEvent(
                    ECommerceProductSerializer.fromJsonString(json.getString("Product")),
                    ECommerceScreenSerializer.fromJsonString(json.getString("Screen"))
                );
            case "ShowProductDetailsECommerceEvent":
                return ECommerceEvent.showProductDetailsEvent(
                    ECommerceProductSerializer.fromJsonString(json.getString("Product")),
                    json.has("Referrer") ? ECommerceReferrerSerializer.fromJsonString(json.getString("Referrer")) : null
                );
            case "ShowScreenECommerceEvent":
                return ECommerceEvent.showScreenEvent(
                    ECommerceScreenSerializer.fromJsonString(json.getString("Screen"))
                );
        }
        throw new JSONException("Unknown ECommerce type " + type);
    }
}
