package io.appmetrica.analytics.plugin.unity;

import androidx.annotation.NonNull;
import androidx.annotation.Nullable;
import org.json.JSONException;
import org.json.JSONObject;
import java.math.BigDecimal;
import java.util.Currency;
import java.util.HashMap;
import java.util.Iterator;
import java.util.Map;
import io.appmetrica.analytics.AdRevenue;
import io.appmetrica.analytics.AdType;

final class AdRevenueSerializer {
    private AdRevenueSerializer() {}

    @NonNull
    public static AdRevenue fromJsonString(@NonNull String adRevenue) throws JSONException {
        JSONObject json = new JSONObject(adRevenue);
        AdRevenue.Builder builder = AdRevenue.newBuilder(
            new BigDecimal(json.getString("AdRevenue")),
            Currency.getInstance(json.getString("Currency"))
        );

        if (json.has("AdNetwork")) {
            builder.withAdNetwork(json.getString("AdNetwork"));
        }
        if (json.has("AdPlacementId")) {
            builder.withAdPlacementId(json.getString("AdPlacementId"));
        }
        if (json.has("AdPlacementName")) {
            builder.withAdPlacementName(json.getString("AdPlacementName"));
        }
        if (json.has("AdType")) {
            builder.withAdType(GetAdType(json.getString("AdType")));
        }
        if (json.has("AdUnitId")) {
            builder.withAdUnitId(json.getString("AdUnitId"));
        }
        if (json.has("AdUnitName")) {
            builder.withAdUnitName(json.getString("AdUnitName"));
        }
        if (json.has("Payload")) {
            builder.withPayload(getPayload(json.getJSONObject("Payload")));
        }
        if (json.has("Precision")) {
            builder.withPrecision(json.getString("Precision"));
        }

        return builder.build();
    }

    @Nullable
    private static AdType GetAdType(@NonNull String adTypeStr) {
        switch (adTypeStr) {
            case "Banner":
                return AdType.BANNER;
            case "Interstitial":
                return AdType.INTERSTITIAL;
            case "Mrec":
                return AdType.MREC;
            case "Native":
                return AdType.NATIVE;
            case "Other":
                return AdType.OTHER;
            case "Rewarded":
                return AdType.REWARDED;
            default:
                return null;
        }
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
