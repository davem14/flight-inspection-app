using flight_inspection_app.vm;
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

namespace flight_inspection_app.view
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        string fileName;
        VM_Login login;
        public Login()
        {
            InitializeComponent();
            login = new VM_Login();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            Nullable<bool> result = dlg.ShowDialog();

            if (result == true)
            {
                text.Text = dlg.FileName;
                _continue.IsEnabled = true;
                fileName = dlg.FileName;
            }
        }

        private void _continue_Click(object sender, RoutedEventArgs e)
        {
            login.VM_FileName = fileName;
            login.start();
            Hide();
        }
    }
}
