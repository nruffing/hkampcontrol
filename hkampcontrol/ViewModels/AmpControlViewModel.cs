using FluentMidi;
using hkampcontrol.AmpProfiles;
using hkampcontrol.Modules;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace hkampcontrol.ViewModels
{
    public sealed class AmpControlViewModel : ViewModelBase
    {
        private IMidiModule _module;
        private IAmpProfile _selectedProfile;
        private IMidiOutputDevice _selectedDevice;

        private bool _isBoostOn;

        public AmpControlViewModel()
            : base()
        {
            this._module = new MidiModule();

            this.Profiles = new ObservableCollection<IAmpProfile>(AmpProfiles.AmpProfiles.All);
            this.SelectedProfile = this.Profiles.FirstOrDefault();

            this.Devices = new ObservableCollection<IMidiOutputDevice>();

            this.IsBoostOn = false;
        }

        public ObservableCollection<IAmpProfile> Profiles { get; }

        public ObservableCollection<IMidiOutputDevice> Devices { get; }

        public IAmpProfile SelectedProfile
        {
            get => this._selectedProfile;
            set
            {
                if (this._selectedProfile != value)
                {
                    this._selectedProfile = value;
                    this.OnPropertyChanged(nameof(SelectedProfile));
                }
            }
        }

        public IMidiOutputDevice SelectedDevice
        {
            get => this._selectedDevice;
            set
            {
                if (this._selectedDevice != value)
                {
                    this._selectedDevice = value;
                    this.OnPropertyChanged(nameof(SelectedDevice));
                }
            }
        }

        public bool IsBoostOn
        {
            get => this._isBoostOn;
            set
            {
                if (this._isBoostOn != value)
                {
                    this._isBoostOn = value;
                    OnPropertyChanged(nameof(IsBoostOn));
                    this._module.SetBoostAsync(this.IsBoostOn, this.SelectedProfile, this.SelectedDevice);
                }
            }
        }

        public void SetDevices(IEnumerable<IMidiOutputDevice> devices)
        {
            foreach (IMidiOutputDevice device in devices)
            {
                this.Devices.Add(device);
            }

            this.SelectedDevice = this.Devices.First();
            OnPropertyChanged(nameof(Devices));
        }
    }
}