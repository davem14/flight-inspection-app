using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.ComponentModel;
using System.Reflection;
using flight_inspection_app.model;

namespace flight_inspection_app.vm
{
    class VM_Screen
    {
        Flight_Model model;
        TcpClient client;
        NetworkStream nwStream;
        byte[] endl;


        public VM_Screen(Flight_Model model)
        {
            this.model = model;
            try
            {
                // create a TCPClient object at the localhost on port 5400
                this.client = new TcpClient("localhost", 5400);
                nwStream = client.GetStream();

                endl = Encoding.ASCII.GetBytes("\r\n");

                model.PropertyChanged +=
                   delegate (object sender, PropertyChangedEventArgs e)
                   {
                       byte[] bytesToSend = ASCIIEncoding.ASCII.GetBytes(GetPropertyValue(model, e.PropertyName).ToString());
                       nwStream.Write(bytesToSend, 0, bytesToSend.Length);
                       nwStream.Write(endl, 0, endl.Length);
                   };
            }
            catch (Exception e)
            {

            }
        }

        public static object GetPropertyValue(object source, string propertyName)
        {
            PropertyInfo property = source.GetType().GetProperty(propertyName);
            return property.GetValue(source, null);
        }
    }
}
