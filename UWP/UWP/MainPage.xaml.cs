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
            TextBox LottoBox = new TextBox(); //Luo TextBoxin scrollViewerin sisalle
            LottoBox.AcceptsReturn = true;
            LottoBox.FontSize = 30;
            for (int i = 1; i <= int.Parse(drawTextBox.Text); i++) 
            {
                int[] numerot = lotto.makeLines(); //Luo uuden rivin
                foreach (int s in numerot) 
                {
                    LottoBox.Text += s.ToString() + " "; //Lisaa rivin scrollViewerin sisalle

                }
                LottoBox.Text += Environment.NewLine;


                scrollViewer.Content = (LottoBox);
            }

        }

        private void clearButton_Click(object sender, RoutedEventArgs e) 
        {
            scrollViewer.Content = ""; //Tyhjentaa scrollViewerin
        }
    }

    class Lotto
    {

        Random rand = new Random();

        public int[] makeLines() //Luo lottorivin
        {
            int[] lotto = new int[7];
            int check = 0;
            for (int i = 0; i < lotto.Length;)
            {
                check = rand.Next(1, 41);
                while (!(lotto.Contains(check))) //Tarkistaa ettei tule samaa numeroa uudestaan
                {
                    lotto[i] = check;
                    i++;
                }
            }
            return lotto;
        }
        

    }
}
