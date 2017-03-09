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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace t4
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            double value = double.Parse(valueTextBox.Text);
            if (value == 0) //Jos valueTextBoxissa on 0, tyhjennetaan se ennen uutta numeroa
            {
                valueTextBox.Text = "";
            }
            string buttonString = (((Button)sender).Content).ToString();
            valueTextBox.Text += buttonString;
        }

        private void buttonBack_Click(object sender, RoutedEventArgs e)
        {
            string value = valueTextBox.Text;
            value = value.Remove(value.Length - 1);
            if (value.Length == 0) //Jos valueTextBox tyhjennetaan kokonaan, laitetaan siihen taas 0
            {
                valueTextBox.Text = "0";
            }
            else
            {
                valueTextBox.Text = value;
            }
        }

        private void buttonOk_Click(object sender, RoutedEventArgs e)
        {
            Kiuas kiuas = new Kiuas();
            double value = double.Parse(valueTextBox.Text);

            if ((bool)tempCheckBox.IsChecked)
            {
                double tempChecked = kiuas.CheckTemp(value);
                tempTextBox.Text = tempChecked.ToString();
                if (tempChecked == 0)
                {
                    infoTextBlock.Text = "Info: Invalid value. Temperature must be 0-120";
                }
            }

            if ((bool)humidCheckBox.IsChecked) {
                double humidChecked = kiuas.CheckHumid(value);
                humidTextBox.Text = humidChecked.ToString();
                if (humidChecked == 0)
                {
                    infoTextBlock.Text = "Info: Invalid value. Humidity must be 0-100";
                }
            }
            


        }

        class Kiuas
        {
            private double temperature;
            private double humidity;


            public double Temperature {
                get { return temperature; }
                set { if (value <= 120 && value >= 0) { temperature = value; }
                    else { temperature = 0; }
                }
            }
            
            public double Humidity {
                get { return humidity; }
                set {
                    if (value <= 100 && value >= 0){
                        humidity = value;
                    }
                    else { humidity = 0; }
                }
            }

            public double CheckTemp(double temp)
            {
                Temperature = temp;
                return temperature;
            }

            public double CheckHumid(double humid)
            {
                Humidity = humid;
                return humidity;
            }



        }
        
    }
}
