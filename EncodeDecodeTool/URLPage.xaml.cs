using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Web;
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
    public sealed partial class URLPage : Page
    {
        public URLPage()
        {
            this.InitializeComponent();
        }

        private Encoding GetEncodingFromComboBoxItem()
        {
            if (URLEncoding.SelectedItem == Encoding_ASCII)
            {
                return Encoding.ASCII;
            }
            else if (URLEncoding.SelectedItem == Encoding_BigEndianUnicode)
            {
                return Encoding.BigEndianUnicode;
            }
            else if (URLEncoding.SelectedItem == Encoding_Default)
            {
                return Encoding.Default;
            }
            else if (URLEncoding.SelectedItem == Encoding_Unicode)
            {
                return Encoding.Unicode;
            }
            else if (URLEncoding.SelectedItem == Encoding_UTF32)
            {
                return Encoding.UTF32;
            }
            else if (URLEncoding.SelectedItem == Encoding_UTF8)
            {
                return Encoding.UTF8;
            }
            return null;
        }

        private void Encode_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (EncodePath.IsChecked == true)
                {
                    Encoded.Text = HttpUtility.UrlPathEncode(Decoded.Text);
                }
                else
                {
                    Encoded.Text = HttpUtility.UrlEncode(Decoded.Text, GetEncodingFromComboBoxItem());
                }
            }
            catch
            {
                Utils.Dialog("Error", "Error occurred while encoding.");
            }
        }

        private void Decode_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Decoded.Text = HttpUtility.UrlDecode(Encoded.Text, GetEncodingFromComboBoxItem());
            }
            catch
            {
                Utils.Dialog("Error", "Error occurred while decoding.");
            }
        }
    }
}
