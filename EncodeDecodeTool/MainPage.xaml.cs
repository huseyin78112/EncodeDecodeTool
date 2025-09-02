using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.System.Profile;
using Windows.UI;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

// Boş Sayfa öğe şablonu https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x41f adresinde açıklanmaktadır

namespace EncodeDecodeTool
{
    /// <summary>
    /// Kendi başına kullanılabilecek ya da bir Çerçeve içine taşınabilecek boş bir sayfa.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            Navigator.SelectedItem = Home;
            NavigatePage(typeof(HomePage), new EntranceNavigationTransitionInfo());
            CoreApplicationViewTitleBar titlebar = CoreApplication.GetCurrentView().TitleBar;
            titlebar.ExtendViewIntoTitleBar = true;
            Window.Current.SetTitleBar(AppTitleBar);
            var titlebar2 = ApplicationView.GetForCurrentView().TitleBar;
            titlebar2.ButtonBackgroundColor = Colors.Transparent;
        }
        private void NavigatePage(
    Type pageType,
    NavigationTransitionInfo transitionInfo)
        {
            Type preNavPageType = ContentFrame.CurrentSourcePageType;
            if (pageType != null && !Type.Equals(preNavPageType, pageType))
            {
                ContentFrame.Navigate(pageType, null, transitionInfo);
            }
        }

        private void Navigator_ItemInvoked(Microsoft.UI.Xaml.Controls.NavigationView sender, Microsoft.UI.Xaml.Controls.NavigationViewItemInvokedEventArgs args)
        {
            if (args.InvokedItemContainer != null)
            {
                Type navPageType = Type.GetType(args.InvokedItemContainer.Tag.ToString());
                NavigatePage(navPageType, args.RecommendedNavigationTransitionInfo);
            }
        }
    }
}
