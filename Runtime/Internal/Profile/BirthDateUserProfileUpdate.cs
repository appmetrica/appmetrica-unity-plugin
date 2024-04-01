using Io.AppMetrica.Profile;

namespace Io.AppMetrica.Internal.Profile {
    /// <summary>
    /// INTERNAL CLASS.
    /// Use <see cref="Attribute.BirthDate">Attribute.BirthDate()</see> for create this UserProfileUpdate.
    /// </summary>
    internal class BirthDateAgeUserProfileUpdate : UserProfileUpdate {
        public readonly int Age;
        public readonly bool IfUndefined;

        public BirthDateAgeUserProfileUpdate(int age, bool ifUndefined) {
            Age = age;
            IfUndefined = ifUndefined;
        }
    }

    /// <summary>
    /// INTERNAL CLASS.
    /// Use <see cref="Attribute.BirthDate">Attribute.BirthDate()</see> for create this UserProfileUpdate.
    /// </summary>
    internal class BirthDateYearUserProfileUpdate : UserProfileUpdate {
        public readonly int Year;
        public readonly bool IfUndefined;

        public BirthDateYearUserProfileUpdate(int year, bool ifUndefined) {
            Year = year;
            IfUndefined = ifUndefined;
        }
    }

    /// <summary>
    /// INTERNAL CLASS.
    /// Use <see cref="Attribute.BirthDate">Attribute.BirthDate()</see> for create this UserProfileUpdate.
    /// </summary>
    internal class BirthDateMonthUserProfileUpdate : UserProfileUpdate {
        public readonly int Year;
        public readonly int Month;
        public readonly bool IfUndefined;

        public BirthDateMonthUserProfileUpdate(int year, int month, bool ifUndefined) {
            Year = year;
            Month = month;
            IfUndefined = ifUndefined;
        }
    }

    /// <summary>
    /// INTERNAL CLASS.
    /// Use <see cref="Attribute.BirthDate">Attribute.BirthDate()</see> for create this UserProfileUpdate.
    /// </summary>
    internal class BirthDateDaysUserProfileUpdate : UserProfileUpdate {
        public readonly int Year;
        public readonly int Month;
        public readonly int DayOfMonth;
        public readonly bool IfUndefined;

        public BirthDateDaysUserProfileUpdate(int year, int month, int dayOfMonth, bool ifUndefined) {
            Year = year;
            Month = month;
            DayOfMonth = dayOfMonth;
            IfUndefined = ifUndefined;
        }
    }

    /// <summary>
    /// INTERNAL CLASS.
    /// Use <see cref="Attribute.BirthDate">Attribute.BirthDate()</see> for create this UserProfileUpdate.
    /// </summary>
    internal class BirthDateResetUserProfileUpdate : UserProfileUpdate { }
}
