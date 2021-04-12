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
using flight_inspection_app.vm.reading_files_classes;

namespace flight_inspection_app
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Flight_Model model;
        XmlHandler xmlHandler;
        FileHandler fileHandler;

        //FileHandler fileHandler;
        public MainWindow(Flight_Model model, XmlHandler xmlHandler, FileHandler fileHandler)
        {
            InitializeComponent();
            this.model = model;
            this.xmlHandler = xmlHandler;
            this.fileHandler = fileHandler;
            loadedUserControl();
        }

        private void loadedUserControl()
        {
            VM_Screen screen = new VM_Screen(model);
            playBar.Children.Add(new playBar(model));
            details.Children.Add(new details(model));
            graph.Children.Add(new graph(model, xmlHandler));
            joystick.Children.Add(new Joystick(model));
            detector.Children.Add(new detector(model, /*graph,*/ xmlHandler, fileHandler));
        }

        private void Closing_Window(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.model.stopRun();
            Application.Current.Shutdown();
        }
    }
}
