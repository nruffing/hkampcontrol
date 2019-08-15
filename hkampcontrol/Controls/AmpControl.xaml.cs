using FluentMidi;
using hkampcontrol.ViewModels;
using Windows.UI.Xaml.Controls;

namespace hkampcontrol.Controls
{
    public sealed partial class AmpControl : UserControl
    {
        public AmpControl()
        {
            this.InitializeComponent();
            this.Loaded += AmpControl_Loaded;
        }

        public AmpControlViewModel ViewModel => (AmpControlViewModel)DataContext;

        private async void AmpControl_Loaded(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            var devices = await MidiDeviceLocator.GetAllOutputDevicesAsync();
            this.ViewModel.SetDevices(devices);
        }

        private void ResetEqualization(object sender, Windows.UI.Xaml.RoutedEventArgs e)
            => this.ViewModel.ResetEqualization();
    }
}