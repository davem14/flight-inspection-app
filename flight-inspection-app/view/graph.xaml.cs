using flight_inspection_app.model;
using flight_inspection_app.vm;
using flight_inspection_app.vm.reading_files_classes;
using OxyPlot;
using OxyPlot.Wpf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
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
        public graph(Flight_Model model, XmlHandler xmlHandler)
        {
            InitializeComponent();
            vm = new VM_Graph(model, xmlHandler);
            DataContext = vm;
            vm.PropertyChanged += delegate (object sender, PropertyChangedEventArgs e)
            {
                if (Equals(e.PropertyName, "IndexCategory"))
                {
                    indexCategoryChanged();
                }
            };
        }

        private void indexCategoryChanged()
        {
            int index = vm.IndexCategory;
            chartFirstCategory.Title = vm.Chunks[index].Name;
            chartSecondCategory.Title = vm.secondCategory(index);

            regressionLine.Title = vm.TitleRegressionLine;
            description.Text = "  " + vm.DescriptionOfCorrelation;
            description.Foreground = vm.ColorOfDescription;


            vm.PointsStaticRegression = vm.getPointsLine(index);
            regressionLine.Annotations.Clear();
            regressionLine.Annotations.Add(vm.lineAnnotation(index));
            foreach (var func in vm.CorrelationItem[index].NormalArea)
            {
                regressionLine.Annotations.Add(new FunctionAnnotation { Equation = func, Color = Color.FromRgb(255,0,0)});
            }
        }

        private void listBoxCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listBoxCategory.SelectedItem != null)
            {
                //chartFirstCategory.Title = ((Chunk)listBoxCategory.SelectedItem).Name;

                vm.IndexCategory = listBoxCategory.SelectedIndex;
            }
        }
    }

    


}
