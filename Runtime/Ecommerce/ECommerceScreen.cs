using JetBrains.Annotations;
using System.Collections.Generic;

namespace Io.AppMetrica.Ecommerce {
    /// <summary>
    /// Describes a screen (page).
    /// </summary>
    public class ECommerceScreen {
        /// <summary>
        /// Path to the screen.
        /// 
        /// <p><b>Platforms</b>: Android, iOS.</p>
        /// </summary>
        [CanBeNull]
        public IEnumerable<string> CategoriesPath { get; set; }

        /// <summary>
        /// Name of the screen.
        /// 
        /// <p><b>Platforms</b>: Android, iOS.</p>
        /// </summary>
        [CanBeNull]
        public string Name { get; set; }

        /// <summary>
        /// Additional key-value structured data with various content.
        /// 
        /// <p><b>Platforms</b>: Android, iOS.</p>
        /// </summary>
        [CanBeNull]
        public IDictionary<string, string> Payload { get; set; }

        /// <summary>
        /// Search query.
        /// 
        /// <p><b>Platforms</b>: Android, iOS.</p>
        /// </summary>
        [CanBeNull]
        public string SearchQuery { get; set; }

        /// <summary>
        /// Creates a screen.
        /// </summary>
        public ECommerceScreen() { }
    }
}
