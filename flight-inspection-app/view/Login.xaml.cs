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
        string CsvFileName;
        string XmlFileName;
        VM_Login login;
        public Login()
        {
            InitializeComponent();
            login = new VM_Login();
        }

        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            Nullable<bool> result = dlg.ShowDialog();

            if (result == true)
            {
                pathCSV.Text = dlg.FileName;
                _continue.IsEnabled = true;
                CsvFileName = dlg.FileName;
            }
        }

        private void _continue_Click(object sender, RoutedEventArgs e)
        {
            login.VM_CsvFileName = CsvFileName;
            login.VM_XmlFileName = XmlFileName;
            login.start();
            Hide();
        }

        private void Load(object sender, RoutedEventArgs e)
        {
            configuration.Text = "--generic=socket,in,10,127.0.0.1,5400,tcp,XXXXXXXXXX" + Environment.NewLine + "--fdm=null";
        }

        private void Button_Click2(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            Nullable<bool> result = dlg.ShowDialog();

            if (result == true)
            {
                pathXML.Text = dlg.FileName;
                _continue.IsEnabled = true;
                XmlFileName = dlg.FileName;
            }
        }
    }
}
