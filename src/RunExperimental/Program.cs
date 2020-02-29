using System;

using TheLosers.BH4.XamarinApp;

namespace TheLosers.BH4.RunExperimental
{
    class Program
    {
        public static void Main()
        {
            int i = 0;
            Sockets.RunClient(Sockets.HOST, Sockets.PORT, (socket, str) => {
                Console.WriteLine(str);
                return str;
            }, default);
            //Sockets.RunServer(Sockets.HOST, Sockets.PORT, () => i++.ToString(), default);
        }
    }
}
