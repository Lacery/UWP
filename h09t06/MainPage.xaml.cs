using System;
using System.Collections.Generic;
using System.IO;
using Windows.UI.Xaml.Controls;
using System.Diagnostics;
using Windows.Storage;
using System.Runtime.Serialization;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace h09t06
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        List<Employee> employees = new List<Employee>();
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void GenerateEmployees()
        {
            employees.Add(new Employee { Firstname = "Joseph", Lastname = "Howard" });
            employees.Add(new Employee { Firstname = "Helen", Lastname = "Schmidt" });
            employees.Add(new Employee { Firstname = "Sean", Lastname = "White" });
        }

        private async void SaveEmployees()
        {
            try
            {
                // open/create a file
                StorageFolder storageFolder = ApplicationData.Current.LocalFolder;
                StorageFile employeesFile = await storageFolder.CreateFileAsync("employees.dat", CreationCollisionOption.OpenIfExists);

                // save employees to disk
                Stream stream = await employeesFile.OpenStreamForWriteAsync();
                DataContractSerializer serializer = new DataContractSerializer(typeof(List<Employee>));
                serializer.WriteObject(stream, employees);
                await stream.FlushAsync();
                stream.Dispose();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Following exception has happend (writing): " + ex.ToString());
            }
        }

        private async void ReadEmployees()
        {
            try
            {
                // find a file
                StorageFolder storageFolder = ApplicationData.Current.LocalFolder;
                Stream stream = await storageFolder.OpenStreamForReadAsync("employees.dat");

                // is it empty
                if (stream == null) employees = new List<Employee>();

                // read data
                DataContractSerializer serializer = new DataContractSerializer(typeof(List<Employee>));
                employees = (List<Employee>)serializer.ReadObject(stream);
                ShowEmployees();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Following exception has happend (reading): " + ex.ToString());
            }
        }

        private void ShowEmployees()
        {
            EmployeesTextBlock.Text = "Employees:" + Environment.NewLine;
            foreach (Employee employee in employees)
            {
                EmployeesTextBlock.Text += employee.Firstname + " " + employee.Lastname + Environment.NewLine;
            }
        }

        private void generateButton_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            GenerateEmployees();
        }

        private void saveButton_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            SaveEmployees();
        }

        private void readButton_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            ReadEmployees();
        }
    }
}
