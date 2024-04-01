package io.appmetrica.analytics.plugin.unity;

import androidx.annotation.NonNull;
import androidx.annotation.Nullable;
import com.unity3d.player.UnityPlayer;
import org.json.JSONException;
import io.appmetrica.analytics.AppMetrica;
import io.appmetrica.analytics.IReporter;
import io.appmetrica.analytics.plugins.PluginErrorDetails;

public final class ReporterProxy {
    private ReporterProxy() {}

    public static void clearAppEnvironment(@NonNull String apiKey) {
        getReporter(apiKey).clearAppEnvironment();
    }

    public static void pauseSession(@NonNull String apiKey) {
        getReporter(apiKey).pauseSession();
    }

    public static void putAppEnvironmentValue(@NonNull String apiKey, @NonNull String key, @Nullable String value) {
        getReporter(apiKey).putAppEnvironmentValue(key, value);
    }

    public static void reportAdRevenue(@NonNull String apiKey, @NonNull String adRevenue) {
        try {
            getReporter(apiKey).reportAdRevenue(AdRevenueSerializer.fromJsonString(adRevenue));
        } catch (JSONException e) {
            AppMetricaUnityLogger.e("Failed to report AdRevenue. Data was parsed with error", e);
        }
    }

    public static void reportECommerce(@NonNull String apiKey, @NonNull String ecommerce) {
        try {
            getReporter(apiKey).reportECommerce(ECommerceEventSerializer.fromJsonString(ecommerce));
        } catch (JSONException e) {
            AppMetricaUnityLogger.e("Failed to report ECommerce. Data was parsed with error", e);
        }
    }

    public static void reportErrorWithoutIdentifier(@NonNull String apiKey, @NonNull String message, @NonNull String errorJson) {
        try {
            PluginErrorDetails error = ExceptionSerializer.fromJsonString(errorJson);
            if (error.getStacktrace().isEmpty()) {
                getReporter(apiKey).getPluginExtension().reportError("Errors without stacktrace", message, error);
            } else {
                getReporter(apiKey).getPluginExtension().reportError(error, message);
            }
        } catch (JSONException e) {
            AppMetricaUnityLogger.e("Failed to report error. Data was parsed with error", e);
        }
    }

    public static void reportError(@NonNull String apiKey, @NonNull String identifier, @Nullable String message, @Nullable String error) {
        try {
            PluginErrorDetails errorDetails = error != null ? ExceptionSerializer.fromJsonString(error) : null;
            getReporter(apiKey).getPluginExtension().reportError(identifier, message, errorDetails);
        } catch (JSONException e) {
            AppMetricaUnityLogger.e("Failed to report error. Data was parsed with error", e);
        }
    }

    public static void reportEvent(@NonNull String apiKey, @NonNull String eventName, @Nullable String jsonValue) {
        getReporter(apiKey).reportEvent(eventName, jsonValue);
    }

    public static void reportRevenue(@NonNull String apiKey, @NonNull String revenue) {
        try {
            getReporter(apiKey).reportRevenue(RevenueSerializer.fromJsonString(revenue));
        } catch (JSONException e) {
            AppMetricaUnityLogger.e("Failed to report Revenue. Data was parsed with error", e);
        }
    }

    public static void reportUnhandledException(@NonNull String apiKey, @NonNull String exception) {
        try {
            getReporter(apiKey).getPluginExtension().reportUnhandledException(ExceptionSerializer.fromJsonString(exception));
        } catch (JSONException e) {
            AppMetricaUnityLogger.e("Failed to report unhandled exception. Data was parsed with error", e);
        }
    }

    public static void reportUserProfile(@NonNull String apiKey, @NonNull String profile) {
        try {
            getReporter(apiKey).reportUserProfile(UserProfileSerializer.fromJsonString(profile));
        } catch (JSONException e) {
            AppMetricaUnityLogger.e("Failed to report UserProfile. Data was parsed with error", e);
        }
    }

    public static void resumeSession(@NonNull String apiKey) {
        getReporter(apiKey).resumeSession();
    }

    public static void sendEventsBuffer(@NonNull String apiKey) {
        getReporter(apiKey).sendEventsBuffer();
    }

    public static void setDataSendingEnabled(@NonNull String apiKey, boolean enabled) {
        getReporter(apiKey).setDataSendingEnabled(enabled);
    }

    public static void setUserProfileID(@NonNull String apiKey, @Nullable String userProfileId) {
        getReporter(apiKey).setUserProfileID(userProfileId);
    }

    @NonNull
    private static IReporter getReporter(@NonNull String apiKey) {
        // TODO: check UnityPlayer.currentActivity != null
        return AppMetrica.getReporter(UnityPlayer.currentActivity, apiKey);
    }
}
