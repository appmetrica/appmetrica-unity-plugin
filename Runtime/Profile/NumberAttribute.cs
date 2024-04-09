using Io.AppMetrica.Internal.Profile;
using JetBrains.Annotations;

namespace Io.AppMetrica.Profile {
    /// <summary>
    /// The number attribute class.
    /// It enables creating custom number attribute for the user profile.
    /// <p><b>EXAMPLE:</b>
    /// <code>
    /// var userProfile = new UserProfile()
    ///     .Apply(Attribute.CustomNumber("level").WithValue(5d));
    /// </code>
    /// </p>
    /// </summary>
    public class NumberAttribute {
        private readonly string _key;

        /// <summary>
        /// INTERNAL CONSTRUCTOR.
        /// Use <see cref="Attribute.CustomNumber">Attribute.CustomNumber(string)</see> instead.
        /// </summary>
        internal NumberAttribute([NotNull] string key) {
            _key = key;
        }

        /// <summary>
        /// Updates the attribute with the specified value.
        /// 
        /// <p><b>Platforms</b>: Android, iOS.</p>
        /// </summary>
        /// <param name="value">New value.</param>
        /// <returns>The <see cref="UserProfileUpdate"/> object.</returns>
        [NotNull]
        public UserProfileUpdate WithValue(double value) {
            return new NumberValueUserProfileUpdate(_key, value, ifUndefined: false);
        }

        /// <summary>
        /// Updates the attribute with the specified value only if the attribute value is undefined.
        /// The method doesn't affect the value if it has been set earlier.
        /// 
        /// <p><b>Platforms</b>: Android, iOS.</p>
        /// </summary>
        /// <param name="value">New value.</param>
        /// <returns>The <see cref="UserProfileUpdate"/> object.</returns>
        [NotNull]
        public UserProfileUpdate WithValueIfUndefined(double value) {
            return new NumberValueUserProfileUpdate(_key, value, ifUndefined: true);
        }

        /// <summary>
        /// Resets the attribute value.
        /// 
        /// <p><b>Platforms</b>: Android, iOS.</p>
        /// </summary>
        /// <returns>The <see cref="UserProfileUpdate"/> object.</returns>
        [NotNull]
        public UserProfileUpdate WithValueReset() {
            return new NumberResetUserProfileUpdate(_key);
        }
    }
}
