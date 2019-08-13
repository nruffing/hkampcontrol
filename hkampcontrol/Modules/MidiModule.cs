using FluentMidi;
using hkampcontrol.AmpProfiles;
using System.Threading.Tasks;

namespace hkampcontrol.Modules
{
    public sealed class MidiModule : IMidiModule
    {
        /// <summary>
        /// Sends a midi event to turn the boost on/off.
        /// </summary>
        /// <param name="isBoostOn">Whether to turn the boost on or off</param>
        /// <param name="profile">The amp profile to use to compile the midi message</param>
        /// <param name="device">The MIDI device to send the message to</param>
        public async Task SetBoostAsync(bool isBoostOn, IAmpProfile profile, IMidiOutputDevice device)
            => await MidiDeviceLocator.SelectForOutput(device.DeviceId)
                .ComposeControlChange()
                .WithControlNumber(profile.Boost)
                .WithValue(this.GetToggleValue(isBoostOn, profile))
                .SendAsync();

        private byte GetToggleValue(bool toggleValue, IAmpProfile profile)
            => toggleValue ? profile.ToggleOnValue : profile.ToggleOffValue;
    }
}