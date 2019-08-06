using System.Collections.Generic;

namespace hkampcontrol.AmpProfiles
{
    public static class AmpProfiles
    {
        /// <summary>
        /// Gets a static collection of all known amp profiles.
        /// </summary>
        public static IEnumerable<IAmpProfile> All => new IAmpProfile[]
        {
            new HkGrandmeisterDeluxe40Profile()
        };
    }
}