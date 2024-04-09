using Io.AppMetrica.Internal.Profile;
using JetBrains.Annotations;

namespace Io.AppMetrica.Profile {
    /// <summary>
    /// The name attribute class.
    /// It enables setting user name for the profile.
    /// <p><b>NOTE:</b> The maximum length of the user profile name is 100 characters.</p>
    /// <p><b>EXAMPLE:</b>
    /// <code>
    /// var userProfile = new UserProfile()
    ///     .Apply(Attribute.Name().WithValue("John"));
    /// </code>
    /// </p>
    /// </summary>
    public class NameAttribute {
        /// <summary>
        /// INTERNAL CONSTRUCTOR.
        /// Use <see cref="Attribute.Name">Attribute.Name()</see> instead.
        /// </summary>
        internal NameAttribute() { }

        /// <summary>
        /// Updates the attribute with the specified value.
        /// 
        /// <p><b>Platforms</b>: Android, iOS.</p>
        /// </summary>
        /// <param name="value">Actual name.</param>
        /// <returns>The <see cref="UserProfileUpdate"/> object.</returns>
        [NotNull]
        public UserProfileUpdate WithValue([NotNull] string value) {
            return new NameValueUserProfileUpdate(value, ifUndefined: false);
        }

        /// <summary>
        /// Updates the attribute with the specified value only if the attribute value is undefined.
        /// The method doesn't affect the value if it has been set earlier.
        /// 
        /// <p><b>Platforms</b>: Android.</p>
        /// </summary>
        /// <param name="value">Actual name.</param>
        /// <returns>The <see cref="UserProfileUpdate"/> object.</returns>
        [NotNull]
        public UserProfileUpdate WithValueIfUndefined([NotNull] string value) {
            return new NameValueUserProfileUpdate(value, ifUndefined: true);
        }

        /// <summary>
        /// Resets the attribute value.
        /// 
        /// <p><b>Platforms</b>: Android, iOS.</p>
        /// </summary>
        /// <returns>The <see cref="UserProfileUpdate"/> object.</returns>
        [NotNull]
        public UserProfileUpdate WithValueReset() {
            return new NameResetUserProfileUpdate();
        }
    }
}
