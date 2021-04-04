using flight_inspection_app.model;
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
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace flight_inspection_app.view
{
    /// <summary>
    /// Interaction logic for graph.xaml
    /// </summary>
    public partial class graph : UserControl
    {
        private VM_Graph vm;
        public graph(Flight_Model model, FileHandler fileHandler)
        {
            InitializeComponent();
            vm = new VM_Graph(model, fileHandler);
            DataContext = vm;

            this.listBox1.ItemsSource = vm.Chunks;
            //this.listBox2.ItemsSource = vm.Chunks;


            LineAnnotation annotation = new LineAnnotation();
            annotation.Slope = 1;
            annotation.Intercept = 1;
            annotation.LineStyle = LineStyle.Solid;
            regressionLine.Annotations.Add(annotation);


        }

        string firstCategory;
        string secondCategory;
        bool firstIsSelected = false;
        bool secondIsSelected = false;

        private void listBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                chartFirstCategory.Title = ((Chunk)listBox1.SelectedItem).Name;

                int index = listBox1.SelectedIndex;
                if(index == 42)
                {
                    Console.WriteLine("hello");
                }

                vm.IndexCategory = index;

                //this.vm.PointsFirstCategory = vm.getDataPoint(vm.Map[index]);
            }

            firstIsSelected = true;

        }
    }

    


}
