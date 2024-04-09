using JetBrains.Annotations;
using System.Collections.Generic;

namespace Io.AppMetrica.Profile {
    /// <summary>
    /// The class to store a user profile.
    /// <p>User profile is a set of user attributes.
    /// User profile details are displayed in the AppMetrica User profiles report.</p>
    /// <p>The UserProfile object should be passed to the AppMetrica server by using the
    /// <see cref="AppMetrica.ReportUserProfile">AppMetrica.ReportUserProfile(UserProfile)</see> method.</p>
    /// <p>AppMetrica has some predefined attributes. You can use them or create own custom attributes.</p>
    /// <p>User profiles are stored on the AppMetrica server.</p>
    /// <p><b>EXAMPLE:</b>
    /// <code>
    /// var userProfile = new UserProfile()
    ///     .Apply(Attribute.CustomString("foo_attribute").WithValue("baz_value"))
    ///     .Apply(Attribute.Name().WithValue("John"))
    ///     .Apply(Attribute.Gender().WithValue(GenderAttribute.Gender.Male))
    ///     .Apply(Attribute.NotificationsEnabled().WithValue(false));
    /// </code>
    /// </p>
    /// </summary>
    public class UserProfile {
        /// <summary>
        /// INTERNAL FIELD.
        /// List of all <see cref="UserProfileUpdate"/> objects.
        /// </summary>
        [NotNull]
        internal readonly List<UserProfileUpdate> UserProfileUpdates;

        /// <summary>
        /// Creates a UserProfile.
        /// 
        /// <p><b>Platforms</b>: Android, iOS.</p>
        /// </summary>
        public UserProfile() {
            UserProfileUpdates = new List<UserProfileUpdate>();
        }

        /// <summary>
        /// Applies user profile update.
        /// <p>Use the <see cref="AppMetrica.ReportUserProfile">AppMetrica.ReportUserProfile(UserProfile)</see>
        /// method to send updated data to the AppMetrica server.</p>
        /// <p>To create a <see cref="UserProfileUpdate"/> object, use methods from the <see cref="Attribute"/>.</p>
        /// 
        /// <p><b>Platforms</b>: Android, iOS.</p>
        /// </summary>
        /// <param name="profileUpdate">The <see cref="UserProfileUpdate"/> object of the attribute update.</param>
        /// <returns>The same <see cref="UserProfile"/> object.</returns>
        [NotNull]
        public UserProfile Apply([NotNull] UserProfileUpdate profileUpdate) {
            UserProfileUpdates.Add(profileUpdate);
            return this;
        }
    }
}
