using BlockGameLauncher.Services;
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
using System.Windows.Shapes;

namespace BlockGameLauncher.Views
{
    /// <summary>
    /// Interaction logic for RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {

        public ProcessingService Processor { get; set; }

        public RegistrationWindow()
        {
            InitializeComponent();
            Processor = new ProcessingService();
        }

        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            if(!String.IsNullOrEmpty(userBox.Text) && !String.IsNullOrEmpty(conPassBox.Password) && !String.IsNullOrEmpty(passBox.Password))
            {
                if (conPassBox.Password.Equals(passBox.Password))
                {
                    bool done = Processor.SendRegistrationData(userBox.Text, passBox.Password);
                    if(done)
                    {
                        this.Close();
                    }
                }
            }
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
