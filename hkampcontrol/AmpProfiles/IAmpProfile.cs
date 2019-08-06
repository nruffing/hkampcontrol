namespace hkampcontrol.AmpProfiles
{
    /// <summary>
    /// Interface that defines an amplifier profile containing the controller number for each possible 
    /// control change event.
    /// </summary>
    public interface IAmpProfile
    {
        /// <summary>
        /// Gets the display name for the amp profile.
        /// </summary>
        string DisplayName { get; }

        /// <summary>
        /// Gets the control number for toggling the boost. It is assumed that sending a value
        /// of 0-63 will turn the boost off and 64-127 will turn it on. For any value over 127
        /// the higher nibble will be ignored.
        /// </summary>
        byte Boost { get; }
    }
}