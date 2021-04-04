using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using flight_inspection_app.model;
using flight_inspection_app.vm.openXML;
using OxyPlot;
using OxyPlot.Annotations;

namespace flight_inspection_app.vm
{
    public class VM_Graph: INotifyPropertyChanged
    {
        Flight_Model model;
        FileHandler fileHandler;
        public event PropertyChangedEventHandler PropertyChanged;
        Dictionary<int, List<float>> map = new Dictionary<int, List<float>>();
        List<string> chunksNames;
        List<Chunk> items;
        string xmlFileName;

        public VM_Graph(Flight_Model model, FileHandler fileHandler)
        {
            this.model = model;
            this.fileHandler = fileHandler;
            OpenXML openXML = new OpenXML(this);
            openXML.ShowDialog();
            xmlHandler xml = new xmlHandler(xmlFileName);
            chunksNames = xml.getList();

            items = new List<Chunk>();
            foreach (string chunk in chunksNames)
            {
                items.Add(new Chunk()
                {
                    Name = chunk
                });
            }

            List<string> file = fileHandler.getFile();


            int size1 = chunksNames.Count;
            for(int i = 0; i <size1; i++)
            {
                List<float> list = new List<float>();
                map.Add(i, list);
            }
            int size2 = file.Count;
            for (int i = 0; i < size2; i++)
            {
                float[] data = Array.ConvertAll(file[i].Split(','), float.Parse);
                int len = data.Length;
                for(int j = 0; j < len; j++)
                {
                    List<float> list;
                    map.TryGetValue(j, out list);
                    list.Add(data[j]);
                }
            }

            model.PropertyChanged += delegate (object sender, PropertyChangedEventArgs e)
            {
                if (Equals(e.PropertyName, "Step"))
                    PointsFirstCategory = getDataPoint(map[indexCategory]);
            };

        }

        int indexCategory;
        public int IndexCategory
        {
            get { return this.model.Step; }
            set
            {
                indexCategory = value;
            }
        }

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
                NotifyPropertyChanged("pointsSecondCategory");
            }
        }

        public List<DataPoint> getDataPoint(List<float> list)
        {
            List<DataPoint> listPoints = new List<DataPoint>();
            int len = model.Step;
            for (int i = 0; i < len; i++)
                listPoints.Add(new DataPoint(i, list[i]));
            return listPoints;
        }

        


        /*string firstCategory;
        public string FirstCategory
        {
            get { return firstCategory; }
            set { firstCategory = value; }
        }

        string secondCategory;
        public string SecondCategory
        {
            get { return firstCategory; }
            set { firstCategory = value; }
        }*/

        public Dictionary<int, List<float>> Map
        {
            get { return this.map; }
        }

        public void setXml(string xml)
        {
            this.xmlFileName = xml;
        }

    }



    class xmlHandler
    {
        List<string> chunksNames;
        public xmlHandler(string fileName)
        {
            chunksNames = getChunksName(fileName);
        }

        List<string> getChunksName(string fileName)
        {
            string[] lines = System.IO.File.ReadAllLines(@fileName);
            int size = lines.Length;
            int i;
            for (i = 0; i < size; i++)
            {
                if (lines[i].Contains("input"))
                    break;
            }

            List<string> names = new List<string>();

            for (; i < size; i++)
            {
                if (lines[i].Contains("name"))
                    names.Add(lines[i]);
            }

            int len = names.Count;

            for (int j = 0; j < len; j++)
            {
                int index = names[j].IndexOf("<name>");
                string s = names[j].Remove(0, index + 6);
                names[j] = s;
                index = names[j].IndexOf("</name>");
                s = names[j].Remove(index);
                names[j] = s;
            }

            return names;
        }

        public List<string> getList()
        {
            return chunksNames;
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
