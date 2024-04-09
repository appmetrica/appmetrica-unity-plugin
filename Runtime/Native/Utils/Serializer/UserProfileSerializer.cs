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
            switch (value) {
                case BirthDateAgeUserProfileUpdate profileUpdate:
                    return new Dictionary<string, object> {
                        { "Type", "BirthDateAgeUserProfileUpdate" },
                        { "Age", profileUpdate.Age },
                        { "IfUndefined", profileUpdate.IfUndefined },
                    };
                case BirthDateYearUserProfileUpdate profileUpdate:
                    return new Dictionary<string, object> {
                        { "Type", "BirthDateYearUserProfileUpdate" },
                        { "Year", profileUpdate.Year },
                        { "IfUndefined", profileUpdate.IfUndefined },
                    };
                case BirthDateMonthUserProfileUpdate profileUpdate:
                    return new Dictionary<string, object> {
                        { "Type", "BirthDateMonthUserProfileUpdate" },
                        { "Year", profileUpdate.Year },
                        { "Month", profileUpdate.Month },
                        { "IfUndefined", profileUpdate.IfUndefined },
                    };
                case BirthDateDaysUserProfileUpdate profileUpdate:
                    return new Dictionary<string, object> {
                        { "Type", "BirthDateDaysUserProfileUpdate" },
                        { "Year", profileUpdate.Year },
                        { "Month", profileUpdate.Month },
                        { "DayOfMonth", profileUpdate.DayOfMonth },
                        { "IfUndefined", profileUpdate.IfUndefined },
                    };
                case BirthDateResetUserProfileUpdate profileUpdate:
                    return new Dictionary<string, object> {
                        { "Type", "BirthDateResetUserProfileUpdate" },
                    };
                default:
                    return (IDictionary<string, object>)null;
            }
        }

        [CanBeNull]
        private static IDictionary<string, object> ConvertBoolean(UserProfileUpdate value) {
            switch (value) {
                case BooleanValueUserProfileUpdate profileUpdate:
                    return new Dictionary<string, object> {
                        { "Type", "BooleanValueUserProfileUpdate" },
                        { "Key", profileUpdate.Key },
                        { "Value", profileUpdate.Value },
                        { "IfUndefined", profileUpdate.IfUndefined },
                    };
                case BooleanResetUserProfileUpdate profileUpdate:
                    return new Dictionary<string, object> {
                        { "Type", "BooleanResetUserProfileUpdate" },
                        { "Key", profileUpdate.Key },
                    };
                default:
                    return (IDictionary<string, object>)null;
            }
        }

        [CanBeNull]
        private static IDictionary<string, object> ConvertCounter(UserProfileUpdate value) {
            switch (value) {
                case CounterDeltaUserProfileUpdate profileUpdate:
                    return new Dictionary<string, object> {
                        { "Type", "CounterDeltaUserProfileUpdate" },
                        { "Key", profileUpdate.Key },
                        { "Delta", profileUpdate.Delta },
                    };
                default:
                    return (IDictionary<string, object>)null;
            }
        }

        [CanBeNull]
        private static IDictionary<string, object> ConvertGender(UserProfileUpdate value) {
            switch (value) {
                case GenderValueUserProfileUpdate profileUpdate:
                    return new Dictionary<string, object> {
                        { "Type", "GenderValueUserProfileUpdate" },
                        { "Value", GetGenderString(profileUpdate.Value) },
                        { "IfUndefined", profileUpdate.IfUndefined },
                    };
                case GenderResetUserProfileUpdate profileUpdate:
                    return new Dictionary<string, object> {
                        { "Type", "GenderResetUserProfileUpdate" },
                    };
                default:
                    return (IDictionary<string, object>)null;
            }
        }

        [CanBeNull]
        private static string GetGenderString(GenderAttribute.Gender? value) {
            switch (value) {
                case GenderAttribute.Gender.Female:
                    return "Female";
                case GenderAttribute.Gender.Male:
                    return "Male";
                case GenderAttribute.Gender.Other:
                    return "Other";
                default:
                    return null;
            }
        }

        [CanBeNull]
        private static IDictionary<string, object> ConvertName(UserProfileUpdate value) {
            switch (value) {
                case NameValueUserProfileUpdate profileUpdate:
                    return new Dictionary<string, object> {
                        { "Type", "NameValueUserProfileUpdate" },
                        { "Value", profileUpdate.Value },
                        { "IfUndefined", profileUpdate.IfUndefined },
                    };
                case NameResetUserProfileUpdate profileUpdate:
                    return new Dictionary<string, object> {
                        { "Type", "NameResetUserProfileUpdate" },
                    };
                default:
                    return (IDictionary<string, object>)null;
            }
        }

        [CanBeNull]
        private static IDictionary<string, object> ConvertNotificationsEnabled(UserProfileUpdate value) {
            switch (value) {
                case NotificationsEnabledValueUserProfileUpdate profileUpdate:
                    return new Dictionary<string, object> {
                        { "Type", "NotificationsEnabledValueUserProfileUpdate" },
                        { "Value", profileUpdate.Value },
                        { "IfUndefined", profileUpdate.IfUndefined },
                    };
                case NotificationsEnabledResetUserProfileUpdate profileUpdate:
                    return new Dictionary<string, object> {
                        { "Type", "NotificationsEnabledResetUserProfileUpdate" },
                    };
                default:
                    return (IDictionary<string, object>)null;
            }
        }

        [CanBeNull]
        private static IDictionary<string, object> ConvertNumber(UserProfileUpdate value) {
            switch (value) {
                case NumberValueUserProfileUpdate profileUpdate:
                    return new Dictionary<string, object> {
                        { "Type", "NumberValueUserProfileUpdate" },
                        { "Key", profileUpdate.Key },
                        { "Value", profileUpdate.Value },
                        { "IfUndefined", profileUpdate.IfUndefined },
                    };
                case NumberResetUserProfileUpdate profileUpdate:
                    return new Dictionary<string, object> {
                        { "Type", "NumberResetUserProfileUpdate" },
                        { "Key", profileUpdate.Key },
                    };
                default:
                    return (IDictionary<string, object>)null;
            }
        }

        [CanBeNull]
        private static IDictionary<string, object> ConvertString(UserProfileUpdate value) {
            switch (value) {
                case StringValueUserProfileUpdate profileUpdate:
                    return new Dictionary<string, object> {
                        { "Type", "StringValueUserProfileUpdate" },
                        { "Key", profileUpdate.Key },
                        { "Value", profileUpdate.Value },
                        { "IfUndefined", profileUpdate.IfUndefined },
                    };
                case StringResetUserProfileUpdate profileUpdate:
                    return new Dictionary<string, object> {
                        { "Type", "StringResetUserProfileUpdate" },
                        { "Key", profileUpdate.Key },
                    };
                default:
                    return (IDictionary<string, object>)null;
            }
        }
    }
}
