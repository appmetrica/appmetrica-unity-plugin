package io.appmetrica.analytics.plugin.unity;

import android.util.Log;

final class AppMetricaUnityLogger {
    private AppMetricaUnityLogger() {}

    public static void e(String message) {
        Log.e("AppMetricaUnity", message);
    }

    public static void e(String message, Throwable exception) {
        Log.e("AppMetricaUnity", message, exception);
    }
}
