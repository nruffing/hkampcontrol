namespace hkampcontrol.data.Models
{
    public sealed class Preset
    {
        public Preset(
            long id,
            string name,
            byte bass,
            byte mid,
            byte treble,
            byte presence,
            byte resonance,
            byte volume,
            byte gain,
            byte channel,
            bool isBoostOn,
            bool isNoiseGateOn,
            bool isFxLoopOn,
            bool isReverbOn,
            byte reverbLevel,
            bool isDelayOn,
            byte delayLevel,
            byte delayFeedback,
            byte delayTime,
            bool isModulationOn,
            byte modulationType,
            byte modulationIntensity,
            byte modulationSpeed)
        {
            this.Id = id;
            this.Name = name;
            this.Bass = bass;
            this.Mid = mid;
            this.Treble = treble;
            this.Presence = presence;
            this.Resonance = resonance;
            this.Volume = volume;
            this.Gain = gain;
            this.Channel = channel;
            this.IsBoostOn = isBoostOn;
            this.IsNoiseGateOn = isNoiseGateOn;
            this.IsFxLoopOn = isFxLoopOn;
            this.IsReverbOn = isReverbOn;
            this.ReverbLevel = reverbLevel;
            this.IsDelayOn = isDelayOn;
            this.DelayLevel = delayLevel;
            this.DelayFeedback = delayFeedback;
            this.DelayTime = delayTime;
            this.IsModulationOn = isModulationOn;
            this.ModulationType = modulationType;
            this.ModulationIntensity = modulationIntensity;
            this.ModulationSpeed = modulationSpeed;
        }

        public long Id { get; } 
        public string Name { get; }
        public byte Bass { get; }
        public byte Mid { get; }
        public byte Treble { get; }
        public byte Presence { get; }
        public byte Resonance { get; }
        public byte Volume { get; }
        public byte Gain { get; }
        public byte Channel { get; }
        public bool IsBoostOn { get; }
        public bool IsNoiseGateOn { get; }
        public bool IsFxLoopOn { get; }
        public bool IsReverbOn { get; }
        public byte ReverbLevel { get; }
        public bool IsDelayOn { get; }
        public byte DelayLevel { get; }
        public byte DelayFeedback { get; }
        public byte DelayTime { get; }
        public bool IsModulationOn { get; }
        public byte ModulationType { get; }        
        public byte ModulationIntensity { get; }
        public byte ModulationSpeed { get; }
    }
}