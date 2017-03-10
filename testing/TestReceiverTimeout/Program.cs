using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Akka.Actor;

namespace TestReceiverTimeout
{
    class Program
    {
        static void Main(string[] args)
        {
            var system = ActorSystem.Create("system");

            var echo = system.ActorOf<Echo>("echo");

            // adjust the interval to see if can echo the timeout message.
            TimeSpan interval = TimeSpan.FromSeconds(2.0);

            for (var i = 0; i < 10; i++)
            {
                echo.Tell("Hello " + i.ToString());
                Thread.Sleep(interval);      
            }

            Console.ReadKey();
        }
    }
}
