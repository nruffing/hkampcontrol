using FluentMidi;
using hkampcontrol.AmpProfiles;
using System.Threading.Tasks;

namespace hkampcontrol.Modules
{
    public interface IMidiModule
    {
        Task SetToggleAsync(bool toggleValue, byte controlNumber, IAmpProfile profile, IMidiOutputDevice device, byte channel);

        Task SetValueAsync(byte value, byte controlNumber, IMidiOutputDevice device, byte channel);
    }
}