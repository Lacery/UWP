using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Diagnostics;
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

namespace h09t02
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

        private void nextpageHyperlinkButton_Click(object sender, RoutedEventArgs e)
        {
            Person person = new Person { Firstname = firstnameTextBox.Text, Lastname = lastnameTextBox.Text };
            this.Frame.Navigate(typeof(Page2), person);
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            //Debug.WriteLine("Number is " + (App.Current as App).Number);
            randomNumberTextBlock.Text = (App.Current as App).Number.ToString();
        }
    }
}
