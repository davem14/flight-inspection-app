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

namespace flight_inspection_app.vm.openXML
{
    /// <summary>
    /// Interaction logic for OpenXML.xaml
    /// </summary>
    public partial class OpenXML : Window
    {
        string fileName;
        VM_Graph vm;

        public OpenXML(VM_Graph vm)
        {
            InitializeComponent();
            this.vm = vm;
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
            Hide();
            vm.setXml(fileName);
        }
    }
}
