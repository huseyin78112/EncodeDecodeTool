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
    public sealed partial class HexPage : Page
    {
        public HexPage()
        {
            this.InitializeComponent();
        }
        private Encoding GetEncodingFromComboBoxItem()
        {
            if (HexEncoding.SelectedItem == Encoding_ASCII)
            {
                return Encoding.ASCII;
            }
            else if (HexEncoding.SelectedItem == Encoding_BigEndianUnicode)
            {
                return Encoding.BigEndianUnicode;
            }
            else if (HexEncoding.SelectedItem == Encoding_Default)
            {
                return Encoding.Default;
            }
            else if (HexEncoding.SelectedItem == Encoding_Unicode)
            {
                return Encoding.Unicode;
            }
            else if (HexEncoding.SelectedItem == Encoding_UTF32)
            {
                return Encoding.UTF32;
            }
            else if (HexEncoding.SelectedItem == Encoding_UTF8)
            {
                return Encoding.UTF8;
            }
            return null;
        }
        private string EncodeHex(string text)
        {
            List<string> hexes = new List<string>();
            byte[] byts = GetEncodingFromComboBoxItem().GetBytes(text);
            foreach (byte byt in byts)
            {
                hexes.Add(byt.ToString("X2"));
            }
            return string.Join(' ', hexes);
        }
        private string DecodeHex(string text)
        {
            try
            {
                if (string.IsNullOrEmpty(text))
                {
                    return "";
                }
                string[] hexes = text.Split(' ');
                List<byte> results = new List<byte>();
                foreach (string hex in hexes)
                {
                    results.Add(byte.Parse(hex, System.Globalization.NumberStyles.HexNumber));
                }
                return GetEncodingFromComboBoxItem().GetString(results.ToArray());
            }
            catch (Exception ex)
            {
                if (!(ex is FormatException))
                {
                    return "";
                }
                else
                {
                    throw ex;
                }
            }
        }
        private void Encode_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Hex.Text = EncodeHex(Text.Text);
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
                Text.Text = DecodeHex(Hex.Text);
            }
            catch (FormatException)
            {
                Utils.Dialog("Error", "Hex is invalid. Hex number must be like this: 48 65 6C 6C 6F");
            }
            catch
            {
                Utils.Dialog("Error", "Error occurred while decoding.");
            }
        }
    }
}
