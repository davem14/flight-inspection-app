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

        bool CsvIsChoose = false;
        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.Filter = "file (*.csv) | *.csv";

            if (dlg.ShowDialog() == true)
            {
                pathCSV.Text = dlg.FileName;
                CsvIsChoose = true;
                if(XmlIsChoose == true)
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

        bool XmlIsChoose = false;
        private void Button_Click2(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.Filter = "file (*.xml) | *.xml";
            //Nullable<bool> result = dlg.ShowDialog();

            if (dlg.ShowDialog() == true)
            {
                pathXML.Text = dlg.FileName;
                XmlIsChoose = true;
                if (CsvIsChoose == true)
                    _continue.IsEnabled = true;
                XmlFileName = dlg.FileName;  
            }
        }
    }
}
