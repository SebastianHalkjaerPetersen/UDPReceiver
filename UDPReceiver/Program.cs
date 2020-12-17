using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace UDPReceiver
{
    class Program
    {
        static void Main(string[] args)
        {
            using (UdpClient socket = new UdpClient(new IPEndPoint(IPAddress.Any, 7777)))
            {
                    IPEndPoint remoteEndPoint = new IPEndPoint(0,0);

                    while (true)
                    {
                        Console.WriteLine("Waiting for broadcast {0}", socket.Client.LocalEndPoint);
                        byte[] datagramReceived = socket.Receive(ref remoteEndPoint);
                        string translate = Encoding.ASCII.GetString(datagramReceived, 0, datagramReceived.Length);
                        Console.WriteLine("Translation {0}", translate);

                        string[] translateSplit =  translate.Split(',', StringSplitOptions.RemoveEmptyEntries);
                        Console.WriteLine("first split: {0}", translateSplit[0]);
                        Console.WriteLine("second split: {0}", translateSplit[1]);
                        Console.WriteLine("third split: {0}", translateSplit[2]);
                    }
            }
        }
    }
}
