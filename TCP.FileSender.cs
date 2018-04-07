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
    class TCPFileSender
    {
        private static string NEW_LINE = Environment.NewLine;

        private static void Send(Socket socket, byte[] buffer, int offset, int size, int timeout)
        {
            int startTickCount = Environment.TickCount;
            int sent = 0;
            do
            {
                if (Environment.TickCount > startTickCount + timeout)
                    throw new Exception("Timeout.");
                try
                {
                    sent += socket.Send(buffer, offset + sent, size - sent, SocketFlags.None);
                }
                catch (SocketException ex)
                {
                    if (ex.SocketErrorCode == SocketError.WouldBlock ||
                        ex.SocketErrorCode == SocketError.IOPending ||
                        ex.SocketErrorCode == SocketError.NoBufferSpaceAvailable)
                    {
                        Thread.Sleep(30);
                    }
                    else
                        throw ex;
                }
            } while (sent < size);
        }

        private static void SendFileInParts(Socket socket, string fileName, IProgress<string> progress)
        {
            try
            {
                using (var file = File.OpenRead(fileName))
                {
                    var sendBuffer = new byte[2048];

                    long bytesLeftToTransmit = file.Length;
                    while (bytesLeftToTransmit > 0)
                    {
                        int dataToSend = file.Read(sendBuffer, 0, sendBuffer.Length);
                        bytesLeftToTransmit -= dataToSend;

                        int offset = 0;
                        if (dataToSend > 0)
                        {
                            Send(socket, sendBuffer, offset, dataToSend, 10000);
                            offset += dataToSend;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                progress.Report(ex.Message + NEW_LINE);
            }

        }

        public static void SendFile(string fileName, IPAddress receiverIP, int receiverPort, IProgress<string> progress)
        {
            try
            {
                Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPEndPoint ip = new IPEndPoint(receiverIP, receiverPort);
                string filePath = "";
                fileName = fileName.Replace("\\", "/");

                while (fileName.IndexOf("/") > -1)
                {
                    filePath += fileName.Substring(0, fileName.IndexOf("/") + 1);
                    fileName = fileName.Substring(fileName.IndexOf("/") + 1);
                }

                byte[] byteFileName = Encoding.ASCII.GetBytes(fileName);
                progress.Report("Reading file.." + NEW_LINE);

                byte[] data = File.ReadAllBytes(filePath + fileName);
                byte[] fileSize = BitConverter.GetBytes(new FileInfo(filePath + fileName).Length);

                byte[] header = new byte[4 + byteFileName.Length + fileSize.Length];
                BitConverter.GetBytes(byteFileName.Length).CopyTo(header, 0);
                byteFileName.CopyTo(header, 4);
                fileSize.CopyTo(header, 4 + byteFileName.Length);

                progress.Report("Connecting to server.." + NEW_LINE);
                socket.Connect(ip);
                progress.Report("Sending file info.." + NEW_LINE);
                socket.Send(header);

                progress.Report("Sending file.." + NEW_LINE);
                SendFileInParts(socket, filePath + fileName, progress);

                progress.Report("Disconnecting.." + NEW_LINE);
                socket.Close();
                progress.Report("File was successfully sent." + NEW_LINE);
            }
            catch (Exception ex)
            {
                progress.Report("File Sending fail." + ex.Message + NEW_LINE);
            }
        }
    }
}
