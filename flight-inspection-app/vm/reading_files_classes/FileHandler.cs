using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace flight_inspection_app.vm.reading_files_classes
{
    public class FileHandler
    {
        List<string> file;
        string fileName;
        public FileHandler(string fileName)
        {
            this.fileName = fileName;
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
            //file.RemoveAt(0);
        }

        public List<string> getFile()
        {
            return file;
        }

        public string FileName
        {
            get { return this.fileName; }
        } 
    }
}
