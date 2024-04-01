package io.appmetrica.analytics.plugin.unity;

import androidx.annotation.NonNull;
import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;
import java.util.HashMap;
import java.util.Iterator;
import java.util.LinkedList;
import java.util.List;
import java.util.Map;
import io.appmetrica.analytics.plugins.PluginErrorDetails;
import io.appmetrica.analytics.plugins.StackTraceItem;

final class ExceptionSerializer {
    private ExceptionSerializer() {}

    @NonNull
    public static PluginErrorDetails fromJsonString(@NonNull String exception) throws JSONException {
        JSONObject json = new JSONObject(exception);
        PluginErrorDetails.Builder builder = new PluginErrorDetails.Builder();
        builder.withPlatform(PluginErrorDetails.Platform.UNITY);
        if (json.has("ExceptionClass")) {
            builder.withExceptionClass(json.getString("ExceptionClass"));
        }
        if (json.has("Message")) {
            builder.withMessage(json.getString("Message"));
        }
        if (json.has("StackTrace")) {
            builder.withStacktrace(getStackTrace(json.getJSONArray("StackTrace")));
        }
        if (json.has("VirtualMachineVersion")) {
            builder.withVirtualMachineVersion(json.getString("VirtualMachineVersion"));
        }
        if (json.has("PluginEnvironment")) {
            builder.withPluginEnvironment(getPluginEnvironment(json.getJSONObject("PluginEnvironment")));
        }
        return builder.build();
    }

    @NonNull
    private static List<StackTraceItem> getStackTrace(@NonNull JSONArray jsonArray) throws JSONException {
        List<StackTraceItem> items = new LinkedList<>();
        for (int idx = 0; idx < jsonArray.length(); idx++) {
            items.add(getStackTraceItem(jsonArray.getJSONObject(idx)));
        }
        return items;
    }

    @NonNull
    private static StackTraceItem getStackTraceItem(@NonNull JSONObject json) throws JSONException {
        StackTraceItem.Builder builder = new StackTraceItem.Builder();
        if (json.has("FileName")) {
            builder.withFileName(json.getString("FileName"));
        }
        if (json.has("ClassName")) {
            builder.withClassName(json.getString("ClassName"));
        }
        if (json.has("MethodName")) {
            builder.withMethodName(json.getString("MethodName"));
        }
        if (json.has("Line")) {
            builder.withLine(json.getInt("Line"));
        }
        if (json.has("Column")) {
            builder.withColumn(json.getInt("Column"));
        }
        return builder.build();
    }

    @NonNull
    private static Map<String, String> getPluginEnvironment(@NonNull JSONObject json) throws JSONException {
        Map<String, String> payload = new HashMap<>(json.length());
        Iterator<String> keyIterator = json.keys();
        while (keyIterator.hasNext()) {
            String key = keyIterator.next();
            payload.put(key, json.getString(key));
        }
        return payload;
    }
}
