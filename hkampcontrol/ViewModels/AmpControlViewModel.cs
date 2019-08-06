using hkampcontrol.AmpProfiles;
using System.Collections.ObjectModel;
using System.Linq;

namespace hkampcontrol.ViewModels
{
    public sealed class AmpControlViewModel : ViewModelBase
    {
        private IAmpProfile _selectedProfile;

        public AmpControlViewModel()
            : base()
        {
            this.Profiles = new ObservableCollection<IAmpProfile>(AmpProfiles.AmpProfiles.All);
            this.SelectedProfile = Profiles.FirstOrDefault();
        }

        public ObservableCollection<IAmpProfile> Profiles { get; }

        public IAmpProfile SelectedProfile
        {
            get => this._selectedProfile;
            set
            {
                if (this._selectedProfile != value)
                {
                    this._selectedProfile = value;
                    OnPropertyChanged(nameof(SelectedProfile));
                }
            }
        }
    }
}