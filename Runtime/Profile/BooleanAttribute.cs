using Io.AppMetrica.Internal.Profile;
using JetBrains.Annotations;

namespace Io.AppMetrica.Profile {
    /// <summary>
    /// The boolean attribute class.
    /// It enables creating custom boolean attribute for the user profile.
    /// <p><b>EXAMPLE:</b>
    /// <code>
    /// var userProfile = new UserProfile()
    ///     .Apply(Attribute.CustomBoolean("is_enabled").WithValue(true));
    /// </code>
    /// </p>
    /// </summary>
    public class BooleanAttribute {
        private readonly string _key;

        /// <summary>
        /// INTERNAL CONSTRUCTOR.
        /// Use <see cref="Attribute.CustomBoolean">Attribute.CustomBoolean(string)</see> instead.
        /// </summary>
        internal BooleanAttribute([NotNull] string key) {
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
        public UserProfileUpdate WithValue(bool value) {
            return new BooleanValueUserProfileUpdate(_key, value, ifUndefined: false);
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
        public UserProfileUpdate WithValueIfUndefined(bool value) {
            return new BooleanValueUserProfileUpdate(_key, value, ifUndefined: true);
        }

        /// <summary>
        /// Resets the attribute value.
        /// 
        /// <p><b>Platforms</b>: Android, iOS.</p>
        /// </summary>
        /// <returns>The <see cref="UserProfileUpdate"/> object.</returns>
        [NotNull]
        public UserProfileUpdate WithValueReset() {
            return new BooleanResetUserProfileUpdate(_key);
        }
    }
}
