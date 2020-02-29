using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace TheLosers.BH4.XamarinApp
{
    public static class Sockets
    {
        public const string HOST = "127.0.0.1";
        public const int PORT = 42;
        private const string ENCODING = "utf-16";

        public static void RunClient(string host, int port, Func<Socket, string, string> processReceived, CancellationToken ct)
        {
            var s = new Socket(SocketType.Stream, ProtocolType.Tcp);
            Console.WriteLine("Socket created");

            try
            {
                s.Bind(new IPEndPoint(new IPAddress(new byte[] { 127, 0, 0, 1 }), port));
            }
            catch (SocketException)
            {
                Console.WriteLine("Bind failed.");
            }

            s.Listen(5);
            Console.WriteLine("Socket awaiting messages");
            Socket conn = s.Accept();
            Console.WriteLine("Connected");

            // Message processing loop.
            while (true)
            {
                ct.ThrowIfCancellationRequested();

                byte[] receivedBytes = new byte[1024];
                int received;
                try
                {
                    received = conn.Receive(receivedBytes);
                }
                catch (SocketException)
                {
                    Console.WriteLine("Server closed connection.");
                    break;
                }

                string receivedString = Encoding.GetEncoding(ENCODING).GetString(receivedBytes);
                Console.WriteLine("Received: " + receivedString);

                conn.Send(Encoding.GetEncoding(ENCODING).GetBytes(processReceived(conn, receivedString)));
            }

            conn.Close();
        }

        public static void RunServer(string host, int port, Func<string> supplier, CancellationToken ct)
        {
            var s = new Socket(SocketType.Stream, ProtocolType.Tcp);
            s.Connect(HOST, port);

            while (true)
            {
                string command = supplier();
                s.Send(Encoding.GetEncoding(ENCODING).GetBytes(command));
                byte[] receivedBytes = new byte[1024];
                int receivedLength = s.Receive(receivedBytes);
                string receivedString = Encoding.GetEncoding(ENCODING).GetString(receivedBytes, 0, receivedLength);
                if (receivedString == "Terminate") break;
                Console.WriteLine(receivedString);
            }
        }
    }
}
