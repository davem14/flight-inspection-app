using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace flight_inspection_app.vm
{
    class VM_Screen
    {
        static void project(int millisecsBetweenBroadcasts)
        {
            // create a TCPClient object at the localhost on port 5400
            TcpClient client = new TcpClient("localhost", 5400);
            NetworkStream nwStream = client.GetStream();
            StreamReader reader = new StreamReader("reg_flight.csv");

            byte[] endl = Encoding.ASCII.GetBytes("\r\n");
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                byte[] bytesToSend = ASCIIEncoding.ASCII.GetBytes(line);
                nwStream.Write(bytesToSend, 0, bytesToSend.Length);
                nwStream.Write(endl, 0, endl.Length);
                Thread.Sleep(millisecsBetweenBroadcasts);
            }

            nwStream.Close();
            reader.Close();
            client.Close();
        }
    }
}
