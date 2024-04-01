using Io.AppMetrica.Profile;
using JetBrains.Annotations;

namespace Io.AppMetrica.Internal.Profile {
    /// <summary>
    /// INTERNAL CLASS.
    /// Use <see cref="Attribute.CustomCounter">Attribute.CustomCounter()</see> for create this UserProfileUpdate.
    /// </summary>
    internal class CounterDeltaUserProfileUpdate : UserProfileUpdate {
        [NotNull]
        public readonly string Key;
        public readonly double Delta;

        public CounterDeltaUserProfileUpdate([NotNull] string key, double delta) {
            Key = key;
            Delta = delta;
        }
    }
}
