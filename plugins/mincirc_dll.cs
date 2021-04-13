using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AD_plugin
{
    public class AD
    {
        TcpClient client;
        NetworkStream nwStream;
        byte[] bytesToRead;
        public AD()
        {
            client = new TcpClient("localhost", 6405);
            nwStream = client.GetStream();
            bytesToRead = new byte[client.ReceiveBufferSize];

        }
        public List<List<int>> Detect(string regflightPath, string anomalflightPath, int numberOfFeatures)
        {
            List<Tuple<int, string>> ar = new List<Tuple<int, string>>();
            List<List<int>> arRanges = new List<List<int>>();
            string data;
            string result;

            string reg = File.ReadAllText(regflightPath);
            string anom = File.ReadAllText(anomalflightPath);
            string properties = "";
            for (int i = 0; i < numberOfFeatures; ++i)
            {
                properties += i.ToString() + ",";
            }



            data = "h\n" + "1\n" + properties + "\n" + reg + "done\n"
                         + properties + "\n" + anom + "done\n"
                         + "3\n" + "4\n";

            // create a TCPClient object at the localhost on port no.
            //TcpClient client = new TcpClient("localhost", 6405);
            //NetworkStream nwStream = client.GetStream();

            int bytesRead;

            // send train and test files
            byte[] bytesToSend = ASCIIEncoding.ASCII.GetBytes(data);
            nwStream.Write(bytesToSend, 0, bytesToSend.Length);

            // recieve anomalies

            // ensure server sent all data
            do
            {
                bytesRead = nwStream.Read(bytesToRead, 0, client.ReceiveBufferSize);
                result = Encoding.ASCII.GetString(bytesToRead, 0, bytesRead);
            } while (!result.Contains("Done"));

            string[] anomalies = result.Split('\n');

            for (int i = 0; i < anomalies.Length; ++i)
            {
                string[] current = anomalies[i].Split('\t');
                if (current[0].CompareTo("") != 0 && !current[0].Contains("Done"))
                {
                    try
                    {
                        ar.Add(new Tuple<int, string>(Int32.Parse(current[0]), current[1]));
                    }
                    catch (Exception e)
                    {
                        //Console.WriteLine(e);
                    }
                }
            }


            for (int i = 0; i < ar.Count; i++)
            {
                int start, end;
                string description = ar[i].Item2;
                start = ar[i].Item1;
                while (i < ar.Count - 1 && ar[i + 1].Item2.CompareTo(description) == 0 && ar[i + 1].Item1 - ar[i].Item1 == 1)
                {
                    ++i;
                }
                end = ar[i].Item1;
                string[] temp = description.Split('-');
                arRanges.Add(new List<int> { Int32.Parse(temp[0]), start, end });
            }

            return arRanges;
        }

        public Dictionary<int, List<Func<double, double>>> GetNormalModel()
        {
            Dictionary<int, List<Func<double, double>>> dict = new Dictionary<int, List<Func<double, double>>>();
            byte[] bytesToSend = ASCIIEncoding.ASCII.GetBytes("5\n6\n");
            nwStream.Write(bytesToSend, 0, bytesToSend.Length);
            string result;
            do
            {
                int bytesRead = nwStream.Read(bytesToRead, 0, client.ReceiveBufferSize);
                result = Encoding.ASCII.GetString(bytesToRead, 0, bytesRead);
            } while (!result.Contains("Done"));

            string[] cf = result.Split(',');
            foreach (string somecf in cf)
            {

                string[] cfmem = somecf.Split(':');
                if (cfmem.Length == 1)
                {
                    continue;
                }
                double r = double.Parse(cfmem[1]);
                double a = double.Parse(cfmem[2]);
                double b = double.Parse(cfmem[3]);
                int name = Int32.Parse(cfmem[0]);
                dict.Add(name, new List<Func<double, double>> { (x) => b + Math.Sqrt(Math.Pow(r,2)-Math.Pow(x-a,2)), (x) => b - Math.Sqrt(Math.Pow(r, 2) - Math.Pow(x - a, 2)) });

            }
            return dict;
        }

    }
}
