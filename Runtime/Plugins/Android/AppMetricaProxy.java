package io.appmetrica.analytics.plugin.unity;

import android.app.Activity;
import androidx.annotation.NonNull;
import androidx.annotation.Nullable;
import com.unity3d.player.UnityPlayer;
import org.json.JSONException;
import org.json.JSONObject;
import java.util.Arrays;
import java.util.HashSet;
import java.util.Set;
import io.appmetrica.analytics.AppMetrica;
import io.appmetrica.analytics.AppMetricaConfig;
import io.appmetrica.analytics.ModulesFacade;
import io.appmetrica.analytics.StartupParamsCallback;
import io.appmetrica.analytics.plugins.PluginErrorDetails;

public final class AppMetricaProxy {
    private static final Set<Object> callbacks = new HashSet<>();

    private AppMetricaProxy() {}

    public static void activate(@NonNull String configStr) {
        try {
            AppMetricaConfig config = AppMetricaConfigSerializer.fromJsonString(configStr);
            AppMetrica.activate(getActivity(), config);
            if (config.sessionsAutoTrackingEnabled == null || config.sessionsAutoTrackingEnabled) {
                AppMetrica.resumeSession(UnityPlayer.currentActivity);
            }
        } catch (JSONException e) {
            AppMetricaUnityLogger.e("Failed to activate AppMetrica. Config was parsed with error.", e);
        }
    }

    public static void activateReporter(@NonNull String config) {
        try {
            AppMetrica.activateReporter(getActivity(), ReporterConfigSerializer.fromJsonString(config));
        } catch (JSONException e) {
            AppMetricaUnityLogger.e("Failed to activate Reporter. Config was parsed with error.", e);
        }
    }

    public static void clearAppEnvironment() {
        AppMetrica.clearAppEnvironment();
    }

    @Nullable
    public static String getDeviceId() {
        return AppMetrica.getDeviceId(getActivity());
    }

    @NonNull
    public static String getLibraryVersion() {
        return AppMetrica.getLibraryVersion();
    }

    @Nullable
    public static String getUuid() {
        return AppMetrica.getUuid(getActivity());
    }

    public static boolean isActivated() {
        return ModulesFacade.isActivatedForApp();
    }

    public static void pauseSession() {
        AppMetrica.pauseSession(UnityPlayer.currentActivity);
    }

    public static void putAppEnvironmentValue(@NonNull String key, @Nullable String value) {
        AppMetrica.putAppEnvironmentValue(key, value);
    }

    public static void putErrorEnvironmentValue(@NonNull String key, @Nullable String value) {
        AppMetrica.putErrorEnvironmentValue(key, value);
    }

    public static void reportAdRevenue(@NonNull String adRevenue) {
        try {
            AppMetrica.reportAdRevenue(AdRevenueSerializer.fromJsonString(adRevenue));
        } catch (JSONException e) {
            AppMetricaUnityLogger.e("Failed to report AdRevenue. Data was parsed with error", e);
        }
    }

    public static void reportAppOpen(@NonNull String deeplink) {
        AppMetrica.reportAppOpen(deeplink);
    }

    public static void reportECommerce(@NonNull String ecommerce) {
        try {
            AppMetrica.reportECommerce(ECommerceEventSerializer.fromJsonString(ecommerce));
        } catch (JSONException e) {
            AppMetricaUnityLogger.e("Failed to report ECommerce. Data was parsed with error", e);
        }
    }

    public static void reportErrorWithoutIdentifier(@NonNull String message, @NonNull String errorJson) {
        try {
            PluginErrorDetails error = ExceptionSerializer.fromJsonString(errorJson);
            if (error.getStacktrace().isEmpty()) {
                AppMetrica.getPluginExtension().reportError("Errors without stacktrace", message, error);
            } else {
                AppMetrica.getPluginExtension().reportError(error, message);
            }
        } catch (JSONException e) {
            AppMetricaUnityLogger.e("Failed to report error. Data was parsed with error", e);
        }
    }

