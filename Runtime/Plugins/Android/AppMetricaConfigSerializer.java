package io.appmetrica.analytics.plugin.unity;

import androidx.annotation.NonNull;
import org.json.JSONException;
import org.json.JSONObject;
import java.util.Iterator;
import io.appmetrica.analytics.AppMetricaConfig;

final class AppMetricaConfigSerializer {
    private AppMetricaConfigSerializer() {
    }

    @NonNull
    public static AppMetricaConfig fromJsonString(@NonNull String config) throws JSONException {
        JSONObject json = new JSONObject(config);
        AppMetricaConfig.Builder builder = AppMetricaConfig.newConfigBuilder(json.getString("ApiKey"));

        if (json.has("AppBuildNumber")) {
            builder.withAppBuildNumber(json.getInt("AppBuildNumber"));
        }
        if (json.has("AppEnvironment")) {
            JSONObject env = json.getJSONObject("AppEnvironment");
            Iterator<String> iterator = env.keys();
            while (iterator.hasNext()) {
                String key = iterator.next();
                builder.withAppEnvironmentValue(key, env.getString(key));
            }
        }
        if (json.has("AppOpenTrackingEnabled")) {
            builder.withAppOpenTrackingEnabled(json.getBoolean("AppOpenTrackingEnabled"));
        }
        if (json.has("AppVersion")) {
            builder.withAppVersion(json.getString("AppVersion"));
        }
        if (json.has("CrashReporting")) {
            builder.withCrashReporting(json.getBoolean("CrashReporting"));
        }
        if (json.has("DataSendingEnabled")) {
            builder.withDataSendingEnabled(json.getBoolean("DataSendingEnabled"));
        }
        if (json.has("DeviceType")) {
            builder.withDeviceType(json.getString("DeviceType"));
        }
        if (json.has("DispatchPeriodSeconds")) {
            builder.withDispatchPeriodSeconds(json.getInt("DispatchPeriodSeconds"));
        }
        if (json.has("ErrorEnvironment")) {
            JSONObject env = json.getJSONObject("ErrorEnvironment");
            Iterator<String> iterator = env.keys();
            while (iterator.hasNext()) {
                String key = iterator.next();
                builder.withErrorEnvironmentValue(key, env.getString(key));
            }
        }
        if (json.has("FirstActivationAsUpdate")) {
            builder.handleFirstActivationAsUpdate(json.getBoolean("FirstActivationAsUpdate"));
        }
        if (json.has("Location")) {
            builder.withLocation(LocationSerializer.fromJsonString(json.getString("Location")));
        }
        if (json.has("LocationTracking")) {
            builder.withLocationTracking(json.getBoolean("LocationTracking"));
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
        if (json.has("NativeCrashReporting")) {
            builder.withNativeCrashReporting(json.getBoolean("NativeCrashReporting"));
        }
        if (json.has("PreloadInfo")) {
            builder.withPreloadInfo(PreloadInfoSerializer.fromJsonString(json.getString("PreloadInfo")));
        }
        if (json.has("RevenueAutoTrackingEnabled")) {
            builder.withRevenueAutoTrackingEnabled(json.getBoolean("RevenueAutoTrackingEnabled"));
        }
        if (json.has("SessionTimeout")) {
            builder.withSessionTimeout(json.getInt("SessionTimeout"));
        }
        if (json.has("SessionsAutoTrackingEnabled")) {
            builder.withSessionsAutoTrackingEnabled(json.getBoolean("SessionsAutoTrackingEnabled"));
        }
        if (json.has("UserProfileID")) {
            builder.withUserProfileID(json.getString("UserProfileID"));
        }

        return builder.build();
    }
}
