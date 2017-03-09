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

namespace t3
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

        private void drawButton_Click(object sender, RoutedEventArgs e)
        {
            Lotto lotto = new Lotto();
            List<int> lista = lotto.makeLines(Int32.Parse(drawTextBox.Text));
            randomNumbersTextBlock.Text = lista.ToString();

        }

        private void clearButton_Click(object sender, RoutedEventArgs e)
        {
            randomNumbersTextBlock.Text = "";
        }
    }

    class Lotto
    {
        public List<int> lista = new List<int>();

        public List<int> makeLines(int lineAmount)
        {
            for (int i = 0; i <= lineAmount-1; i++)
            {
                Random rand = new Random();
                int number = rand.Next(1, 39 + 1);
                lista.Add(number);
            }
            return lista;
        }
        

    }
}
