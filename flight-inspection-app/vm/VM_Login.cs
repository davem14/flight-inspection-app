using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using flight_inspection_app.model;
using flight_inspection_app;
using System.IO;
using flight_inspection_app.vm.reading_files_classes;

namespace flight_inspection_app.vm
{
    
    class VM_Login
    {
        string CsvFileName;
        string XmlFileName;

        public string VM_CsvFileName
        {
            get { return CsvFileName; }
            set { CsvFileName = value; }
        }

        public string VM_XmlFileName
        {
            get { return XmlFileName; }
            set { XmlFileName = value; }
        }

        public void start()
        {
            FileHandler fileHandler = new FileHandler(CsvFileName);
            XmlHandler xmlHandler = new XmlHandler(XmlFileName);

            Flight_Model model = new Flight_Model();

            MainWindow mainWindow = new MainWindow(model, xmlHandler, fileHandler);

            model.File = fileHandler.getFile();

            mainWindow.Show();
            model.start();
            
            
        }
    }
}
