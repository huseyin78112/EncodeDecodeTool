using System;
using System.Collections.Generic;
using System.Globalization;
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
    public sealed partial class IDNPage : Page
    {
        public IDNPage()
        {
            this.InitializeComponent();
        }

        private IdnMapping mapping = new IdnMapping();

        private void Encode_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                IDN.Text = mapping.GetAscii(Text.Text);
            }
            catch (ArgumentException)
            {
                Utils.Dialog("Error", "Text is invalid");
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
                Text.Text = mapping.GetUnicode(IDN.Text);
            }
            catch (ArgumentException)
            {
                Utils.Dialog("Error", "Punycode is invalid");
            }
            catch
            {
                Utils.Dialog("Error", "Error occurred while decoding.");
            }
        }
    }
}
