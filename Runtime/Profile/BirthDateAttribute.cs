using System;
using Io.AppMetrica.Internal.Profile;

namespace Io.AppMetrica.Profile {
    /// <summary>
    /// The birth date attribute class.
    /// It enables linking user birth date with the profile.
    /// <p><b>EXAMPLE:</b>
    /// <code>
    /// var userProfile = new UserProfile()
    ///     .Apply(Attribute.BirthDate().WithAge(27));
    /// </code>
    /// </p>
    /// </summary>
    public class BirthDateAttribute {
        /// <summary>
        /// INTERNAL CONSTRUCTOR.
        /// Use <see cref="Attribute.BirthDate">Attribute.BirthDate()</see> instead.
        /// </summary>
        internal BirthDateAttribute() { }

        /// <summary>
        /// Updates the birth date attribute with the specified value.
        /// <p>It calculates the birth year by using the following formula:
        /// Birth Year = currentYear - age.</p>
        /// <p><b>NOTE:</b> It overwrites the existing value.</p>
        /// 
        /// <p><b>Platforms</b>: Android, iOS.</p>
        /// </summary>
        /// <param name="age">Age of the user.</param>
        /// <returns>The <see cref="UserProfileUpdate"/> object.</returns>
        public UserProfileUpdate WithAge(int age) {
            return new BirthDateAgeUserProfileUpdate(age, ifUndefined: false);
        }

        /// <summary>
        /// Updates the birth date attribute with the specified value only if the attribute value is undefined.
        /// The method doesn't affect the value if it has been set earlier.
        /// <p>It calculates the birth year by using the following formula:
        /// Birth Year = currentYear - age.</p>
        /// 
        /// <p><b>Platforms</b>: Android.</p>
        /// </summary>
        /// <param name="age">Age of the user</param>
        /// <returns>The <see cref="UserProfileUpdate"/> object.</returns>
        public UserProfileUpdate WithAgeIfUndefined(int age) {
            return new BirthDateAgeUserProfileUpdate(age, ifUndefined: true);
        }

        /// <summary>
        /// Updates the birth date attribute with the specified value.
        /// <p>This methods sets year of the birth date.</p>
        /// <p><b>NOTE:</b> It overwrites the existing value.</p>
        /// 
        /// <p><b>Platforms</b>: Android, iOS.</p>
        /// </summary>
        /// <param name="year">Year of birth.</param>
        /// <returns>The <see cref="UserProfileUpdate"/> object.</returns>
        public UserProfileUpdate WithBirthDate(int year) {
            return new BirthDateYearUserProfileUpdate(year, ifUndefined: false);
        }

        /// <summary>
        /// Updates the birth date attribute with the specified values.
        /// <p>This method sets the year and month of the birth date.</p>
        /// <p><b>NOTE:</b> It overwrites the existing value.</p>
        /// 
        /// <p><b>Platforms</b>: Android, iOS.</p>
        /// </summary>
        /// <param name="year">Year of birth.</param>
        /// <param name="month">Month of birth.</param>
        /// <returns>The <see cref="UserProfileUpdate"/> object.</returns>
        public UserProfileUpdate WithBirthDate(int year, int month) {
            return new BirthDateMonthUserProfileUpdate(year, month, ifUndefined: false);
        }

        /// <summary>
        /// Updates the birth date attribute with the specified values.
        /// <p>This methods sets year, month and day of the month of the birth date.</p>
        /// <p><b>NOTE:</b> It overwrites the existing value.</p>
        /// 
        /// <p><b>Platforms</b>: Android, iOS.</p>
        /// </summary>
        /// <param name="year">Year of birth.</param>
        /// <param name="month">Month of birth.</param>
        /// <param name="dayOfMonth">Day of the month of birth.</param>
        /// <returns>The <see cref="UserProfileUpdate"/> object.</returns>
        public UserProfileUpdate WithBirthDate(int year, int month, int dayOfMonth) {
            return new BirthDateDaysUserProfileUpdate(year, month, dayOfMonth, ifUndefined: false);
        }

        public UserProfileUpdate WithBirthDate(DateTime date) {
            return WithBirthDate(date.Year, date.Month, date.Day);
        }

        /// <summary>
        /// Updates the birth date attribute with the specified value only if the attribute value is undefined.
        /// The method doesn't affect the value if it has been set earlier.
        /// <p>This methods sets year of the birth date.</p>
        /// 
        /// <p><b>Platforms</b>: Android.</p>
        /// </summary>
        /// <param name="year">Year of birth.</param>
        /// <returns>The <see cref="UserProfileUpdate"/> object.</returns>
        public UserProfileUpdate WithBirthDateIfUndefined(int year) {
            return new BirthDateYearUserProfileUpdate(year, ifUndefined: true);
        }

        /// <summary>
        /// Updates the birth date attribute with the specified values only if the attribute value is undefined.
        /// The method doesn't affect the value if it has been set earlier.
        /// <p>This method sets the year and month of the birth date.</p>
        /// 
        /// <p><b>Platforms</b>: Android.</p>
        /// </summary>
        /// <param name="year">Year of birth.</param>
        /// <param name="month">Month of birth.</param>
        /// <returns>The <see cref="UserProfileUpdate"/> object.</returns>
        public UserProfileUpdate WithBirthDateIfUndefined(int year, int month) {
            return new BirthDateMonthUserProfileUpdate(year, month, ifUndefined: true);
        }

        /// <summary>
        /// Updates the birth date attribute with the specified values only if the attribute value is undefined.
        /// The method doesn't affect the value if it has been set earlier.
        /// <p>This methods sets year, month and day of the month of the birth date.</p>
        /// 
        /// <p><b>Platforms</b>: Android.</p>
        /// </summary>
        /// <param name="year">Year of birth.</param>
        /// <param name="month">Month of birth.</param>
        /// <param name="dayOfMonth">Day of the month of birth.</param>
        /// <returns>The <see cref="UserProfileUpdate"/> object.</returns>
        public UserProfileUpdate WithBirthDateIfUndefined(int year, int month, int dayOfMonth) {
            return new BirthDateDaysUserProfileUpdate(year, month, dayOfMonth, ifUndefined: true);
        }

        public UserProfileUpdate WithBirthDateIfUndefined(DateTime date) {
            return WithBirthDateIfUndefined(date.Year, date.Month, date.Day);
        }

        /// <summary>
        /// Resets the birth date attribute value.
        /// 
        /// <p><b>Platforms</b>: Android, iOS.</p>
        /// </summary>
        /// <returns>The <see cref="UserProfileUpdate"/> object.</returns>
        public UserProfileUpdate WithValueReset() {
            return new BirthDateResetUserProfileUpdate();
        }
    }
}
