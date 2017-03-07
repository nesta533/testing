using System;
using Akka.Actor;

namespace HelloWorld
{
    public class GreetingActor : ReceiveActor
    {
        public GreetingActor()
        {
            Receive<Greet>( greet => { Console.WriteLine("Hello {0}", greet.Who); });
        }
        public class Greet
        {
            public Greet(string who)
            {
                Who = who;
            }
            public string Who{ get; private set; }
        }

    }
}
