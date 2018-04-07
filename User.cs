using System;
using System.Net.Sockets;
using System.Net;
using System.Net.NetworkInformation;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TCPClientApp
{ 
    public class User
    {
        public string NEW_LINE = Environment.NewLine;
        private int _port;
        private IPEndPoint _ip;
        private IPAddress _localIP;

        public int GetPort()
        {
            return _port;
        }

        public static IPAddress GetLocalIP()
        {
            IPAddress ip = Dns.GetHostAddresses(Dns.GetHostName()).Where(address => address.AddressFamily == AddressFamily.InterNetwork).Last();
            return ip;
        }

        public static int GetOpenPort()
        {
            int PortStartIndex = 1000;
            int PortEndIndex = 2000;
            IPGlobalProperties properties = IPGlobalProperties.GetIPGlobalProperties();
            IPEndPoint[] tcpEndPoints = properties.GetActiveTcpListeners();

            List<int> usedPorts = tcpEndPoints.Select(p => p.Port).ToList<int>();
            int unusedPort = 0;

            for (int port = PortStartIndex; port < PortEndIndex; port++)
            {
                if (!usedPorts.Contains(port))
                {
                    unusedPort = port;
                    break;
                }
            }
            return unusedPort;
        }
    
        public Task Listen(string savePath, Progress<string> progress)
        {
            return Task.Factory.StartNew(() => TCPFileReceiver.StartReceiving(savePath, ref _ip, _port, progress), TaskCreationOptions.LongRunning);
        }

        public Task Send(string fileName, IPAddress receiverIP, int receiverPort, Progress<string> progress)
        {
            return Task.Factory.StartNew(() => TCPFileSender.SendFile(fileName, receiverIP, receiverPort, progress), TaskCreationOptions.LongRunning);
        }

        public User()
        {
            _port = GetOpenPort();
            _localIP = GetLocalIP();
        }
    }
}
