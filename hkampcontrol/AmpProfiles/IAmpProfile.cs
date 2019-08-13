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
        /// Gets the value to send to turn on a toggle control (e.g. Boost On/Off)
        /// </summary>
        byte ToggleOnValue { get; }

        /// <summary>
        /// Gets the value to send to turn off a toggle control (e.g. Boost On/Off)
        /// </summary>
        byte ToggleOffValue { get; }

        /// <summary>
        /// Gets the control number for toggling the boost.
        /// </summary>
        byte Boost { get; }
    }
}