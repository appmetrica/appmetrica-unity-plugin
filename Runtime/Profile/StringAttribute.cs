using Io.AppMetrica.Internal.Profile;
using JetBrains.Annotations;

namespace Io.AppMetrica.Profile {
    /// <summary>
    /// The string attribute class.
    /// It enables creating custom string attribute for the user profile.
    /// <p><b>EXAMPLE:</b>
    /// <code>
    /// var userProfile = new UserProfile()
    ///     .Apply(Attribute.CustomString("favorite_country").WithValue("Russia"));
    /// </code>
    /// </p>
    /// </summary>
    public class StringAttribute {
        private readonly string _key;

        /// <summary>
        /// INTERNAL CONSTRUCTOR.
        /// Use <see cref="Attribute.CustomString">Attribute.CustomString(string)</see> instead.
        /// </summary>
        internal StringAttribute([NotNull] string key) {
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
        public UserProfileUpdate WithValue([NotNull] string value) {
            return new StringValueUserProfileUpdate(_key, value, ifUndefined: false);
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
        public UserProfileUpdate WithValueIfUndefined([NotNull] string value) {
            return new StringValueUserProfileUpdate(_key, value, ifUndefined: true);
        }

        /// <summary>
        /// Resets the attribute value.
        /// 
        /// <p><b>Platforms</b>: Android, iOS.</p>
        /// </summary>
        /// <returns>The <see cref="UserProfileUpdate"/> object.</returns>
        [NotNull]
        public UserProfileUpdate WithValueReset() {
            return new StringResetUserProfileUpdate(_key);
        }
    }
}
