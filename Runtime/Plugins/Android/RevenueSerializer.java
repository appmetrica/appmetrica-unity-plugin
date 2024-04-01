package io.appmetrica.analytics.plugin.unity;

import androidx.annotation.NonNull;
import androidx.annotation.Nullable;
import org.json.JSONException;
import org.json.JSONObject;
import java.util.Currency;
import io.appmetrica.analytics.Revenue;

final class RevenueSerializer {
    private RevenueSerializer() {}

    @NonNull
    public static Revenue fromJsonString(@NonNull String revenue) throws JSONException {
        JSONObject json = new JSONObject(revenue);
        Revenue.Builder builder = Revenue.newBuilder(
            json.getLong("PriceMicros"),
            Currency.getInstance(json.getString("Currency"))
        );

        if (json.has("Payload")) {
            builder.withPayload(json.getString("Payload"));
        }
        if (json.has("ProductID")) {
            builder.withProductID(json.getString("ProductID"));
        }
        if (json.has("Quantity")) {
            builder.withQuantity(json.getInt("Quantity"));
        }
        if (json.has("ReceiptData") || json.has("Signature")) {
            Revenue.Receipt.Builder receiptBuilder = Revenue.Receipt.newBuilder();
            if (json.has("ReceiptData")) {
                receiptBuilder.withData(json.getString("ReceiptData"));
            }
            if (json.has("Signature")) {
                receiptBuilder.withSignature(json.getString("Signature"));
            }
            builder.withReceipt(receiptBuilder.build());
        }

        return builder.build();
    }
}
