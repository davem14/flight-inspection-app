using flight_inspection_app.model;
using flight_inspection_app.view;
using flight_inspection_app.vm.reading_files_classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace flight_inspection_app.vm
{
    class VM_Detector : INotifyPropertyChanged
    {
        // fields
        private Flight_Model model;
        private dllUpload dllWindow;
        private XmlHandler xmlHandler;
        private string anomalyFlightCSVPath;
        private List<List<int>> anomoalies;
        private int anomaliesLen;
        private int anomalyIdx;

        // + properties
        private bool enableDetect = false;
        public bool EnableDetect
        {
            get => enableDetect;
            set
            {
                enableDetect = value;
                NotifyPropertyChanged("EnableDetect");
            }
        }

        private bool enablePlay = false;
        public bool EnablePlay
        {
            get => enablePlay;
            set
            {
                enablePlay = value;
                NotifyPropertyChanged("EnablePlay");
            }
        }

        private bool enableNext = false;
        public bool EnableNext
        {
            get => enableNext;
            set
            {
                enableNext = value;
                NotifyPropertyChanged("EnableNext");
            }
        }

        private bool enablePrevious = false;
        public bool EnablePrevious
        {
            get => enablePrevious;
            set
            {
                enablePrevious = value;
                NotifyPropertyChanged("EnablePrevious");
            }
        }

        // constructor
        public VM_Detector(Flight_Model model, XmlHandler xmlHandler, FileHandler fileHandler)
        {
            this.model = model;
            //this.graph = graph;
            this.xmlHandler = xmlHandler;
            dllWindow = new dllUpload();
            anomalyFlightCSVPath = fileHandler.FileName;
        }

        // property changed members
        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        // methods
        public void detect()
        {
            // choose which DLL to load
            try
            {
                var assembly = Assembly.LoadFile(dllWindow.pathDLL.Text);
                var theType = assembly.GetType("AD_plugin.AD");
                var AD = Activator.CreateInstance(theType);

                var detect = theType.GetMethod("Detect");
                var anoms = detect.Invoke(AD, new object[] { dllWindow.pathCSV.Text, anomalyFlightCSVPath, xmlHandler.getList().Count });
                anomoalies = (List<List<int>>)anoms; // category, begin, end
                anomaliesLen = anomoalies.Count();
                anomalyIdx = 0;

                var GNM = theType.GetMethod("GetNormalModel");
                var dict = GNM.Invoke(AD, null);
                //featuresThresholdEquations = (Dictionary<int, List<Func<double, double>>>)dict;
                model.Categories = (Dictionary<int, List<Func<double, double>>>)dict;
            } catch { Console.WriteLine("dll error"); }
            if (anomaliesLen == 0)
                EnablePlay = false;
            else
                EnablePlay = true;
            updateNextPrev();
        }

        internal void upload()
        {
            var a = dllWindow.ShowDialog();
            EnableDetect = dllWindow.isEnabledDetect();
        }

        internal void previous()
        {
            anomalyIdx--;
            play();
            updateNextPrev();
        }

        internal void next()
        {
            anomalyIdx++;
            play();
            updateNextPrev();
        }

        internal void play()
        {
            model.Anomaly = anomoalies[anomalyIdx][0];
            model.Step = anomoalies[anomalyIdx][1];
        }

        private void updateNextPrev()
        {
            if (anomaliesLen == 0)
            {
                EnablePrevious = false;
                EnableNext = false;
                return;
            }
            if (anomalyIdx == 0)
                EnablePrevious = false;
            else
                EnablePrevious = true;

            if (anomalyIdx == anomaliesLen - 1)
                EnableNext = false;
            else
                EnableNext = true;
        }
    }
}
