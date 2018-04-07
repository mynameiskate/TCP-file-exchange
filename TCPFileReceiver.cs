using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TCPClientApp
{
    class TCPFileReceiver
    {
        private static string NEW_LINE = Environment.NewLine;

        public static Socket CreateSocket(IPAddress address, ref IPEndPoint ip, int port)
        {
            ip = new IPEndPoint(address, port);
            Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            clientSocket.Bind(ip);
            return clientSocket;
        }

        public static void StartReceiving(string savePath, ref IPEndPoint ip, int port, IProgress<string> progress)
        {
            Socket sck = CreateSocket(IPAddress.Any, ref ip, port);
            progress.Report("Starting.." + NEW_LINE);
            sck.Listen(5);
            while (true)
            {
                try
                {
                    Socket socket = sck.Accept();
                    byte[] header = new byte[1024];
                    int dataLength = socket.Receive(header);
                    progress.Report("Receiving data.." + NEW_LINE);

                    int nameLength = BitConverter.ToInt32(header, 0);
                    string fileName = Encoding.ASCII.GetString(header, 4, nameLength);
                    BinaryWriter binW = new BinaryWriter(File.Create(savePath + fileName));
                    progress.Report("Saving file.." + NEW_LINE);

                    byte[] buffer = new byte[2048];
                    ReceiveFile(socket, BitConverter.ToInt32(header, 4 + nameLength), binW);
                    binW.Close();
                    socket.Close();
                    progress.Report("Success" + NEW_LINE);

                }
                catch (Exception ex)
                {
                    progress.Report(ex.Message + NEW_LINE); 
                }
            }
        }

        private static void CreateDirectory(string v)
        {
            throw new NotImplementedException();
        }

        private static void ReceiveBuffer(Socket socket, byte[] buffer, int offset, int size, int timeout)
        {
            int startTickCount = Environment.TickCount;
            int received = 0;  // how many bytes is already received
            do
            {
                if (Environment.TickCount > startTickCount + timeout)
                    throw new Exception("Timeout.");
                try
                {
                    received += socket.Receive(buffer, offset + received, size - received, SocketFlags.None);
                }
                catch (SocketException ex)
                {
                    if (ex.SocketErrorCode == SocketError.WouldBlock ||
                        ex.SocketErrorCode == SocketError.IOPending ||
                        ex.SocketErrorCode == SocketError.NoBufferSpaceAvailable)
                    {
                        // socket buffer is probably empty, wait and try again
                        Thread.Sleep(30);
                    }
                    else
                        throw ex;  // any serious error occurr
                }
            } while (received < size);
        }

        private static void ReceiveFile(Socket socket, int size, BinaryWriter stream)
        {
            byte[] receiveBuffer = new byte[2048];
            int bytesLeftToReceive = size;

            while (bytesLeftToReceive > 0)
            {
                int bytesToCopy = Math.Min(receiveBuffer.Length, bytesLeftToReceive);
                ReceiveBuffer(socket, receiveBuffer, 0, bytesToCopy, 10000);
                stream.Write(receiveBuffer, 0, bytesToCopy);
                bytesLeftToReceive -= bytesToCopy;
            }

        }

    }
}
