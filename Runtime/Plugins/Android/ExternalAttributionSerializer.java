package io.appmetrica.analytics.plugin.unity;

import androidx.annotation.NonNull;

import io.appmetrica.analytics.ModulesFacade;

final class ExternalAttributionSerializer {
    private ExternalAttributionSerializer() {}

    public static int getSourceId(@NonNull String sourceStr) {
        switch (sourceStr) {
            case "AppsFlyer":
                return ModulesFacade.EXTERNAL_ATTRIBUTION_APPSFLYER;
            case "Adjust":
                return ModulesFacade.EXTERNAL_ATTRIBUTION_ADJUST;
            case "Kochava":
                return ModulesFacade.EXTERNAL_ATTRIBUTION_KOCHAVA;
            case "Tenjin":
                return ModulesFacade.EXTERNAL_ATTRIBUTION_TENJIN;
            case "Airbridge":
                return ModulesFacade.EXTERNAL_ATTRIBUTION_AIRBRIDGE;
            case "Singular":
                return ModulesFacade.EXTERNAL_ATTRIBUTION_SINGULAR;
            default:
                return -1;
        }
    }
}
