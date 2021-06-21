using BlockGameLauncher.Services;
using BlockGameLauncher.Views;
using DatabaseServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BlockGameLauncher
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public ProcessingService Processor { get; set; }
        public MainWindow()
        {
            InitializeComponent();

            Processor = new ProcessingService();
        }

        private void registerButton_Click(object sender, RoutedEventArgs e)
        {
            // Needs to be implemented
            RegistrationWindow registration = new RegistrationWindow();
            registration.Show();
        }

        private void loginButton_Click(object sender, RoutedEventArgs e)
        {
            if(!(String.IsNullOrEmpty(userBox.Text) & String.IsNullOrEmpty(passwordBox.Password))) {
                Tuple<Boolean, Datapackage> data = Processor.SendUserData(userBox.Text, passwordBox.Password);
                
                if (data.Item1)
                    StartButton.Visibility = Visibility.Visible;
            }
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            // Run exe command
        }
    }
}
