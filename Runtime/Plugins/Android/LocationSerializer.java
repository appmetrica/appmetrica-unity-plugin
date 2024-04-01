package io.appmetrica.analytics.plugin.unity;

import android.location.Location;
import androidx.annotation.NonNull;
import org.json.JSONException;
import org.json.JSONObject;

final class LocationSerializer {
    private LocationSerializer() {}

    @NonNull
    public static Location fromJsonString(@NonNull String locationStr) throws JSONException {
        JSONObject json = new JSONObject(locationStr);
        Location location = new Location("");
        location.setLatitude(json.getDouble("Latitude"));
        location.setLongitude(json.getDouble("Longitude"));
        return location;
    }
}
