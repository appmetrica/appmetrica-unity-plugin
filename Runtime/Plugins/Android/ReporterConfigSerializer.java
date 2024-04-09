package io.appmetrica.analytics.plugin.unity;

import androidx.annotation.NonNull;
import org.json.JSONException;
import org.json.JSONObject;
import java.util.Iterator;
import io.appmetrica.analytics.ReporterConfig;

final class ReporterConfigSerializer {
    private ReporterConfigSerializer() {}

    @NonNull
    public static ReporterConfig fromJsonString(@NonNull String config) throws JSONException {
        JSONObject json = new JSONObject(config);
        ReporterConfig.Builder builder = ReporterConfig.newConfigBuilder(json.getString("ApiKey"));

        if (json.has("AppEnvironment")) {
            JSONObject env = json.getJSONObject("AppEnvironment");
            Iterator<String> iterator = env.keys();
            while (iterator.hasNext()) {
                String key = iterator.next();
                builder.withAppEnvironmentValue(key, env.getString(key));
            }
        }
        if (json.has("DataSendingEnabled")) {
            builder.withDataSendingEnabled(json.getBoolean("DataSendingEnabled"));
        }
        if (json.has("DispatchPeriodSeconds")) {
            builder.withDispatchPeriodSeconds(json.getInt("DispatchPeriodSeconds"));
        }
        if (json.optBoolean("Logs", false)) {
            builder.withLogs();
        }
        if (json.has("MaxReportsCount")) {
            builder.withMaxReportsCount(json.getInt("MaxReportsCount"));
        }
        if (json.has("MaxReportsInDatabaseCount")) {
            builder.withMaxReportsInDatabaseCount(json.getInt("MaxReportsInDatabaseCount"));
        }
        if (json.has("SessionTimeout")) {
            builder.withSessionTimeout(json.getInt("SessionTimeout"));
        }
        if (json.has("UserProfileID")) {
            builder.withUserProfileID(json.getString("UserProfileID"));
        }

        return builder.build();
    }
}
