using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using flight_inspection_app.model;
using flight_inspection_app;
using System.IO;

namespace flight_inspection_app.vm
{
    
    class VM_Login
    {
        string fileName;

        public string VM_FileName
        {
                get { return fileName; }
                set { fileName = value; }
            }
        public void start()
        {
            FileHandler fileHandler = new FileHandler(fileName);
            Flight_Model model = new Flight_Model(fileHandler.getFile());

            MainWindow mainWindow = new MainWindow(model, fileHandler);
            mainWindow.Show();
            model.start();
            
            
        }
    }

    public class FileHandler
    {
        List<string> file;
        public FileHandler(string fileName)
        {
            createListFile(fileName);
        }

        private void createListFile(string fileName)
        {
            using (var reader = new StreamReader(fileName))
            {
                file = new List<string>();
                while (!reader.EndOfStream)
                    file.Add(reader.ReadLine());
            }
        }

        public List<string> getFile()
        {
            return file;
        }
    }

}
