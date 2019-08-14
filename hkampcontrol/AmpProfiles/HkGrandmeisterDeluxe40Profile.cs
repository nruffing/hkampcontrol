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
        /// Gets the control number for toggling the noise gate
        /// </summary>
        public byte NoiseGate => 63;

        /// <summary>
        /// Gets the control number for toggling the FX loop
        /// </summary>
        public byte FxLoop => 55;

        /// <summary>
        /// Gets the control number for toggling the reverb
        /// </summary>
        public byte ReverbToggle => 54;

        /// <summary>
        /// Gets the control number for the reverb volume
        /// </summary>
        public byte Reverb => 29;

        /// <summary>
        /// Gets the control number for toggling the delay
        /// </summary>
        public byte DelayToggle => 53;

        /// <summary>
        /// Gets the control number for the delay volume
        /// </summary>
        public byte Delay => 28;

        /// <summary>
        /// Gets the control number for the delay feedback
        /// </summary>
        public byte DelayFeedback => 27;

        /// <summary>
        /// Gets the control number for the delay time
        /// </summary>
        public byte DelayTime => 4;

        /// <summary>
        /// Gets the control number for the modulation type
        /// </summary>
        public byte ModType => 12;
        
        /// <summary>
        /// Gets the value to send to set the modulation type to to turn modulation off
        /// </summary>
        public byte ModTypeOff => 1;

        /// <summary>
        /// Gets the value to send to set the modulation type to chorus
        /// </summary>
        public byte ModTypeChorus => 1;

        /// <summary>
        /// Gets the value to send to set the modulation type to flanger
        /// </summary>
        public byte ModTypeFlanger => 33;

        /// <summary>
        /// Gets the value to send to set the modulation type to phaser
        /// </summary>
        public byte ModTypePhaser => 65;

        /// <summary>
        /// Gets the value to send to set the modulation type tremelo
        /// </summary>
        public byte ModTypeTremelo => 97;

        /// <summary>
        /// Gets the value to send to set the modulation intensity
        /// </summary>
        public byte ModIntensity => 1;

        /// <summary>
        /// Gets the value to send to set the modulation speed
        /// </summary>
        public byte ModSpeed => 26;
    }
}