using Io.AppMetrica.Profile;

namespace Io.AppMetrica.Internal.Profile {
    /// <summary>
    /// INTERNAL CLASS.
    /// Use <see cref="Attribute.Gender">Attribute.Gender()</see> for create this UserProfileUpdate.
    /// </summary>
    internal class GenderValueUserProfileUpdate : UserProfileUpdate {
        public readonly GenderAttribute.Gender Value;
        public readonly bool IfUndefined;

        public GenderValueUserProfileUpdate(GenderAttribute.Gender value, bool ifUndefined) {
            Value = value;
            IfUndefined = ifUndefined;
        }
    }

    /// <summary>
    /// INTERNAL CLASS.
    /// Use <see cref="Attribute.Gender">Attribute.Gender()</see> for create this UserProfileUpdate.
    /// </summary>
    internal class GenderResetUserProfileUpdate : UserProfileUpdate { }
}
