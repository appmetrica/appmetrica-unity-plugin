package io.appmetrica.analytics.plugin.unity;

import androidx.annotation.NonNull;
import androidx.annotation.Nullable;
import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;
import io.appmetrica.analytics.profile.Attribute;
import io.appmetrica.analytics.profile.BirthDateAttribute;
import io.appmetrica.analytics.profile.BooleanAttribute;
import io.appmetrica.analytics.profile.CounterAttribute;
import io.appmetrica.analytics.profile.GenderAttribute;
import io.appmetrica.analytics.profile.NameAttribute;
import io.appmetrica.analytics.profile.NotificationsEnabledAttribute;
import io.appmetrica.analytics.profile.NumberAttribute;
import io.appmetrica.analytics.profile.StringAttribute;
import io.appmetrica.analytics.profile.UserProfile;
import io.appmetrica.analytics.profile.UserProfileUpdate;

final class UserProfileSerializer {
    private UserProfileSerializer() {}

    @NonNull
    public static UserProfile fromJsonString(@NonNull String profile) throws JSONException {
        JSONArray json = new JSONArray(profile);
        UserProfile.Builder builder = UserProfile.newBuilder();

        for (int idx = 0; idx < json.length(); idx++) {
            builder.apply(parseUserProfileUpdate(json.getJSONObject(idx)));
        }

        return builder.build();
    }

    @NonNull
    private static UserProfileUpdate<?> parseUserProfileUpdate(@NonNull JSONObject json) throws JSONException {
        String type = json.getString("Type");
        if (type.startsWith("BirthDate")) {
            return parseBirthDate(type, json);
        }
        if (type.startsWith("Boolean")) {
            return parseBoolean(type, json);
        }
        if (type.startsWith("Counter")) {
            return parseCounter(type, json);
        }
        if (type.startsWith("Gender")) {
            return parseGender(type, json);
        }
        if (type.startsWith("Name")) {
            return parseName(type, json);
        }
        if (type.startsWith("NotificationsEnabled")) {
            return parseNotificationsEnabled(type, json);
        }
        if (type.startsWith("Number")) {
            return parseNumber(type, json);
        }
        if (type.startsWith("String")) {
            return parseString(type, json);
        }
        throw new JSONException("Unknown UserProfile type " + type);
    }

    @NonNull
    private static UserProfileUpdate<?> parseBirthDate(@NonNull String type, @NonNull JSONObject json) throws JSONException {
        BirthDateAttribute att = Attribute.birthDate();
        // BirthDate
        switch (type) {
            case "BirthDateAgeUserProfileUpdate": {
                int age = json.getInt("Age");
                boolean ifUndefined = json.getBoolean("IfUndefined");
                return ifUndefined ? att.withAgeIfUndefined(age) : att.withAge(age);
            }
            case "BirthDateYearUserProfileUpdate": {
                int year = json.getInt("Year");
                boolean ifUndefined = json.getBoolean("IfUndefined");
                return ifUndefined ? att.withBirthDateIfUndefined(year) : att.withBirthDate(year);
            }
            case "BirthDateMonthUserProfileUpdate": {
                int year = json.getInt("Year");
                int month = json.getInt("Month");
                boolean ifUndefined = json.getBoolean("IfUndefined");
                return ifUndefined ? att.withBirthDateIfUndefined(year, month) : att.withBirthDate(year, month);
            }
            case "BirthDateDaysUserProfileUpdate": {
                int year = json.getInt("Year");
                int month = json.getInt("Month");
                int days = json.getInt("DayOfMonth");
                boolean ifUndefined = json.getBoolean("IfUndefined");
                return ifUndefined ? att.withBirthDateIfUndefined(year, month, days) : att.withBirthDate(year, month, days);
            }
            case "BirthDateResetUserProfileUpdate": {
                return att.withValueReset();
            }
        }
        throw new JSONException("Unknown UserProfile type " + type);
    }

    @NonNull
    private static UserProfileUpdate<?> parseBoolean(@NonNull String type, @NonNull JSONObject json) throws JSONException {
        BooleanAttribute att = Attribute.customBoolean(json.getString("Key"));
        // BirthDate
        switch (type) {
            case "BooleanValueUserProfileUpdate": {
                boolean value = json.getBoolean("Value");
                boolean ifUndefined = json.getBoolean("IfUndefined");
                return ifUndefined ? att.withValueIfUndefined(value) : att.withValue(value);
            }
            case "BooleanResetUserProfileUpdate": {
                return att.withValueReset();
            }
        }
        throw new JSONException("Unknown UserProfile type " + type);
    }

