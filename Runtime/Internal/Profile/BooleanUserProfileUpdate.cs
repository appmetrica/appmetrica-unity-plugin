using Io.AppMetrica.Profile;
using JetBrains.Annotations;

namespace Io.AppMetrica.Internal.Profile {
    /// <summary>
    /// INTERNAL CLASS.
    /// Use <see cref="Attribute.CustomBoolean">Attribute.CustomBoolean()</see> for create this UserProfileUpdate.
    /// </summary>
    internal class BooleanValueUserProfileUpdate : UserProfileUpdate {
        [NotNull]
        public readonly string Key;

        public readonly bool Value;
        public readonly bool IfUndefined;

        public BooleanValueUserProfileUpdate([NotNull] string key, bool value, bool ifUndefined) {
            Key = key;
            Value = value;
            IfUndefined = ifUndefined;
        }
    }

    /// <summary>
    /// INTERNAL CLASS.
    /// Use <see cref="Attribute.CustomBoolean">Attribute.CustomBoolean()</see> for create this UserProfileUpdate.
    /// </summary>
    internal class BooleanResetUserProfileUpdate : UserProfileUpdate {
        [NotNull]
        public readonly string Key;

        public BooleanResetUserProfileUpdate([NotNull] string key) {
            Key = key;
        }
    }
}
