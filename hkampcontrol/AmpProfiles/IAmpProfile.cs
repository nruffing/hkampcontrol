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

        /// <summary>
        /// Gets the control number for toggling the noise gate
        /// </summary>
        byte NoiseGate { get; }

        /// <summary>
        /// Gets the control number for toggling the FX loop
        /// </summary>
        byte FxLoop { get; }

        /// <summary>
        /// Gets the control number for toggling the reverb
        /// </summary>
        byte ReverbToggle { get; }

        /// <summary>
        /// Gets the control number for the reverb volume
        /// </summary>
        byte Reverb { get; }

        /// <summary>
        /// Gets the control number for toggling the delay
        /// </summary>
        byte DelayToggle { get; }        

        /// <summary>
        /// Gets the control number for the delay volume
        /// </summary>
        byte Delay { get; }

        /// <summary>
        /// Gets the control number for the delay feedback
        /// </summary>
        byte DelayFeedback { get; }

        /// <summary>
        /// Gets the control number for the delay time
        /// </summary>
        byte DelayTime { get; }

        /// <summary>
        /// Gets the control number for the modulation type
        /// </summary>
        byte ModType { get; }

        /// <summary>
        /// Gets the value to send to set the modulation type to to turn modulation on/off
        /// </summary>
        byte ModToggle { get; }

        /// <summary>
        /// Gets the value to send to set the modulation type to chorus
        /// </summary>
        byte ModTypeChorus { get; }

        /// <summary>
        /// Gets the value to send to set the modulation type to flanger
        /// </summary>
        byte ModTypeFlanger { get; }

        /// <summary>
        /// Gets the value to send to set the modulation type to phaser
        /// </summary>
        byte ModTypePhaser { get; }

        /// <summary>
        /// Gets the value to send to set the modulation type tremelo
        /// </summary>
        byte ModTypeTremelo { get; }

        /// <summary>
        /// Gets the value to send to set the modulation intensity
        /// </summary>
        byte ModIntensity { get; }

        /// <summary>
        /// Gets the value to send to set the modulation speed
        /// </summary>
        byte ModSpeed { get; }        

        /// <summary>
        /// Gets the control number for bass
        /// </summary>
        byte Bass { get; }

        /// <summary>
        /// Gets the control number for mid
        /// </summary>
        byte Mid { get; }

        /// <summary>
        /// Gets the control number for treble
        /// </summary>
        byte Treble { get; }

        /// <summary>
        /// Gets the control number for presence
        /// </summary>
        byte Presence { get; }

        /// <summary>
        /// Gets the control number for resonance
        /// </summary>
        byte Resonance { get; }

        /// <summary>
        /// Gets the control number for volume
        /// </summary>
        byte Volume { get; }

        /// <summary>
        /// Gets the control number for gain
        /// </summary>
        byte Gain { get; }

        /// <summary>
        /// Gets the control number for changing the channel
        /// </summary>
        byte Channel { get; }

        /// <summary>
        /// Gets the value to send for the channel for clean
        /// </summary>
        byte CleanChannelValue { get; }

        /// <summary>
        /// Gets the value to send for the channel for crunch
        /// </summary>
        byte CrunchChannelValue { get; }

        /// <summary>
        /// Gets the value to send for the channel for lead
        /// </summary>
        byte LeadChannelValue { get; }

        /// <summary>
        /// Gets the value to send for the channel for ultra
        /// </summary>
        byte UltraChannelValue { get; }

        /// <summary>
        /// Gets the control number for changing the power soak setting
        /// </summary>
        byte PowerSoak { get; }

        /// <summary>
        /// Gets the value to send for the power soak for turning the speaker output off
        /// </summary>
        byte SpeakerOffValue { get; }

        /// <summary>
        /// Gets the value to send for the power soak for setting it to 1W
        /// </summary>
        byte OneWattValue { get; }

        /// <summary>
        /// Gets the value to send for the power soak for setting it to 5W
        /// </summary>
        byte FiveWattValue { get; }

        /// <summary>
        /// Gets the value to send for the power soak for setting it to 20W
        /// </summary>
        byte TwentyWattValue { get; }

        /// <summary>
        /// Gets the value to send for the power soak for turning it off (40W)
        /// </summary>
        byte PowerSoakOff { get; }
    }
}