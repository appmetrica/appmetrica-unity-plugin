using Io.AppMetrica.Internal.Profile;
using JetBrains.Annotations;

namespace Io.AppMetrica.Profile {
    /// <summary>
    /// The gender attribute class.
    /// It enables linking user gender with the profile.
    /// <p>Possible values:<br/>
    /// - <see cref="Gender.Female"/><br/>
    /// - <see cref="Gender.Male"/><br/>
    /// - <see cref="Gender.Other"/><br/>
    /// </p>
    /// <p>You can set the OTHER value to the Gender attribute and pass additional info using the custom attribute.</p>
    /// <p><b>EXAMPLE:</b>
    /// <code>
    /// var userProfile = new UserProfile()
    ///     .Apply(Attribute.Gender().WithValue(GenderAttribute.Gender.Other));
    /// </code>
    /// </p>
    /// </summary>
    public class GenderAttribute {
        /// <summary>
        /// Gender enumeration.
        /// </summary>
        public enum Gender {
            Female,
            Male,
            Other,
        }

        /// <summary>
        /// INTERNAL CONSTRUCTOR.
        /// Use <see cref="Attribute.Gender">Attribute.Gender()</see> instead.
        /// </summary>
        internal GenderAttribute() { }

        /// <summary>
        /// Updates the attribute with the specified value.
        /// 
        /// <p><b>Platforms</b>: Android, iOS.</p>
        /// </summary>
        /// <param name="value">Actual gender.</param>
        /// <returns>The <see cref="UserProfileUpdate"/> object.</returns>
        [NotNull]
        public UserProfileUpdate WithValue(Gender value) {
            return new GenderValueUserProfileUpdate(value, ifUndefined: false);
        }

        /// <summary>
        /// Updates the attribute with the specified value only if the attribute value is undefined.
        /// The method doesn't affect the value if it has been set earlier.
        /// 
        /// <p><b>Platforms</b>: Android.</p>
        /// </summary>
        /// <param name="value">Actual gender.</param>
        /// <returns>The <see cref="UserProfileUpdate"/> object.</returns>
        [NotNull]
        public UserProfileUpdate WithValueIfUndefined(Gender value) {
            return new GenderValueUserProfileUpdate(value, ifUndefined: true);
        }

        /// <summary>
        /// Resets the attribute value.
        /// 
        /// <p><b>Platforms</b>: Android, iOS.</p>
        /// </summary>
        /// <returns>The <see cref="UserProfileUpdate"/> object.</returns>
        [NotNull]
        public UserProfileUpdate WithValueReset() {
            return new GenderResetUserProfileUpdate();
        }
    }
}
