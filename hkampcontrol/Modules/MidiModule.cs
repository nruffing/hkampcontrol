using FluentMidi;
using hkampcontrol.AmpProfiles;
using System.Threading.Tasks;

namespace hkampcontrol.Modules
{
    public sealed class MidiModule : IMidiModule
    {
        public async Task SetToggleAsync(bool toggleValue, byte controlNumber, IAmpProfile profile, IMidiOutputDevice device, byte channel)
            => await MidiDeviceLocator.SelectForOutput(device.DeviceId)
                .ComposeControlChange()
                .WithChannel(channel)
                .WithControlNumber(controlNumber)
                .WithValue(this.GetToggleValue(toggleValue, profile))
                .SendAsync();

        public async Task SetValueAsync(byte value, byte controlNumber, IMidiOutputDevice device, byte channel)
            => await MidiDeviceLocator.SelectForOutput(device.DeviceId)
                .ComposeControlChange()
                .WithChannel(channel)
                .WithControlNumber(controlNumber)
                .WithValue(value)
                .SendAsync();

        private byte GetToggleValue(bool toggleValue, IAmpProfile profile)
            => toggleValue ? profile.ToggleOnValue : profile.ToggleOffValue;
    }
}