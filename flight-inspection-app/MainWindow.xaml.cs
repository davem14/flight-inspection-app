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
using flight_inspection_app.view;
using flight_inspection_app;
using flight_inspection_app.vm;

namespace flight_inspection_app
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Flight_Model model;
        //FileHandler fileHandler;
        public MainWindow(Flight_Model model)
        {
            InitializeComponent();
            this.model = model;
            loadedUserControl();
        }

        private void loadedUserControl()
        {
            playBar.Children.Add(new playBar(model));
        }
    }
}
