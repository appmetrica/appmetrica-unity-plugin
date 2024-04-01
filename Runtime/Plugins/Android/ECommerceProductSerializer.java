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
import io.appmetrica.analytics.ecommerce.ECommerceProduct;

final class ECommerceProductSerializer {
    private ECommerceProductSerializer() {}

    @NonNull
    public static ECommerceProduct fromJsonString(@NonNull String ecommerce) throws JSONException {
        JSONObject json = new JSONObject(ecommerce);
        ECommerceProduct event = new ECommerceProduct(
            json.getString("Sku")
        );
        if (json.has("ActualPrice")) {
            event.setActualPrice(ECommercePriceSerializer.fromJsonString(json.getString("ActualPrice")));
        }
        if (json.has("CategoriesPath")) {
            event.setCategoriesPath(getCategoriesPath(json.getJSONArray("CategoriesPath")));
        }
        if (json.has("Name")) {
            event.setName(json.getString("Name"));
        }
        if (json.has("OriginalPrice")) {
            event.setOriginalPrice(ECommercePriceSerializer.fromJsonString(json.getString("OriginalPrice")));
        }
        if (json.has("Payload")) {
            event.setPayload(getPayload(json.getJSONObject("Payload")));
        }
        if (json.has("Promocodes")) {
            event.setPromocodes(getPromocodes(json.getJSONArray("Promocodes")));
        }
        return event;
    }

    @NonNull
    private static List<String> getCategoriesPath(@NonNull JSONArray jsonArray) throws JSONException {
        List<String> categoriesPath = new ArrayList<>(jsonArray.length());
        for (int idx = 0; idx < jsonArray.length(); idx++) {
            categoriesPath.add(jsonArray.getString(idx));
        }
        return categoriesPath;
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

    @NonNull
    private static List<String> getPromocodes(@NonNull JSONArray jsonArray) throws JSONException {
        List<String> promocodes = new ArrayList<>(jsonArray.length());
        for (int idx = 0; idx < jsonArray.length(); idx++) {
            promocodes.add(jsonArray.getString(idx));
        }
        return promocodes;
    }
}