    @NonNull
    private static UserProfileUpdate<?> parseCounter(@NonNull String type, @NonNull JSONObject json) throws JSONException {
        CounterAttribute att = Attribute.customCounter(json.getString("Key"));
        // BirthDate
        if (type.equals("CounterDeltaUserProfileUpdate")) {
            double delta = json.getDouble("Delta");
            return att.withDelta(delta);
        }
        throw new JSONException("Unknown UserProfile type " + type);
    }

    @NonNull
    private static UserProfileUpdate<?> parseGender(@NonNull String type, @NonNull JSONObject json) throws JSONException {
        GenderAttribute att = Attribute.gender();
        // BirthDate
        switch (type) {
            case "GenderValueUserProfileUpdate": {
                GenderAttribute.Gender value = getGender(json.getString("Value"));
                boolean ifUndefined = json.getBoolean("IfUndefined");
                return ifUndefined ? att.withValueIfUndefined(value) : att.withValue(value);
            }
            case "GenderResetUserProfileUpdate": {
                return att.withValueReset();
            }
        }
        throw new JSONException("Unknown UserProfile type " + type);
    }

    @NonNull
    private static GenderAttribute.Gender getGender(@NonNull String value) {
        switch (value) {
            case "Female":
                return GenderAttribute.Gender.FEMALE;
            case "Male":
                return GenderAttribute.Gender.MALE;
            default:
                return GenderAttribute.Gender.OTHER;
        }
    }

    @NonNull
    private static UserProfileUpdate<?> parseName(@NonNull String type, @NonNull JSONObject json) throws JSONException {
        NameAttribute att = Attribute.name();
        // BirthDate
        switch (type) {
            case "NameValueUserProfileUpdate": {
                String value = json.getString("Value");
                boolean ifUndefined = json.getBoolean("IfUndefined");
                return ifUndefined ? att.withValueIfUndefined(value) : att.withValue(value);
            }
            case "NameResetUserProfileUpdate": {
                return att.withValueReset();
            }
        }
        throw new JSONException("Unknown UserProfile type " + type);
    }

    @NonNull
    private static UserProfileUpdate<?> parseNotificationsEnabled(@NonNull String type, @NonNull JSONObject json) throws JSONException {
        NotificationsEnabledAttribute att = Attribute.notificationsEnabled();
        // BirthDate
        switch (type) {
            case "NotificationsEnabledValueUserProfileUpdate": {
                boolean value = json.getBoolean("Value");
                boolean ifUndefined = json.getBoolean("IfUndefined");
                return ifUndefined ? att.withValueIfUndefined(value) : att.withValue(value);
            }
            case "NotificationsEnabledResetUserProfileUpdate": {
                return att.withValueReset();
            }
        }
        throw new JSONException("Unknown UserProfile type " + type);
    }

    @NonNull
    private static UserProfileUpdate<?> parseNumber(@NonNull String type, @NonNull JSONObject json) throws JSONException {
        NumberAttribute att = Attribute.customNumber(json.getString("Key"));
        // BirthDate
        switch (type) {
            case "NumberValueUserProfileUpdate": {
                double value = json.getDouble("Value");
                boolean ifUndefined = json.getBoolean("IfUndefined");
                return ifUndefined ? att.withValueIfUndefined(value) : att.withValue(value);
            }
            case "NumberResetUserProfileUpdate": {
                return att.withValueReset();
            }
        }
        throw new JSONException("Unknown UserProfile type " + type);
    }

    @NonNull
    private static UserProfileUpdate<?> parseString(@NonNull String type, @NonNull JSONObject json) throws JSONException {
        StringAttribute att = Attribute.customString(json.getString("Key"));
        // BirthDate
        switch (type) {
            case "StringValueUserProfileUpdate": {
                String value = json.getString("Value");
                boolean ifUndefined = json.getBoolean("IfUndefined");
                return ifUndefined ? att.withValueIfUndefined(value) : att.withValue(value);
            }
            case "StringResetUserProfileUpdate": {
                return att.withValueReset();
            }
        }
        throw new JSONException("Unknown UserProfile type " + type);
    }
}
