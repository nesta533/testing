using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Akka.Actor;

namespace TestStash
{
    class Program
    {
        static void Main(string[] args)
        {
            var system = ActorSystem.Create("system");

            var protocol = system.ActorOf<ActorWithProtocol>("protocol");

            protocol.Tell("open");
            protocol.Tell("write");

            // stach the open message
            for (var i = 0; i < 10; i++)
            {
                protocol.Tell("open");
            }

            protocol.Tell("close");

            Console.ReadKey();
        }
    }
}
