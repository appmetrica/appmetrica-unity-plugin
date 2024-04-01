package io.appmetrica.analytics.plugin.unity;

import androidx.annotation.NonNull;
import androidx.annotation.Nullable;
import org.jetbrains.annotations.NotNull;
import org.json.JSONException;
import org.json.JSONObject;
import java.util.Map;
import io.appmetrica.analytics.DeferredDeeplinkListener;
import io.appmetrica.analytics.StartupParamsCallback;
import io.appmetrica.analytics.StartupParamsItem;
import io.appmetrica.analytics.StartupParamsItemStatus;

public interface DeferredDeeplinkListenerProxy {
    void onDeeplinkLoaded(@NonNull String deeplink);

    void onError(@NotNull String error, @NotNull String referrer);

    class Delegate implements DeferredDeeplinkListener {
        @NonNull
        private final DeferredDeeplinkListenerProxy proxy;

        public Delegate(@NonNull DeferredDeeplinkListenerProxy proxy) {
            this.proxy = proxy;
        }

        @Override
        public void onDeeplinkLoaded(@NonNull String deeplink) {
            proxy.onDeeplinkLoaded(deeplink);
        }

        @Override
        public void onError(@NonNull Error error, @Nullable String referrer) {
            proxy.onError(getErrorStr(error), referrer == null ? "" : referrer);
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
