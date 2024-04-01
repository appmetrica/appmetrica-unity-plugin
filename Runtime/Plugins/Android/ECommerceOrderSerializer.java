package io.appmetrica.analytics.plugin.unity;

import androidx.annotation.NonNull;
import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.Iterator;
import java.util.List;
import java.util.Map;
import io.appmetrica.analytics.ecommerce.ECommerceCartItem;
import io.appmetrica.analytics.ecommerce.ECommerceOrder;

final class ECommerceOrderSerializer {
    private ECommerceOrderSerializer() {}

    @NonNull
    public static ECommerceOrder fromJsonString(@NonNull String ecommerce) throws JSONException {
        JSONObject json = new JSONObject(ecommerce);
        ECommerceOrder event = new ECommerceOrder(
            json.getString("Identifier"),
            getCartItems(json.getJSONArray("CartItems"))
        );
        if (json.has("Payload")) {
            event.setPayload(getPayload(json.getJSONObject("Payload")));
        }
        return event;
    }

    @NonNull
    private static List<ECommerceCartItem> getCartItems(@NonNull JSONArray jsonArray) throws JSONException {
        List<ECommerceCartItem> cartItems = new ArrayList<>(jsonArray.length());
        for (int idx = 0; idx < jsonArray.length(); idx++) {
            cartItems.add(ECommerceCartItemSerializer.fromJsonString(jsonArray.getString(idx)));
        }
        return cartItems;
    }

    @NonNull
    private static Map<String, String> getPayload(@NonNull JSONObject json) throws JSONException {
        Map<String, String> payload = new HashMap<>(json.length());
        Iterator<String> keyIterator = json.keys();
        while (keyIterator.hasNext()) {
            String key = keyIterator.next();
            payload.put(key, json.getString(key));
        }
        return payload;
    }
}
