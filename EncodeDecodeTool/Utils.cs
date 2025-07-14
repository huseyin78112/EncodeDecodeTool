using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace EncodeDecodeTool
{
    public class Utils
    {
        public static async void Dialog(string title, string content)
        {
            try
            {
                ContentDialog dlg = new ContentDialog();
                dlg.Title = title;
                dlg.Content = content;
                dlg.PrimaryButtonText = "OK";
                dlg.DefaultButton = ContentDialogButton.Primary;
                await dlg.ShowAsync();
            }
            catch { }
        }
    }
}
