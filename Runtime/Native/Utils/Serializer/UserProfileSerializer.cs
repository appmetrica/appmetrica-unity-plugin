using System.Collections.Generic;
using Io.AppMetrica.Internal;
using Io.AppMetrica.Internal.Profile;
using Io.AppMetrica.Profile;
using JetBrains.Annotations;
using System.Linq;

namespace Io.AppMetrica.Native.Utils.Serializer {
    internal static class UserProfileSerializer {
        [NotNull]
        public static string ToJsonString([NotNull] this UserProfile self) {
            return JSONEncoder.Encode(
                self.UserProfileUpdates
                    .Select(ConvertUpdate)
                    .Where(updateDict => updateDict != null)
                    .ToList()
            );
        }

        [CanBeNull]
        private static IDictionary<string, object> ConvertUpdate([NotNull] UserProfileUpdate value) {
            return ConvertBirthDate(value)
                   ?? ConvertBoolean(value)
                   ?? ConvertCounter(value)
                   ?? ConvertGender(value)
                   ?? ConvertName(value)
                   ?? ConvertNotificationsEnabled(value)
                   ?? ConvertNumber(value)
                   ?? ConvertString(value);
        }

        [CanBeNull]
        private static IDictionary<string, object> ConvertBirthDate(UserProfileUpdate value) {
            return value switch {
                BirthDateAgeUserProfileUpdate profileUpdate => new Dictionary<string, object> {
                    { "Type", "BirthDateAgeUserProfileUpdate" },
                    { "Age", profileUpdate.Age },
                    { "IfUndefined", profileUpdate.IfUndefined },
                },
                BirthDateYearUserProfileUpdate profileUpdate => new Dictionary<string, object> {
                    { "Type", "BirthDateYearUserProfileUpdate" },
                    { "Year", profileUpdate.Year },
                    { "IfUndefined", profileUpdate.IfUndefined },
                },
                BirthDateMonthUserProfileUpdate profileUpdate => new Dictionary<string, object> {
                    { "Type", "BirthDateMonthUserProfileUpdate" },
                    { "Year", profileUpdate.Year },
                    { "Month", profileUpdate.Month },
                    { "IfUndefined", profileUpdate.IfUndefined },
                },
                BirthDateDaysUserProfileUpdate profileUpdate => new Dictionary<string, object> {
                    { "Type", "BirthDateDaysUserProfileUpdate" },
                    { "Year", profileUpdate.Year },
                    { "Month", profileUpdate.Month },
                    { "DayOfMonth", profileUpdate.DayOfMonth },
                    { "IfUndefined", profileUpdate.IfUndefined },
                },
                BirthDateResetUserProfileUpdate => new Dictionary<string, object> {
                    { "Type", "BirthDateResetUserProfileUpdate" },
                },
                _ => (IDictionary<string, object>)null,
            };
        }

        [CanBeNull]
        private static IDictionary<string, object> ConvertBoolean(UserProfileUpdate value) {
            return value switch {
                BooleanValueUserProfileUpdate profileUpdate => new Dictionary<string, object> {
                    { "Type", "BooleanValueUserProfileUpdate" },
                    { "Key", profileUpdate.Key },
                    { "Value", profileUpdate.Value },
                    { "IfUndefined", profileUpdate.IfUndefined },
                },
                BooleanResetUserProfileUpdate profileUpdate => new Dictionary<string, object> {
                    { "Type", "BooleanResetUserProfileUpdate" },
                    { "Key", profileUpdate.Key },
                },
                _ => (IDictionary<string, object>)null,
            };
        }

        [CanBeNull]
        private static IDictionary<string, object> ConvertCounter(UserProfileUpdate value) {
            return value switch {
                CounterDeltaUserProfileUpdate profileUpdate => new Dictionary<string, object> {
                    { "Type", "CounterDeltaUserProfileUpdate" },
                    { "Key", profileUpdate.Key },
                    { "Delta", profileUpdate.Delta },
                },
                _ => (IDictionary<string, object>)null,
            };
        }

        [CanBeNull]
        private static IDictionary<string, object> ConvertGender(UserProfileUpdate value) {
            return value switch {
                GenderValueUserProfileUpdate profileUpdate => new Dictionary<string, object> {
                    { "Type", "GenderValueUserProfileUpdate" },
                    { "Value", GetGenderString(profileUpdate.Value) },
                    { "IfUndefined", profileUpdate.IfUndefined },
                },
                GenderResetUserProfileUpdate => new Dictionary<string, object> {
                    { "Type", "GenderResetUserProfileUpdate" },
                },
                _ => (IDictionary<string, object>)null,
            };
        }

        [CanBeNull]
        private static string GetGenderString(GenderAttribute.Gender? value) {
            return value switch {
                GenderAttribute.Gender.Female => "Female",
                GenderAttribute.Gender.Male => "Male",
                GenderAttribute.Gender.Other => "Other",
                _ => null,
            };
        }

        [CanBeNull]
        private static IDictionary<string, object> ConvertName(UserProfileUpdate value) {
            return value switch {
                NameValueUserProfileUpdate profileUpdate => new Dictionary<string, object> {
                    { "Type", "NameValueUserProfileUpdate" },
                    { "Value", profileUpdate.Value },
                    { "IfUndefined", profileUpdate.IfUndefined },
                },
                NameResetUserProfileUpdate => new Dictionary<string, object> {
                    { "Type", "NameResetUserProfileUpdate" },
                },
                _ => (IDictionary<string, object>)null,
            };
        }

        [CanBeNull]
        private static IDictionary<string, object> ConvertNotificationsEnabled(UserProfileUpdate value) {
            return value switch {
                NotificationsEnabledValueUserProfileUpdate profileUpdate => new Dictionary<string, object> {
                    { "Type", "NotificationsEnabledValueUserProfileUpdate" },
                    { "Value", profileUpdate.Value },
                    { "IfUndefined", profileUpdate.IfUndefined },
                },
                NotificationsEnabledResetUserProfileUpdate => new Dictionary<string, object> {
                    { "Type", "NotificationsEnabledResetUserProfileUpdate" },
                },
                _ => (IDictionary<string, object>)null,
            };
        }

        [CanBeNull]
        private static IDictionary<string, object> ConvertNumber(UserProfileUpdate value) {
            return value switch {
                NumberValueUserProfileUpdate profileUpdate => new Dictionary<string, object> {
                    { "Type", "NumberValueUserProfileUpdate" },
                    { "Key", profileUpdate.Key },
                    { "Value", profileUpdate.Value },
                    { "IfUndefined", profileUpdate.IfUndefined },
                },
                NumberResetUserProfileUpdate profileUpdate => new Dictionary<string, object> {
                    { "Type", "NumberResetUserProfileUpdate" },
                    { "Key", profileUpdate.Key },
                },
                _ => (IDictionary<string, object>)null,
            };
        }

        [CanBeNull]
        private static IDictionary<string, object> ConvertString(UserProfileUpdate value) {
            return value switch {
                StringValueUserProfileUpdate profileUpdate => new Dictionary<string, object> {
                    { "Type", "StringValueUserProfileUpdate" },
                    { "Key", profileUpdate.Key },
                    { "Value", profileUpdate.Value },
                    { "IfUndefined", profileUpdate.IfUndefined },
                },
                StringResetUserProfileUpdate profileUpdate => new Dictionary<string, object> {
                    { "Type", "StringResetUserProfileUpdate" },
                    { "Key", profileUpdate.Key },
                },
                _ => (IDictionary<string, object>)null,
            };
        }
    }
}
