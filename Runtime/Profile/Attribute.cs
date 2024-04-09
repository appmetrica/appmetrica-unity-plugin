using JetBrains.Annotations;

namespace Io.AppMetrica.Profile {
    /// <summary>
    /// The attribute class.
    /// <p>Attribute is a property of the user profile.
    /// You can use predefined profiles (e.g. name, gender, etc.) or create your own.</p>
    /// <p>AppMetrica allows you to create up to 100 custom attributes.</p>
    /// <p>Attributes are applied by using the
    /// <see cref="UserProfile.Apply">UserProfile.Apply()</see> method.</p>
    /// </summary>
    public static class Attribute {
        /// <summary>
        /// Creates a birth date attribute.
        /// 
        /// <p><b>Platforms</b>: Android, iOS.</p>
        /// </summary>
        /// <returns>The <see cref="Profile.BirthDateAttribute"/> object.</returns>
        [NotNull]
        public static BirthDateAttribute BirthDate() {
            return new BirthDateAttribute();
        }

        /// <summary>
        /// Creates a custom boolean attribute.
        /// 
        /// <p><b>Platforms</b>: Android, iOS.</p>
        /// </summary>
        /// <param name="key">Attribute key. It can contain up to 200 characters.</param>
        /// <returns>The <see cref="Profile.BooleanAttribute"/> object.</returns>
        [NotNull]
        public static BooleanAttribute CustomBoolean([NotNull] string key) {
            return new BooleanAttribute(key);
        }

        /// <summary>
        /// Creates a custom counter attribute.
        /// 
        /// <p><b>Platforms</b>: Android, iOS.</p>
        /// </summary>
        /// <param name="key">Attribute key. It can contain up to 200 characters.</param>
        /// <returns>The <see cref="Profile.CounterAttribute"/> object.</returns>
        [NotNull]
        public static CounterAttribute CustomCounter([NotNull] string key) {
            return new CounterAttribute(key);
        }

        /// <summary>
        /// Creates a custom number attribute.
        /// 
        /// <p><b>Platforms</b>: Android, iOS.</p>
        /// </summary>
        /// <param name="key">Attribute key. It can contain up to 200 characters.</param>
        /// <returns>The <see cref="Profile.NumberAttribute"/> object.</returns>
        [NotNull]
        public static NumberAttribute CustomNumber([NotNull] string key) {
            return new NumberAttribute(key);
        }

        /// <summary>
        /// Creates a custom string attribute.
        /// 
        /// <p><b>Platforms</b>: Android, iOS.</p>
        /// </summary>
        /// <param name="key">Attribute key. It can contain up to 200 characters.</param>
        /// <returns>The <see cref="Profile.StringAttribute"/> object.</returns>
        [NotNull]
        public static StringAttribute CustomString([NotNull] string key) {
            return new StringAttribute(key);
        }

        /// <summary>
        /// Creates a gender attribute.
        /// 
        /// <p><b>Platforms</b>: Android, iOS.</p>
        /// </summary>
        /// <returns>The <see cref="Profile.GenderAttribute"/> object.</returns>
        [NotNull]
        public static GenderAttribute Gender() {
            return new GenderAttribute();
        }

        /// <summary>
        /// Creates a name attribute.
        /// 
        /// <p><b>Platforms</b>: Android, iOS.</p> 
        /// </summary>
        /// <returns>The <see cref="Profile.NameAttribute"/> object.</returns>
        [NotNull]
        public static NameAttribute Name() {
            return new NameAttribute();
        }

        /// <summary>
        /// Creates a enabled notifications attribute.
        /// It indicates whether the user has enabled notifications for the application.
        /// 
        /// <p><b>Platforms</b>: Android, iOS.</p>
        /// </summary>
        /// <returns>The <see cref="Profile.NotificationsEnabledAttribute"/> object.</returns>
        [NotNull]
        public static NotificationsEnabledAttribute NotificationsEnabled() {
            return new NotificationsEnabledAttribute();
        }
    }
}
