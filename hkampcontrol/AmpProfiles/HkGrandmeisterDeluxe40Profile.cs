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
        /// Gets the value to send to turn on a toggle control (e.g. Boost On/Off). A value
        /// of 0-63 will set the control off and 64-127 will turn it on. For any value over 127
        /// the higher nibble will be ignored.
        /// </summary>
        public byte ToggleOnValue => 64;

        /// <summary>
        /// Gets the value to send to turn off a toggle control (e.g. Boost On/Off). A value
        /// of 0-63 will set the control off and 64-127 will turn it on. For any value over 127
        /// the higher nibble will be ignored.
        /// </summary>
        public byte ToggleOffValue => 0;

        /// <summary>
        /// Gets the control number for toggling the boost. 
        /// </summary>
        public byte Boost => 64;

        /// <summary>
        /// Gets the control number for the reverb volume
        /// </summary>
        public byte Reverb => 29;
    }
}