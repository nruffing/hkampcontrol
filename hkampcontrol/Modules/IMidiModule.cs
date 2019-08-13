using FluentMidi;
using hkampcontrol.AmpProfiles;
using System.Threading.Tasks;

namespace hkampcontrol.Modules
{
    public interface IMidiModule
    {
        /// <summary>
        /// Sends a midi event to turn the boost on/off.
        /// </summary>
        /// <param name="isBoostOn">Whether to turn the boost on or off</param>
        /// <param name="profile">The amp profile to use to compile the midi message</param>
        /// <param name="device">The MIDI device to send the message to</param>
        /// <param name="channel">The MIDI channel to send the message on</param>
        Task SetBoostAsync(bool isBoostOn, IAmpProfile profile, IMidiOutputDevice device, byte channel);
    }
}