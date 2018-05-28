using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;

namespace ArduinoWifiTest
{
    public class ArduinoWifi
    {
        //Fields
        private List<string> communicatie = new List<string>();

        //Constructor
        public ArduinoWifi(string IpAdres, int Poort)
        {
            TCP = new TcpClient(IpAdres, Poort);
            Arduino = TCP.GetStream();
        }

        //Properties
        public TcpClient TCP { get; private set; }
        public NetworkStream Arduino { get; private set; }
        public bool DataAvailable
        {
            get { return Arduino.DataAvailable; }
        }
        

        //Methods
        public void Send(string Message)
        {
            byte[] Buffer = Encoding.ASCII.GetBytes(Message);
            Arduino.Write(Buffer, 0, Buffer.Length);
        }

        public List<string> Receive()
        {
            Byte[] data = new Byte[256];
            Int32 bytes = Arduino.Read(data, 0, data.Length);
            string OntvangenData = System.Text.Encoding.ASCII.GetString(data, 0, bytes);
            communicatie.Add(OntvangenData);
            return communicatie;
        }

    }
}
