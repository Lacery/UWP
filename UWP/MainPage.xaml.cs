

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace UWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        double ikkunanLeveys, ikkunanKorkeus, puunLeveys = 45;
        public MainPage()
        {
            this.InitializeComponent();
        }


        private void laskeButton_Click(object sender, RoutedEventArgs e)
        {
            double vaihto = (ikkunanLeveys+puunLeveys*2) * (ikkunanKorkeus + puunLeveys*2);
            double lasi = ikkunanLeveys * ikkunanKorkeus;
            double karmi = ikkunanKorkeus * 2 + (ikkunanLeveys - puunLeveys) * 2;
            ikkunanPintaAlaTextBox.Text = vaihto.ToString() + " cm^2";
            lasinPintaAlaTextBox.Text = lasi.ToString() + " cm^2";
            karminPiiriTextBox.Text = karmi.ToString() + " mm";
        }

        private void puunLeveysTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!double.TryParse(puunLeveysTextBox.Text, out puunLeveys))
            {

            }
        }

        private void ikkunanLeveysTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!double.TryParse(ikkunanLeveysTextBox.Text, out ikkunanLeveys))
            {
                
            }

        }
        private void ikkunanKorkeusTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!double.TryParse(ikkunanKorkeusTextBox.Text, out ikkunanKorkeus))
            {

            }
        }

    }
}
