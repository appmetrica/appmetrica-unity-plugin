package io.appmetrica.analytics.plugin.unity;

import androidx.annotation.NonNull;
import org.json.JSONException;
import org.json.JSONObject;
import java.math.BigDecimal;
import io.appmetrica.analytics.ecommerce.ECommerceAmount;

final class ECommerceAmountSerializer {
    private ECommerceAmountSerializer() {}

    @NonNull
    public static ECommerceAmount fromJsonString(@NonNull String ecommerce) throws JSONException {
        JSONObject json = new JSONObject(ecommerce);
        return new ECommerceAmount(
            new BigDecimal(json.getString("Amount")),
            json.getString("Unit")
        );
    }
}
