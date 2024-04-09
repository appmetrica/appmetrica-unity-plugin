using Io.AppMetrica.Internal.Profile;
using JetBrains.Annotations;

namespace Io.AppMetrica.Profile {
    /// <summary>
    /// The counter attribute class.
    /// It enables creating custom counter for the user profile.
    /// <p><b>EXAMPLE:</b>
    /// <code>
    /// var userProfile = new UserProfile()
    ///     .Apply(Attribute.CustomCounter("time_left").WithDelta(-10d));
    /// </code>
    /// </p>
    /// </summary>
    public class CounterAttribute {
        private readonly string _key;

        /// <summary>
        /// INTERNAL CONSTRUCTOR.
        /// Use <see cref="Attribute.CustomCounter">Attribute.CustomCounter(string)</see> instead.
        /// </summary>
        internal CounterAttribute([NotNull] string key) {
            _key = key;
        }

        /// <summary>
        /// Updates the counter attribute value with the specified delta value.
        /// 
        /// <p><b>Platforms</b>: Android, iOS.</p>
        /// </summary>
        /// <param name="value">Delta value to change the counter attribute value.</param>
        /// <returns>The <see cref="UserProfileUpdate"/> object.</returns>
        [NotNull]
        public UserProfileUpdate WithDelta(double value) {
            return new CounterDeltaUserProfileUpdate(_key, value);
        }
    }
}
