using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using flight_inspection_app.model;
using flight_inspection_app.vm.reading_files_classes;
using flight_inspection_app.vm.statistics;
using flight_inspection_app.vm.correlation_classes;
using OxyPlot;
using System.Threading;

namespace flight_inspection_app.vm
{
    public class VM_Graph: INotifyPropertyChanged
    {
        Flight_Model model;
        public event PropertyChangedEventHandler PropertyChanged;
        Dictionary<int, List<float>> map = new Dictionary<int, List<float>>();
        List<string> chunksNames;
        List<Chunk> items;
        Dictionary<int, CorrelationDetails> correlationItem;

        public VM_Graph(Flight_Model model, XmlHandler xmlHandler)
        {
            this.model = model;
            chunksNames = xmlHandler.getList();
            

            model.PropertyChanged += delegate (object sender, PropertyChangedEventArgs e)
            {
                if (Equals(e.PropertyName, "File"))
                {
                    initializationOfData(model.File);
                    this.correlationItem = Correlation.findCorrelations(chunksNames, map);
                    this.NotifyPropertyChanged("VM_" + e.PropertyName);
                }
                else if (Equals(e.PropertyName, "Step"))
                {
                    new Thread(delegate ()
                    {
                        PointsFirstCategory = getDataPoint(map[indexCategory]);
                        if (correlationItem[indexCategory].CorrelationWith != -1)
                            PointsSecondCategory = getDataPoint(map[correlationItem[indexCategory].CorrelationWith]);
                        else
                            PointsSecondCategory = getDataPoint(new List<float>());
                        PointsDynamicRegression = getPointsDynamicRegression(correlationItem[indexCategory].Points, indexCategory);
                    }).Start();
                    

                }
            };

        }


        void initializationOfData(List<string> file)
        {
            this.items = new List<Chunk>();
            foreach (string chunk in chunksNames)
            {
                this.items.Add(new Chunk()
                {
                    Name = chunk
                });
            }

            int size1 = chunksNames.Count;
            for (int i = 0; i < size1; i++)
            {
                List<float> list = new List<float>();
                this.map.Add(i, list);
            }

            int size2 = file.Count;
            for (int i = 0; i < size2; i++)
            {
                float[] data = Array.ConvertAll(file[i].Split(','), float.Parse);
                int len = data.Length;
                for (int j = 0; j < len; j++)
                {
                    List<float> list;
                    this.map.TryGetValue(j, out list);
                    list.Add(data[j]);
                }
            }
        }


        public OxyPlot.Wpf.LineAnnotation lineAnnotation(int index)
        {
            OxyPlot.Wpf.LineAnnotation annotation = new OxyPlot.Wpf.LineAnnotation();
            if (!Single.IsNaN(correlationItem[index].CorrelationValue))
            {
                annotation.Slope = correlationItem[index].RegressionLine.A;
                annotation.Intercept = correlationItem[index].RegressionLine.B; ;
                annotation.LineStyle = LineStyle.Solid;
            }
            return annotation;
        }


        int indexCategory;
        public int IndexCategory
        {
            get {
                return indexCategory;
                ;
            }
            set
            {
                indexCategory = value;
            }
        }

        public string secondCategory(int index)
        {
            if(correlationItem[index].CorrelationWith != -1)
                return Chunks[correlationItem[index].CorrelationWith].Name;
            return " ";
        }

        public string DescriptionOfCorrelation
        {
            get { return correlationItem[IndexCategory].Warning; }
        }

        public string TitleRegressionLine
        {
            get
            {
                if (!Single.IsNaN(correlationItem[IndexCategory].CorrelationValue))
                    return "The regression line between " + items[IndexCategory].Name + " and " + secondCategory(IndexCategory);
                else
                    return "There is no a regression line";
            }
        }

        public SolidColorBrush ColorOfDescription
        {
            get
            {
                if (Single.IsNaN(correlationItem[IndexCategory].CorrelationValue))
                    return new SolidColorBrush(Colors.Red);
                else if (correlationItem[IndexCategory].CorrelationValue < 0.9)
                    return new SolidColorBrush(Colors.Orange);
                else
                    return new SolidColorBrush(Colors.Green);
            }
        }

        /*string titleFirstCategory;
        public string TitleFirstCategory
        {
            get { return this.titleFirstCategory; }
            set
            {
                titleFirstCategory = value;
            }
        }*/


        public void NotifyPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public int VM_Step
        {
            get { return this.model.Step; }
        }


        public List<Chunk> Chunks
        {
            get { return this.items; }
        }


        IList<DataPoint> pointsFirstCategory;
        public IList<DataPoint> PointsFirstCategory
        {
            get { return pointsFirstCategory; }
            set
            {
                pointsFirstCategory = value;
                NotifyPropertyChanged("PointsFirstCategory");
            }
        }

        IList<DataPoint> pointsSecondCategory;
        public IList<DataPoint> PointsSecondCategory
        {
            get { return pointsSecondCategory; }
            set
            {
                pointsSecondCategory = value;
                NotifyPropertyChanged("PointsSecondCategory");
            }
        }

        public IList<DataPoint> getDataPoint(List<float> list)
        {
            IList<DataPoint> points = new List<DataPoint>();
            if (list.Count != 0)
            {
                int len = model.Step;
                for (int i = 0; i < len; i++)
                    points.Add(new DataPoint(i, list[i]));
            }
            return points;
        }

        IList<DataPoint> pointsStaticRegression;
        public IList<DataPoint> PointsStaticRegression
        {
            get { return pointsStaticRegression; }
            set
            {
                pointsStaticRegression = value;
                NotifyPropertyChanged("PointsStaticRegression");
            }
        }

        IList<DataPoint> pointsDynamicRegression;
        public IList<DataPoint> PointsDynamicRegression
        {
            get { return pointsDynamicRegression; }
            set
            {
                pointsDynamicRegression = value;
                NotifyPropertyChanged("PointsDynamicRegression");
            }
        }

        public List<DataPoint> getPointsStaticRegression(int index)
        {
            List<Point> points = correlationItem[index].Points;
            List<DataPoint> listPoints = new List<DataPoint>();
            if (!Single.IsNaN(correlationItem[index].CorrelationValue))
            {
                int len = points.Count;
                for (int i = 0; i < len; i++)
                    listPoints.Add(new DataPoint(points[i].x, points[i].y));
            }
            return listPoints;
        }

        public List<DataPoint> getPointsDynamicRegression(List<Point> list, int index)
        {
            List<DataPoint> listPoints = new List<DataPoint>();
            if (!Single.IsNaN(correlationItem[index].CorrelationValue))
            {
                int len = listPoints.Count;
                for (int i = 0, j = model.Step; i < 300 && j < model.Range + 1; i++, j++)
                    listPoints.Add(new DataPoint(list[j].x, list[j].y));
            }
            return listPoints;
        }

        public Dictionary<int, List<float>> Map
        {
            get { return this.map; }
        }
    }


    public class Chunk
    {
        string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
    }
}
