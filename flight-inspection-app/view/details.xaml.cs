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
using flight_inspection_app.model;
using flight_inspection_app.vm;

namespace flight_inspection_app.view
{
    /// <summary>
    /// Interaction logic for details.xaml
    /// </summary>
    public partial class details : UserControl
    {
        private VM_details vm;
        public details(Flight_Model model)
        {
            InitializeComponent();
            vm = new VM_details(model);
            DataContext = vm;
            // ...        
        }
    }
}