    public static void reportError(@NonNull String identifier, @Nullable String message, @Nullable String error) {
        try {
            PluginErrorDetails errorDetails = error != null ? ExceptionSerializer.fromJsonString(error) : null;
            AppMetrica.getPluginExtension().reportError(identifier, message, errorDetails);
        } catch (JSONException e) {
            AppMetricaUnityLogger.e("Failed to report error. Data was parsed with error", e);
        }
    }

    public static void reportEvent(@NonNull String eventName, @Nullable String jsonValue) {
        AppMetrica.reportEvent(eventName, jsonValue);
    }

    public static void reportExternalAttribution(@NonNull String source, @NonNull String value) {
        ModulesFacade.reportExternalAttribution(ExternalAttributionSerializer.getSourceId(source), value);
    }

    public static void reportRevenue(@NonNull String revenue) {
        try {
            AppMetrica.reportRevenue(RevenueSerializer.fromJsonString(revenue));
        } catch (JSONException e) {
            AppMetricaUnityLogger.e("Failed to report Revenue. Data was parsed with error", e);
        }
    }

    public static void reportUnhandledException(@NonNull String exception) {
        try {
            AppMetrica.getPluginExtension().reportUnhandledException(ExceptionSerializer.fromJsonString(exception));
        } catch (JSONException e) {
            AppMetricaUnityLogger.e("Failed to report unhandled exception. Data was parsed with error", e);
        }
    }

    public static void reportUserProfile(@NonNull String profile) {
        try {
            AppMetrica.reportUserProfile(UserProfileSerializer.fromJsonString(profile));
        } catch (JSONException e) {
            AppMetricaUnityLogger.e("Failed to report UserProfile. Data was parsed with error", e);
        }
    }

    public static void requestDeferredDeeplink(@NonNull DeferredDeeplinkListenerProxy callback) {
        AppMetrica.requestDeferredDeeplink(new DeferredDeeplinkListenerProxy.Delegate(callback));
    }

    public static void requestDeferredDeeplinkParameters(@NonNull DeferredDeeplinkParametersListenerProxy callback) {
        AppMetrica.requestDeferredDeeplinkParameters(new DeferredDeeplinkParametersListenerProxy.Delegate(callback));
    }

    public static void requestStartupParams(@NonNull StartupParamsCallbackProxy callback, @NonNull String[] identifiers) {
        final StartupParamsCallback nativeCallback = new StartupParamsCallbackProxy.Delegate(callback) {
            @Override
            public void onReceive(@Nullable Result result) {
                super.onReceive(result);
                callbacks.remove(this);
            }

            @Override
            public void onRequestError(@NonNull Reason reason, @Nullable Result result) {
                super.onRequestError(reason, result);
                callbacks.remove(this);
            }
        };
        callbacks.add(nativeCallback);
        AppMetrica.requestStartupParams(getActivity(), nativeCallback, Arrays.asList(identifiers));
    }

    public static void resumeSession() {
        AppMetrica.resumeSession(UnityPlayer.currentActivity);
    }

    public static void sendEventsBuffer() {
        AppMetrica.sendEventsBuffer();
    }

    public static void setDataSendingEnabled(boolean enabled) {
        AppMetrica.setDataSendingEnabled(enabled);
    }

    public static void setLocation(@Nullable String location) {
        try {
            AppMetrica.setLocation(location == null ? null : LocationSerializer.fromJsonString(location));
        } catch (JSONException e) {
            AppMetricaUnityLogger.e("Failed to set custom location. Data was parsed with error", e);
        }
    }

    public static void setLocationTracking(boolean enabled) {
        AppMetrica.setLocationTracking(enabled);
    }

    public static void setUserProfileID(@Nullable String userProfileId) {
        AppMetrica.setUserProfileID(userProfileId);
    }

    public static void touchReporter(@NonNull String apiKey) {
        AppMetrica.getReporter(getActivity(), apiKey);
    }

    @NonNull
    private static Activity getActivity() {
        // TODO: check UnityPlayer.currentActivity != null
        return UnityPlayer.currentActivity;
    }
}
