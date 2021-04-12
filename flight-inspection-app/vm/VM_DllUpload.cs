using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace flight_inspection_app.vm
{
    class VM_DllUpload
    {
        string CsvFileName;
        string DllFileName;

        public string VM_CsvFileName
        {
            get { return CsvFileName; }
            set { CsvFileName = value; }
        }

        public string VM_DllFileName
        {
            get { return DllFileName; }
            set { DllFileName = value; }
        }
    }
}
