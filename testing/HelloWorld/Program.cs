using System;
using Akka.Actor;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            var system = ActorSystem.Create("system");

            var greeter = system.ActorOf<GreetingActor>("greeter");

            greeter.Tell(new GreetingActor.Greet("World"));

            Console.ReadKey();
        }
    }
}
