using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace flight_inspection_app.vm
{
    class VM_Screen
    {
        public static void project(int millisecsBetweenBroadcasts) {
            // Establish the remote endpoint for the socket, using port 5400 on the local computer.
            IPHostEntry ipHost = Dns.GetHostEntry(Dns.GetHostName());
            IPAddress ipAddr = ipHost.AddressList[0];
            IPEndPoint FG_EndPoint = new IPEndPoint(ipAddr, 5400);

            // Creation TCP/IP Socket using Socket Class Costructor
            using (Socket fgSoc = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
            {
                try
                {
                    // Connect Socket to FG's endpoint
                    fgSoc.Connect(FG_EndPoint);

                    // print EndPoint information that we are connected to
                    Console.WriteLine("Socket connected to -> {0} ", fgSoc.RemoteEndPoint.ToString());

                    using (StreamReader reader = new StreamReader("reg_flight.csv"))
                    {
                        string line;
                        while ((line = reader.ReadLine()) != null)
                        {
                            byte[] toSent = Encoding.ASCII.GetBytes(line);
                            int bytesSent = fgSoc.Send(toSent);
                            Thread.Sleep(millisecsBetweenBroadcasts);
                        }
                    }
                }

                // Manage of Socket's Exceptions
                catch (ArgumentNullException ane)
                {

                    Console.WriteLine("ArgumentNullException : {0}", ane.ToString());
                }

                catch (SocketException se)
                {

                    Console.WriteLine("SocketException : {0}", se.ToString());
                }

                catch (Exception e)
                {
                    Console.WriteLine("Unexpected exception : {0}", e.ToString());
                }
            }
        }
    }
}
