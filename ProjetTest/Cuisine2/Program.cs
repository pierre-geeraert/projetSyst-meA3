using System;
using Cuisine;

namespace Cuisine
{
    class Program
    {
        public static int Main(String[] args)
        {
            SocketListener.StartServer();
            return 0;
        }
    }
}