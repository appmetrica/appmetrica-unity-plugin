using Io.AppMetrica.Internal.Profile;
using JetBrains.Annotations;

namespace Io.AppMetrica.Profile {
    /// <summary>
    /// The NotificationsEnabled attribute class.
    /// It indicates whether the user has enabled notifications for the application.
    /// It enables setting notification status for the user profile.
    /// <p><b>EXAMPLE:</b>
    /// <code>
    /// var userProfile = new UserProfile()
    ///     .Apply(Attribute.NotificationsEnabled().WithValue(true));
    /// </code>
    /// </p>
    /// </summary>
    public class NotificationsEnabledAttribute {
        /// <summary>
        /// INTERNAL CONSTRUCTOR.
        /// Use <see cref="Attribute.NotificationsEnabled">Attribute.NotificationsEnabled()</see> instead.
        /// </summary>
        internal NotificationsEnabledAttribute() { }

        /// <summary>
        /// Updates the attribute with the specified value.
        /// 
        /// <p><b>Platforms</b>: Android, iOS.</p>
        /// </summary>
        /// <param name="value">Actual status.</param>
        /// <returns>The <see cref="UserProfileUpdate"/> object.</returns>
        [NotNull]
        public UserProfileUpdate WithValue(bool value) {
            return new NotificationsEnabledValueUserProfileUpdate(value, ifUndefined: false);
        }

        /// <summary>
        /// Updates the attribute with the specified value only if the attribute value is undefined.
        /// The method doesn't affect the value if it has been set earlier.
        /// 
        /// <p><b>Platforms</b>: Android.</p>
        /// </summary>
        /// <param name="value">Actual status.</param>
        /// <returns>The <see cref="UserProfileUpdate"/> object.</returns>
        [NotNull]
        public UserProfileUpdate WithValueIfUndefined(bool value) {
            return new NotificationsEnabledValueUserProfileUpdate(value, ifUndefined: true);
        }

        /// <summary>
        /// Resets the attribute value.
        /// 
        /// <p><b>Platforms</b>: Android, iOS.</p>
        /// </summary>
        /// <returns>The <see cref="UserProfileUpdate"/> object.</returns>
        [NotNull]
        public UserProfileUpdate WithValueReset() {
            return new NotificationsEnabledResetUserProfileUpdate();
        }
    }
}
