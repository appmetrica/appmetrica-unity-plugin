package io.appmetrica.analytics.plugin.unity;

import android.app.Activity;
import androidx.annotation.NonNull;
import com.unity3d.player.UnityPlayer;
import io.appmetrica.analytics.AppMetricaLibraryAdapter;

public final class AppMetricaLibraryAdapterProxy {
    private AppMetricaLibraryAdapterProxy() {}

    public static void subscribeForAutoCollectedData(@NonNull String apiKey) {
        try {
            AppMetricaLibraryAdapter.subscribeForAutoCollectedData(getActivity(), apiKey);
        } catch (Throwable e) {
            AppMetricaUnityLogger.e("Failed to subscribe for auto collected data.", e);
        }
    }

    @NonNull
    private static Activity getActivity() {
        // TODO: check UnityPlayer.currentActivity != null
        return UnityPlayer.currentActivity;
    }
}
