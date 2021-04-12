using flight_inspection_app.model;
using flight_inspection_app.view;
using flight_inspection_app.vm.reading_files_classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace flight_inspection_app.vm
{
    class VM_Detector
    {
        private Flight_Model model;
        //private VM_Graph graph;
        private dllUpload dllWindow;
        private XmlHandler xmlHandler;
        private string anomalyFlightCSVPath;
        private List<Tuple<Tuple<int, int>, string>> anomoalies;
        
        //public event PropertyChangedEventHandler PropertyChanged;
        public VM_Detector(Flight_Model model, /*graph g,*/ XmlHandler xmlHandler, FileHandler fileHandler)
        {
            this.model = model;
            //this.graph = graph;
            this.xmlHandler = xmlHandler;
            dllWindow = new dllUpload();
            anomalyFlightCSVPath = fileHandler.FileName;
        }

        public void detect()
        {
            string nameChunks = "";
            foreach (var str in xmlHandler.getList())
                nameChunks += str + ",";

            // choose which DLL to load
            var assembly = Assembly.LoadFile(dllWindow.pathDLL.Text);
            var theType = assembly.GetType("AD_plugin.AD");
            var obj = Activator.CreateInstance(theType);
            var method = theType.GetMethod("Detect");

            var anoms = method.Invoke(obj, new object[] { dllWindow.pathCSV.Text, anomalyFlightCSVPath, nameChunks });
            this.anomoalies = (List<Tuple<Tuple<int, int>, string>>)anoms;
        }


        internal void upload() => dllWindow.Show();

        internal void previos() => throw new NotImplementedException();

        internal void next()
        {
            throw new NotImplementedException();
        }
    }
}
