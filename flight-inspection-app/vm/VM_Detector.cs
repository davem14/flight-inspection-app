﻿using flight_inspection_app.model;
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
        private List<List<int>> anomoalies;
        int anomaliesLen;
        int anomalyIdx;
        Dictionary<int, List<Func<double, double>>> featuresThresholdEquations;

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
            // choose which DLL to load
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
        }


        internal void upload() => dllWindow.Show();

        internal void previos()
        {
            if (anomalyIdx >= 0)
            {
                anomalyIdx--;
                model.Anomaly = anomoalies[anomalyIdx][0];
                model.Step = anomoalies[anomalyIdx][1];
            }
        }

        internal void next()
        {
            if (anomalyIdx < anomaliesLen)
            {
                anomalyIdx++;
                model.Anomaly = anomoalies[anomalyIdx][0];
                model.Step = anomoalies[anomalyIdx][1];
            }
        }
    }
}
