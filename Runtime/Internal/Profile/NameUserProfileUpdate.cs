using Io.AppMetrica.Profile;
using JetBrains.Annotations;

namespace Io.AppMetrica.Internal.Profile {
    /// <summary>
    /// INTERNAL CLASS.
    /// Use <see cref="Attribute.Name">Attribute.Name()</see> for create this UserProfileUpdate.
    /// </summary>
    internal class NameValueUserProfileUpdate : UserProfileUpdate {
        [NotNull]
        public readonly string Value;

        public readonly bool IfUndefined;

        public NameValueUserProfileUpdate([NotNull] string value, bool ifUndefined) {
            Value = value;
            IfUndefined = ifUndefined;
        }
    }

    /// <summary>
    /// INTERNAL CLASS.
    /// Use <see cref="Attribute.Name">Attribute.Name()</see> for create this UserProfileUpdate.
    /// </summary>
    internal class NameResetUserProfileUpdate : UserProfileUpdate { }
}
