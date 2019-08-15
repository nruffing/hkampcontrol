﻿using FluentMidi;
using hkampcontrol.AmpProfiles;
using hkampcontrol.Models;
using hkampcontrol.Modules;
using System;
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

        private bool _isReverbOn;
        private byte _reverbLevel;

        private bool _isDelayOn;
        private byte _delayLevel;
        private byte _delayFeedback;
        private byte _delayTime;

        private bool _isModOn;
        private ModulationType _modType;
        private byte _modIntensity;
        private byte _modSpeed;

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
        
        public bool IsReverbOn
        {
            get => this._isReverbOn;
            set
            {
                if (this._isReverbOn != value)
                {
                    this._isReverbOn = value;
                    OnPropertyChanged(nameof(IsReverbOn));
                    this._module.SetToggleAsync(this.IsReverbOn, this.SelectedProfile.ReverbToggle, this.SelectedProfile, this.SelectedDevice, this.SelectedChannel);
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
                    this.IsReverbOn = true;
                }
            }
        }

        public bool IsDelayOn
        {
            get => this._isDelayOn;
            set
            {
                if (this._isDelayOn != value)
                {
                    this._isDelayOn = value;
                    OnPropertyChanged(nameof(IsDelayOn));
                    this._module.SetToggleAsync(this.IsDelayOn, this.SelectedProfile.DelayToggle, this.SelectedProfile, this.SelectedDevice, this.SelectedChannel);
                }
            }
        }

        public int DelayLevel
        {
            get => this._delayLevel;
            set
            {
                if (this._delayLevel != value)
                {
                    this._delayLevel = (byte)value;
                    OnPropertyChanged(nameof(DelayLevel));
                    this._module.SetValueAsync(this._delayLevel, this.SelectedProfile.Delay, this.SelectedDevice, this.SelectedChannel);
                    this.IsDelayOn = true;
                }
            }
        }

        public int DelayFeedback
        {
            get => this._delayFeedback;
            set
            {
                if (this._delayFeedback != value)
                {
                    this._delayFeedback = (byte)value;
                    OnPropertyChanged(nameof(DelayFeedback));
                    this._module.SetValueAsync(this._delayFeedback, this.SelectedProfile.DelayFeedback, this.SelectedDevice, this.SelectedChannel);
                    this.IsDelayOn = true;
                }
            }
        }

        public int DelayTime
        {
            get => this._delayFeedback;
            set
            {
                if (this._delayTime != value)
                {
                    this._delayTime = (byte)value;
                    OnPropertyChanged(nameof(DelayTime));
                    this._module.SetValueAsync(this._delayTime, this.SelectedProfile.DelayTime, this.SelectedDevice, this.SelectedChannel);
                    this.IsDelayOn = true;
                }
            }
        }

        public bool IsModulationOn
        {
            get => this._isModOn;
            set
            {
                if (this._isModOn != value)
                {
                    this._isModOn = value;
                    OnPropertyChanged(nameof(IsModulationOn));
                    this._module.SetToggleAsync(this.IsModulationOn, this.SelectedProfile.ModToggle, this.SelectedProfile, this.SelectedDevice, this.SelectedChannel);
                }
            }
        }

        public ModulationType ModulationType
        {
            get => this._modType;
            set
            {
                if (this._modType != value)
                {
                    this._modType = value;
                    OnPropertyChanged(nameof(ModulationType));
                    this._module.SetValueAsync(this.GetModulationTypeValue(), this.SelectedProfile.ModType, this.SelectedDevice, this.SelectedChannel);
                    // Modulation type can effect the speed so we should we resend speed
                    this.SendModulationSpeed();
                    this.IsModulationOn = true;
                }
            }
        }

        public int ModulationIntensity
        {
            get => this._modIntensity;
            set
            {
                if (this._modIntensity != value)
                {
                    this._modIntensity = (byte)value;
                    OnPropertyChanged(nameof(ModulationIntensity));
                    this._module.SetValueAsync(this._modIntensity, this.SelectedProfile.ModIntensity , this.SelectedDevice, this.SelectedChannel);
                    this.IsModulationOn = true;
                }
            }
        }
        public int ModulationSpeed
        {
            get => this._modSpeed;
            set
            {
                if (this._modSpeed != value)
                {
                    this._modSpeed = (byte)value;
                    OnPropertyChanged(nameof(ModulationSpeed));
                    this.SendModulationSpeed();
                    this.IsModulationOn = true;
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

        private byte GetModulationTypeValue()
        {
            switch (this._modType)
            {
                case ModulationType.Chorus:
                    return this.SelectedProfile.ModTypeChorus;
                case ModulationType.Flanger:
                    return this.SelectedProfile.ModTypeFlanger;
                case ModulationType.Phaser:
                    return this.SelectedProfile.ModTypePhaser;
                case ModulationType.Tremelo:
                    return this.SelectedProfile.ModTypeTremelo;
                default:
                    throw new NotImplementedException($"Unknown {nameof(ModulationType)} detected");
            }
        }

        private void SendModulationSpeed()
            => this._module.SetValueAsync(this._modIntensity, this.SelectedProfile.ModSpeed, this.SelectedDevice, this.SelectedChannel);
    }
}