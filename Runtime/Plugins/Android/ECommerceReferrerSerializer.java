package io.appmetrica.analytics.plugin.unity;

import androidx.annotation.NonNull;
import org.json.JSONException;
import org.json.JSONObject;
import io.appmetrica.analytics.ecommerce.ECommerceReferrer;

final class ECommerceReferrerSerializer {
    private ECommerceReferrerSerializer() {}

    @NonNull
    public static ECommerceReferrer fromJsonString(@NonNull String ecommerce) throws JSONException {
        JSONObject json = new JSONObject(ecommerce);
        ECommerceReferrer event = new ECommerceReferrer();
        if (json.has("Identifier")) {
            event.setIdentifier(json.getString("Identifier"));
        }
        if (json.has("Screen")) {
            event.setScreen(ECommerceScreenSerializer.fromJsonString(json.getString("Screen")));
        }
        if (json.has("Type")) {
            event.setType(json.getString("Type"));
        }
        return event;
    }
}
