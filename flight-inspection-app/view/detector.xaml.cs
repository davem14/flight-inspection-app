using flight_inspection_app.model;
using flight_inspection_app.vm;
using flight_inspection_app.vm.reading_files_classes;
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

namespace flight_inspection_app.view
{
    /// <summary>
    /// Interaction logic for detector.xaml
    /// </summary>
    public partial class detector : UserControl
    {
        private VM_Detector vm;
        public detector(Flight_Model model, /*VM_Graph graph,*/ XmlHandler xmlHandler)
        {
            InitializeComponent();
            vm = new VM_Detector(model, /*,graph*/ xmlHandler);
            DataContext = vm;
        }

        private void upload_Click(object sender, RoutedEventArgs e)
        {
            vm.upload();
        }

        private void previous_Click(object sender, RoutedEventArgs e)
        {
            vm.previos();
        }

        private void next_Click(object sender, RoutedEventArgs e)
        {
            vm.next();
        }

        private void detect_Click(object sender, RoutedEventArgs e)
        {
            vm.detect();
        }
    }
}
