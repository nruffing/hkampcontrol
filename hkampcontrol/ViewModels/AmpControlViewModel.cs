using FluentMidi;
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
        private const byte DefaultBalancedValue = 64;

        private IMidiModule _module;
        private IAmpProfile _selectedProfile;
        private IMidiOutputDevice _selectedDevice;
        private byte _selectedChannel;

        private byte _bass = DefaultBalancedValue;
        private byte _mid = DefaultBalancedValue;
        private byte _treble = DefaultBalancedValue;
        private byte _presence = DefaultBalancedValue;
        private byte _resonance = DefaultBalancedValue;

        private byte _volume = DefaultBalancedValue;
        private byte _gain = DefaultBalancedValue;

        private Channel _channel;
        private PowerSoak _powerSoak;

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

        public int Bass
        {
            get => this._bass;
            set
            {
                if (this._bass != value)
                {
                    this._bass = (byte)value;
                    OnPropertyChanged(nameof(Bass));
                    SendBass();
                }
            }
        }

        public int Mid
        {
            get => this._mid;
            set
            {
                if (this._mid != value)
                {
                    this._mid = (byte)value;
                    OnPropertyChanged(nameof(Mid));
                    SendMid();
                }
            }
        }

        public int Treble
        {
            get => this._treble;
            set
            {
                if (this._treble != value)
                {
                    this._treble = (byte)value;
                    OnPropertyChanged(nameof(Treble));
                    SendTreble();
                }
            }
        }

        public int Presence
        {
            get => this._presence;
            set
            {
                if (this._presence != value)
                {
                    this._presence = (byte)value;
                    OnPropertyChanged(nameof(Presence));
                    SendPresence();
                }
            }
        }

        public int Resonance
        {
            get => this._resonance;
            set
            {
                if (this._resonance != value)
                {
                    this._resonance = (byte)value;
                    OnPropertyChanged(nameof(Resonance));
                    SendResonance();
                }
            }
        }

        public int Volume
        {
            get => this._volume;
            set
            {
                if (this._volume != value)
                {
                    this._volume = (byte)value;
                    OnPropertyChanged(nameof(Volume));
                    SendVolume();
                }
            }
        }

        public int Gain
        {
            get => this._gain;
            set
            {
                if (this._gain != value)
                {
                    this._gain = (byte)value;
                    OnPropertyChanged(nameof(Gain));
                    SendGain();
                }
            }
        }

        public Channel Channel
        {
            get => this._channel;
            set
            {
                if (this._channel != value)
                {
                    this._channel = value;
                    OnPropertyChanged(nameof(Channel));
                    SendChannel();
                }
            }
        }

        public PowerSoak PowerSoak
        {
            get => this._powerSoak;
            set
            {
                if (this._powerSoak != value)
                {
                    this._powerSoak = value;
                    OnPropertyChanged(nameof(PowerSoak));
                    SendPowerSoak();
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
                    SendBoost();
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
                    SendNoiseGate();
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
                    SendFxLoop();
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
                    SendReverb();
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
                    SendReverbLevel();
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
                    SendDelay();
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
                    SendDelayLevel();
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
                    SendFeedback();
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
                    SendTime();
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
                    SendModSpeed();
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
                    SendModType();
                    // Modulation type can effect the speed so we should we resend speed
                    this.SendModSpeed();
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
                    SendModIntensity();
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
                    this.SendModSpeed();
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

        public void ResetEqualization()
        {
            this.Bass = DefaultBalancedValue;
            this.Mid = DefaultBalancedValue;
            this.Treble = DefaultBalancedValue;
            this.Presence = DefaultBalancedValue;
            this.Resonance = DefaultBalancedValue;
        }

        public void SyncAll()
        {
            SendBass();
            SendMid();
            SendTreble();
            SendPresence();
            SendResonance();
            SendGain();
            SendChannel();
            SendPowerSoak();
            SendBoost();
            SendNoiseGate();
            SendFxLoop();
            SendReverb();
            SendReverbLevel();
            SendDelay();
            SendDelayLevel();
            SendFeedback();
            SendTime();
            SendModulation();
            SendModType();
            SendModIntensity();
            SendModSpeed();
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

        private byte GetChannelValue()
        {
            switch (this._channel)
            {
                case Channel.Clean:
                    return this.SelectedProfile.CleanChannelValue;
                case Channel.Crunch:
                    return this.SelectedProfile.CrunchChannelValue;
                case Channel.Lead:
                    return this.SelectedProfile.LeadChannelValue;
                case Channel.Ultra:
                    return this.SelectedProfile.UltraChannelValue;
                default:
                    throw new NotImplementedException($"Unknown {nameof(Channel)} detected");
            }
        }

        private byte GetPowerSoakValue()
        {
            switch (this._powerSoak)
            {
                case PowerSoak.SpeakerOff:
                    return this.SelectedProfile.SpeakerOffValue;
                case PowerSoak.OneWatt:
                    return this.SelectedProfile.OneWattValue;
                case PowerSoak.FiveWatt:
                    return this.SelectedProfile.FiveWattValue;
                case PowerSoak.TwentyWatt:
                    return this.SelectedProfile.TwentyWattValue;
                case PowerSoak.Off:
                    return this.SelectedProfile.PowerSoakOff;
                default:
                    throw new NotImplementedException($"Unknown {nameof(PowerSoak)} detected");
            }
        }

        private void SendBass()
            => this._module.SetValueAsync(this._bass, this.SelectedProfile.Bass, this.SelectedDevice, this.SelectedChannel);

        private void SendMid()
            => this._module.SetValueAsync(this._mid, this.SelectedProfile.Mid, this.SelectedDevice, this.SelectedChannel);

        private void SendTreble()
            => this._module.SetValueAsync(this._treble, this.SelectedProfile.Treble, this.SelectedDevice, this.SelectedChannel);

        private void SendPresence()
            => this._module.SetValueAsync(this._presence, this.SelectedProfile.Presence, this.SelectedDevice, this.SelectedChannel);

        private void SendResonance()
            => this._module.SetValueAsync(this._resonance, this.SelectedProfile.Resonance, this.SelectedDevice, this.SelectedChannel);

        private void SendVolume()
            => this._module.SetValueAsync(this._volume, this.SelectedProfile.Volume, this.SelectedDevice, this.SelectedChannel);

        private void SendGain()
            => this._module.SetValueAsync(this._gain, this.SelectedProfile.Gain, this.SelectedDevice, this.SelectedChannel);

        private void SendChannel()
            => this._module.SetValueAsync(this.GetChannelValue(), this.SelectedProfile.Channel, this.SelectedDevice, this.SelectedChannel);

        private void SendPowerSoak()
            => this._module.SetValueAsync(this.GetPowerSoakValue(), this.SelectedProfile.PowerSoak, this.SelectedDevice, this.SelectedChannel);

        private void SendBoost()
            => this._module.SetToggleAsync(this._isBoostOn, this.SelectedProfile.Boost, this.SelectedProfile, this.SelectedDevice, this.SelectedChannel);

        private void SendNoiseGate()
            => this._module.SetToggleAsync(this._isNoiseGateOn, this.SelectedProfile.NoiseGate, this.SelectedProfile, this.SelectedDevice, this.SelectedChannel);

        private void SendFxLoop()
            => this._module.SetToggleAsync(this._isFxLoopOn, this.SelectedProfile.FxLoop, this.SelectedProfile, this.SelectedDevice, this.SelectedChannel);

        private void SendReverb()
            => this._module.SetToggleAsync(this._isReverbOn, this.SelectedProfile.ReverbToggle, this.SelectedProfile, this.SelectedDevice, this.SelectedChannel);

        private void SendReverbLevel()
            => this._module.SetValueAsync(this._reverbLevel, this.SelectedProfile.Reverb, this.SelectedDevice, this.SelectedChannel);

        private void SendDelay()
            => this._module.SetToggleAsync(this._isDelayOn, this.SelectedProfile.DelayToggle, this.SelectedProfile, this.SelectedDevice, this.SelectedChannel);

        private void SendDelayLevel()
            => this._module.SetValueAsync(this._delayLevel, this.SelectedProfile.Delay, this.SelectedDevice, this.SelectedChannel);

        private void SendFeedback()
            => this._module.SetValueAsync(this._delayFeedback, this.SelectedProfile.DelayFeedback, this.SelectedDevice, this.SelectedChannel);

        private void SendTime()
            => this._module.SetValueAsync(this._delayTime, this.SelectedProfile.DelayTime, this.SelectedDevice, this.SelectedChannel);

        private void SendModulation()
            => this._module.SetToggleAsync(this._isModOn, this.SelectedProfile.ModToggle, this.SelectedProfile, this.SelectedDevice, this.SelectedChannel);

        private void SendModType() 
            => this._module.SetValueAsync(this.GetModulationTypeValue(), this.SelectedProfile.ModType, this.SelectedDevice, this.SelectedChannel);

        private void SendModIntensity()
            => this._module.SetValueAsync(this._modIntensity, this.SelectedProfile.ModIntensity, this.SelectedDevice, this.SelectedChannel);

        private void SendModSpeed()
            => this._module.SetValueAsync(this._modIntensity, this.SelectedProfile.ModSpeed, this.SelectedDevice, this.SelectedChannel);
    }
}