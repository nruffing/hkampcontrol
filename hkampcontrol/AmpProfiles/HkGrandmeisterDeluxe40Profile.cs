namespace hkampcontrol.AmpProfiles
{
    /// <summary>
    /// Implementation that defines an amplifier profile for the Hughes & Kettner GrandMeister Deluxe 40
    /// containing the controller number for each possible control change event.
    /// http://hughes-and-kettner.com/products/grandmeister/grandmeister-deluxe-40/
    /// </summary>
    public class HkGrandmeisterDeluxe40Profile : IAmpProfile
    {
        /// <summary>
        /// Gets the display name for the amp profile.
        /// </summary>
        public string DisplayName => "Hughes & Kettner GrandMeister Deluxe 40";

        /// <summary>
        /// Gets the control number for toggling the boost. It is assumed that sending a value
        /// of 0-63 will turn the boost off and 64-127 will turn it on. For any value over 127
        /// the higher nibble will be ignored.
        /// </summary>
        public byte Boost => 64;        
    }
}