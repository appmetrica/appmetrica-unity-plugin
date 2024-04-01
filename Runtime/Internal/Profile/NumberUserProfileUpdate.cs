using Io.AppMetrica.Profile;
using JetBrains.Annotations;

namespace Io.AppMetrica.Internal.Profile {
    /// <summary>
    /// INTERNAL CLASS.
    /// Use <see cref="Attribute.CustomNumber">Attribute.CustomNumber()</see> for create this UserProfileUpdate.
    /// </summary>
    internal class NumberValueUserProfileUpdate : UserProfileUpdate {
        [NotNull]
        public readonly string Key;

        public readonly double Value;
        public readonly bool IfUndefined;

        public NumberValueUserProfileUpdate([NotNull] string key, double value, bool ifUndefined) {
            Key = key;
            Value = value;
            IfUndefined = ifUndefined;
        }
    }

    /// <summary>
    /// INTERNAL CLASS.
    /// Use <see cref="Attribute.CustomNumber">Attribute.CustomNumber()</see> for create this UserProfileUpdate.
    /// </summary>
    internal class NumberResetUserProfileUpdate : UserProfileUpdate {
        [NotNull]
        public readonly string Key;

        public NumberResetUserProfileUpdate([NotNull] string key) {
            Key = key;
        }
    }
}
