using JetBrains.Annotations;

namespace Io.AppMetrica.Ecommerce {
    /// <summary>
    /// Describes transition source - screen which shown screen, product card, etc.
    /// </summary>
    public class ECommerceReferrer {
        /// <summary>
        /// Identifier of object used to perform a transition.
        /// 
        /// <p><b>Platforms</b>: Android, iOS.</p>
        /// </summary>
        [CanBeNull]
        public string Identifier { get; set; }

        /// <summary>
        /// Screen from which the transition started.
        /// 
        /// <p><b>Platforms</b>: Android, iOS.</p>
        /// </summary>
        [CanBeNull]
        public ECommerceScreen Screen { get; set; }

        /// <summary>
        /// Type of object used to perform a transition.
        /// For example: "button", "banner", etc.
        /// 
        /// <p><b>Platforms</b>: Android, iOS.</p>
        /// </summary>
        [CanBeNull]
        public string Type { get; set; }

        /// <summary>
        /// Creates a referrer.
        /// </summary>
        public ECommerceReferrer() { }
    }
}
