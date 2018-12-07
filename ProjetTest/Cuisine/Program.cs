using System;
using Cuisine;

namespace Cuisine
{
    class Program
    {
        public static int Main(String[] args)
        {
            AsynchronousSocketListener.StartListening();
            return 0;
        }
    }
}
