package io.appmetrica.analytics.plugin.unity;

import androidx.annotation.NonNull;
import org.json.JSONException;
import org.json.JSONObject;
import java.util.Iterator;
import io.appmetrica.analytics.PreloadInfo;

final class PreloadInfoSerializer {
    private PreloadInfoSerializer() {}

    @NonNull
    public static PreloadInfo fromJsonString(@NonNull String preloadInfo) throws JSONException {
        JSONObject json = new JSONObject(preloadInfo);
        PreloadInfo.Builder builder = PreloadInfo.newBuilder(json.getString("TrackingId"));

        if (json.has("AdditionalParams")) {
            JSONObject paramsJson = json.getJSONObject("AdditionalParams");
            Iterator<String> keyIterator = paramsJson.keys();
            while (keyIterator.hasNext()) {
                String key = keyIterator.next();
                builder.setAdditionalParams(key, paramsJson.getString(key));
            }
        }

        return builder.build();
    }
}
