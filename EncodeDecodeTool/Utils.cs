using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace EncodeDecodeTool
{
    public class Utils
    {
        private static ApplicationDataContainer localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
        public static ApplicationDataContainer LocalSettings
        {
            get
            {
                return localSettings;
            }
        }
        public static async void Dialog(string title, string content)
        {
            try
            {
                ContentDialog dlg = new ContentDialog();
                dlg.Title = title;
                dlg.Content = content;
                dlg.PrimaryButtonText = "OK";
                dlg.DefaultButton = ContentDialogButton.Primary;
                dlg.RequestedTheme = GetTheme();
                await dlg.ShowAsync();
            }
            catch { }
        }
        public static void SetTheme(ElementTheme theme)
        {
            ((FrameworkElement)Window.Current.Content).RequestedTheme = theme;
            localSettings.Values["CurrentAppTheme"] = (int)theme;
        }
        public static ElementTheme GetTheme()
        {
            return ((FrameworkElement)Window.Current.Content).RequestedTheme;
        }
        public static ElementTheme GetThemeSetting()
        {
            if (!localSettings.Values.ContainsKey("CurrentAppTheme"))
            {
                localSettings.Values["CurrentAppTheme"] = (int)ElementTheme.Default;
            }
            return (ElementTheme)localSettings.Values["CurrentAppTheme"];
        }
    }
}
