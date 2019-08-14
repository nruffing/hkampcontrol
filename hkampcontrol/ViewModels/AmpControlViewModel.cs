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
        private byte _selectedChannel;

        private bool _isBoostOn;
        private bool _isNoiseGateOn;
        private bool _isFxLoopOn;

        private byte _reverbLevel;

        public AmpControlViewModel()
            : base()
        {
            this._module = new MidiModule();

            this.Profiles = new ObservableCollection<IAmpProfile>(AmpProfiles.AmpProfiles.All);
            this.SelectedProfile = this.Profiles.FirstOrDefault();

            this.Devices = new ObservableCollection<IMidiOutputDevice>();

            this.Channels = new ObservableCollection<byte>();
            for (byte i = 1; i <= 16; i++)
            {
                this.Channels.Add(i);
            }
            this.SelectedChannel = this.Channels.First();
        }

        public ObservableCollection<IAmpProfile> Profiles { get; }

        public ObservableCollection<IMidiOutputDevice> Devices { get; }

        public ObservableCollection<byte> Channels { get; }

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

        public byte SelectedChannel
        {
            get => this._selectedChannel;
            set
            {
                if (this._selectedChannel != value)
                {
                    this._selectedChannel = value;
                    OnPropertyChanged(nameof(SelectedChannel));
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
                    this._module.SetToggleAsync(this.IsBoostOn, this.SelectedProfile.Boost, this.SelectedProfile, this.SelectedDevice, this.SelectedChannel);
                }
            }
        }

        public bool IsNoiseGateOn
        {
            get => this._isNoiseGateOn;
            set
            {
                if (this._isNoiseGateOn != value)
                {
                    this._isNoiseGateOn = value;
                    OnPropertyChanged(nameof(IsNoiseGateOn));
                    this._module.SetToggleAsync(this.IsNoiseGateOn, this.SelectedProfile.NoiseGate, this.SelectedProfile, this.SelectedDevice, this.SelectedChannel);
                }
            }
        }

        public bool IsFxLoopOn
        {
            get => this._isFxLoopOn;
            set
            {
                if (this._isFxLoopOn != value)
                {
                    this._isFxLoopOn = value;
                    OnPropertyChanged(nameof(IsFxLoopOn));
                    this._module.SetToggleAsync(this.IsFxLoopOn, this.SelectedProfile.FxLoop, this.SelectedProfile, this.SelectedDevice, this.SelectedChannel);
                }
            }
        }

        public int ReverbLevel
        {
            get => this._reverbLevel;
            set
            {
                if (this._reverbLevel != value)
                {
                    this._reverbLevel = (byte)value;
                    OnPropertyChanged(nameof(ReverbLevel));
                    this._module.SetValueAsync(this._reverbLevel, this.SelectedProfile.Reverb, this.SelectedDevice, this.SelectedChannel);
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
        }
    }
}