package io.appmetrica.analytics.plugin.unity;

import androidx.annotation.NonNull;
import androidx.annotation.Nullable;
import org.json.JSONException;
import org.json.JSONObject;
import java.util.Map;
import io.appmetrica.analytics.StartupParamsCallback;
import io.appmetrica.analytics.StartupParamsItem;
import io.appmetrica.analytics.StartupParamsItemStatus;

public interface StartupParamsCallbackProxy {
    void onReceive(@NonNull String result, @NonNull String errorReason);

    class Delegate implements StartupParamsCallback {
        @NonNull
        private final StartupParamsCallbackProxy proxy;

        public Delegate(@NonNull StartupParamsCallbackProxy proxy) {
            this.proxy = proxy;
        }

        @Override
        public void onReceive(@Nullable Result result) {
            try {
                proxy.onReceive(StartupParamsCallbackProxy.ResultSerializer.toJsonString(result), "");
            } catch (JSONException e) {
                AppMetricaUnityLogger.e("Failed to serialize StartupParamsCallback.onReceive parameters", e);
            }
        }

        @Override
        public void onRequestError(@NonNull Reason reason, @Nullable Result result) {
            try {
                proxy.onReceive(
                    StartupParamsCallbackProxy.ResultSerializer.toJsonString(result),
                    StartupParamsCallbackProxy.ReasonSerializer.toJsonString(reason)
                );
            } catch (JSONException e) {
                AppMetricaUnityLogger.e("Failed to serialize StartupParamsCallback.onRequestError parameters", e);
            }
        }
    }

    class ResultSerializer {
        private ResultSerializer() {}

        @NonNull
        public static String toJsonString(@Nullable StartupParamsCallback.Result result) throws JSONException {
            if (result == null) return "";

            JSONObject parametersJson = new JSONObject();
            for (Map.Entry<String, StartupParamsItem> entry : result.parameters.entrySet()) {
                if (entry.getValue() != null) {
                    parametersJson.put(entry.getKey(), StartupParamsItemSerializer.toJson(entry.getValue()));
                }
            }
            return new JSONObject()
                .put("parameters", parametersJson)
                .toString();
        }
    }

    class StartupParamsItemSerializer {
        private StartupParamsItemSerializer() {}

        @NonNull
        public static JSONObject toJson(@NonNull StartupParamsItem item) throws JSONException {
            return new JSONObject()
                .put("id", item.getId())
                .put("status", getStatus(item.getStatus()))
                .put("errorDetails", item.getErrorDetails());
        }

        @Nullable
        private static String getStatus(@NonNull StartupParamsItemStatus status) {
            switch (status) {
                case OK:
                    return "OK";
                case PROVIDER_UNAVAILABLE:
                    return "PROVIDER_UNAVAILABLE";
                case INVALID_VALUE_FROM_PROVIDER:
                    return "INVALID_VALUE_FROM_PROVIDER";
                case NETWORK_ERROR:
                    return "NETWORK_ERROR";
                case FEATURE_DISABLED:
                    return "FEATURE_DISABLED";
                case UNKNOWN_ERROR:
                    return "UNKNOWN_ERROR";
            }
            return null;
        }
    }

    class ReasonSerializer {
        private ReasonSerializer() {}

        @NonNull
        public static String toJsonString(@Nullable StartupParamsCallback.Reason result) throws JSONException {
            if (result == null) return "";
            return new JSONObject()
                .put("value", result.value)
                .toString();
        }
    }
}
