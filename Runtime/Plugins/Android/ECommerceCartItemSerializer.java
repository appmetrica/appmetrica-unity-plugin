package io.appmetrica.analytics.plugin.unity;

import androidx.annotation.NonNull;
import org.json.JSONException;
import org.json.JSONObject;
import java.math.BigDecimal;
import io.appmetrica.analytics.ecommerce.ECommerceCartItem;

final class ECommerceCartItemSerializer {
    private ECommerceCartItemSerializer() {}

    @NonNull
    public static ECommerceCartItem fromJsonString(@NonNull String ecommerce) throws JSONException {
        JSONObject json = new JSONObject(ecommerce);
        ECommerceCartItem event = new ECommerceCartItem(
            ECommerceProductSerializer.fromJsonString(json.getString("Product")),
            ECommercePriceSerializer.fromJsonString(json.getString("Revenue")),
            new BigDecimal(json.getString("Quantity"))
        );
        if (json.has("Referrer")) {
            event.setReferrer(ECommerceReferrerSerializer.fromJsonString(json.getString("Referrer")));
        }
        return event;
    }
}
