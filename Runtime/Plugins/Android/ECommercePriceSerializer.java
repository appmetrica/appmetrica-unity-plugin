package io.appmetrica.analytics.plugin.unity;

import androidx.annotation.NonNull;
import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;
import java.util.ArrayList;
import java.util.List;
import io.appmetrica.analytics.ecommerce.ECommerceAmount;
import io.appmetrica.analytics.ecommerce.ECommercePrice;

final class ECommercePriceSerializer {
    private ECommercePriceSerializer() {}

    @NonNull
    public static ECommercePrice fromJsonString(@NonNull String ecommerce) throws JSONException {
        JSONObject json = new JSONObject(ecommerce);
        ECommercePrice event = new ECommercePrice(
            ECommerceAmountSerializer.fromJsonString(json.getString("Fiat"))
        );
        if (json.has("InternalComponents")) {
            event.setInternalComponents(getInternalComponents(json.getJSONArray("InternalComponents")));
        }
        return event;
    }

    @NonNull
    private static List<ECommerceAmount> getInternalComponents(@NonNull JSONArray jsonArray) throws JSONException {
        List<ECommerceAmount> internalComponents = new ArrayList<>(jsonArray.length());
        for (int idx = 0; idx < jsonArray.length(); idx++) {
            internalComponents.add(ECommerceAmountSerializer.fromJsonString(jsonArray.getString(idx)));
        }
        return internalComponents;
    }
}
