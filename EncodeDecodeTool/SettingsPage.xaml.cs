using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Boş Sayfa öğe şablonu https://go.microsoft.com/fwlink/?LinkId=234238 adresinde açıklanmaktadır

namespace EncodeDecodeTool
{
    /// <summary>
    /// Kendi başına kullanılabilecek ya da bir Çerçeve içine gezinebilecek boş bir sayfa.
    /// </summary>
    public sealed partial class SettingsPage : Page
    {
        public SettingsPage()
        {
            this.InitializeComponent();
            RadioButton item = null;
            ElementTheme theme = Utils.GetTheme();
            if (theme == ElementTheme.Default)
            {
                item = AppSystemTheme;
            }
            else if (theme == ElementTheme.Light)
            {
                item = AppLightTheme;
            }
            else if (theme == ElementTheme.Dark)
            {
                item = AppDarkTheme;
            }
            ThemeRadioButtons.SelectedItem = item;
        }

        private void ThemeRadioButtons_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ThemeRadioButtons.SelectedItem == AppSystemTheme)
            {
                Utils.SetTheme(ElementTheme.Default);
            }
            else if (ThemeRadioButtons.SelectedItem == AppLightTheme)
            {
                Utils.SetTheme(ElementTheme.Light);
            }
            else if (ThemeRadioButtons.SelectedItem == AppDarkTheme)
            {
                Utils.SetTheme(ElementTheme.Dark);
            }
        }
    }
}
