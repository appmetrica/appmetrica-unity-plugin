using Io.AppMetrica.Profile;

namespace Io.AppMetrica.Internal.Profile {
    /// <summary>
    /// INTERNAL CLASS.
    /// Use <see cref="Attribute.NotificationsEnabled">Attribute.NotificationsEnabled()</see> for create this UserProfileUpdate.
    /// </summary>
    internal class NotificationsEnabledValueUserProfileUpdate : UserProfileUpdate {
        public readonly bool Value;
        public readonly bool IfUndefined;

        public NotificationsEnabledValueUserProfileUpdate(bool value, bool ifUndefined) {
            Value = value;
            IfUndefined = ifUndefined;
        }
    }

    /// <summary>
    /// INTERNAL CLASS.
    /// Use <see cref="Attribute.NotificationsEnabled">Attribute.NotificationsEnabled()</see> for create this UserProfileUpdate.
    /// </summary>
    internal class NotificationsEnabledResetUserProfileUpdate : UserProfileUpdate { }
}
