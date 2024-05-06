package io.appmetrica.analytics.plugin.unity;

import androidx.annotation.NonNull;
import org.json.JSONException;
import io.appmetrica.analytics.AppMetricaConfig;

// INTERNAL CLASS
// Do not remove this class. It is needed for AppMetrica Push Unity Plugin.
public class AppMetricaPushHelper {
    private AppMetricaPushHelper() {}

    public static AppMetricaConfig getAppMetricaConfigFromUnityJsonString(@NonNull String jsonString) throws JSONException {
        return AppMetricaConfigSerializer.fromJsonString(jsonString);
    }
}
