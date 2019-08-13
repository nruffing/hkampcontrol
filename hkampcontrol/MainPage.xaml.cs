﻿using Windows.UI.Xaml.Controls;
using System.Linq;
using hkampcontrol.Views;

namespace hkampcontrol
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void NavigationView_Loaded(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            _nav.SelectedItem = _nav.MenuItems.First();
            _nav.IsPaneOpen = false;
            _view.Navigate(typeof(AmpControlPage));
        }

        private void NavigationView_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            TextBlock ItemContent = args.InvokedItem as TextBlock;
            if (ItemContent != null)
            {
                switch (ItemContent.Tag)
                {
                    case "AmpControlPage":
                        _view.Navigate(typeof(AmpControlPage));
                        break;
                }
            }
        }
    }
}