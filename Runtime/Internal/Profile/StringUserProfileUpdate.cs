using Io.AppMetrica.Profile;
using JetBrains.Annotations;

namespace Io.AppMetrica.Internal.Profile {
    /// <summary>
    /// INTERNAL CLASS.
    /// Use <see cref="Attribute.CustomString">Attribute.CustomString()</see> for create this UserProfileUpdate.
    /// </summary>
    internal class StringValueUserProfileUpdate : UserProfileUpdate {
        [NotNull]
        public readonly string Key;

        [NotNull]
        public readonly string Value;

        public readonly bool IfUndefined;

        public StringValueUserProfileUpdate([NotNull] string key, [NotNull] string value, bool ifUndefined) {
            Key = key;
            Value = value;
            IfUndefined = ifUndefined;
        }
    }

    /// <summary>
    /// INTERNAL CLASS.
    /// Use <see cref="Attribute.CustomString">Attribute.CustomString()</see> for create this UserProfileUpdate.
    /// </summary>
    internal class StringResetUserProfileUpdate : UserProfileUpdate {
        [NotNull]
        public readonly string Key;

        public StringResetUserProfileUpdate([NotNull] string key) {
            Key = key;
        }
    }
}
