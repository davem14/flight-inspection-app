using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using flight_inspection_app.model;

namespace flight_inspection_app.vm
{
    class VM_Graph
    {
        Flight_Model model;
        Dictionary<string, List<float>> map = new Dictionary<string, List<float>>();

        VM_Graph(Flight_Model model)
        {
            this.model = model;
        }

    }

}
