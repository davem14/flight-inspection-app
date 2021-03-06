using flight_inspection_app.vm;
using OxyPlot;
using OxyPlot.Wpf;
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
    /// Interaction logic for dllUpload.xaml
    /// </summary>
    public partial class dllUpload : Window
    {
        string CsvFileName;
        string DllFileName;
        bool CSV = false;
        bool DLL = false;

        public dllUpload()
        {
            InitializeComponent();
        }

        private void upload(TextBox path, string fileName)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            Nullable<bool> result = dlg.ShowDialog();

            if (result == true)
            {
                path.Text = dlg.FileName;
                fileName = dlg.FileName;
            }
        }

        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.Filter = "file (*.csv) | *.csv";
            Nullable<bool> result = dlg.ShowDialog();

            if (result == true)
            {
                CSV = true;
                pathCSV.Text = dlg.FileName;
                CsvFileName = dlg.FileName;
            }
        }

        private void Button_Click2(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.Filter = "file (*.dll) | *.dll";
            Nullable<bool> result = dlg.ShowDialog();

            if (result == true)
            {
                DLL = true;
                pathDLL.Text = dlg.FileName;
                DllFileName = dlg.FileName;
            }
        }

        private void _continue_Click(object sender, RoutedEventArgs e)
        {
            Hide();
        }

        internal bool isEnabledDetect() => CSV && DLL;
    }
}
