using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace flight_inspection_app.vm.reading_files_classes
{
    public class XmlHandler
    {
        private List<string> chunksNames;
        public XmlHandler(string fileName)
        {
            chunksNames = getChunksName(fileName);
            handleDuplicateNames();
        }

        private List<string> getChunksName(string fileName)
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

            len = names.Count;

            for (int j = 0; j < len; j++)
            {
                names[j] = names[j].Replace("-", "_");
            }


            return names;
        }

        private void handleDuplicateNames()
        {
            int len = chunksNames.Count;
            for(int i = 0; i < len; i++)
            {
                bool isDuplicate = false;
                int times = 2;
                for (int j = i+1; j < len; j++)
                {
                    if(Equals(chunksNames[i], chunksNames[j]))
                    {
                        isDuplicate = true;
                        chunksNames[j] = chunksNames[j] + "_" + times.ToString();
                        times += 1;
                    }
                }
                if (isDuplicate)
                    chunksNames[i] = chunksNames[i] + "_1";
            }
        }

        public List<string> getList()
        {
            return chunksNames;
        }
    }
}
