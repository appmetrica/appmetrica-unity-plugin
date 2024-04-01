package io.appmetrica.analytics.plugin.unity;

import androidx.annotation.NonNull;
import androidx.annotation.Nullable;
import org.jetbrains.annotations.NotNull;
import org.json.JSONException;
import org.json.JSONObject;
import java.util.Map;
import io.appmetrica.analytics.DeferredDeeplinkListener;
import io.appmetrica.analytics.DeferredDeeplinkParametersListener;
import io.appmetrica.analytics.StartupParamsCallback;
import io.appmetrica.analytics.StartupParamsItem;
import io.appmetrica.analytics.StartupParamsItemStatus;

public interface DeferredDeeplinkParametersListenerProxy {
    void onParametersLoaded(@NotNull String parameters);

    void onError(@NotNull String error, @NotNull String referrer);

    class Delegate implements DeferredDeeplinkParametersListener {
        @NonNull
        private final DeferredDeeplinkParametersListenerProxy proxy;

        public Delegate(@NonNull DeferredDeeplinkParametersListenerProxy proxy) {
            this.proxy = proxy;
        }

        @Override
        public void onParametersLoaded(@NonNull Map<String, String> map) {
            proxy.onParametersLoaded(new JSONObject(map).toString());
        }

        @Override
        public void onError(@NonNull Error error, @NonNull String referrer) {
            proxy.onError(getErrorStr(error), referrer);
        }

        @NonNull
        private static String getErrorStr(@NonNull Error error) {
            switch (error) {
                case NO_REFERRER:
                    return "NoReferrer";
                case NOT_A_FIRST_LAUNCH:
                    return "NotAFirstLaunch";
                case PARSE_ERROR:
                    return "ParseError";
                default:
                    return "Unknown";
            }
        }
    }
}
