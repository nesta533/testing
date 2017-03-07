using System;
using Akka.Actor;

namespace EchoActorLib
{
    public class EchoActor : ReceiveActor
    {
        public EchoActor()
        {
            Receive<Hello>(hello =>
            {
                Console.WriteLine("[{0}]: {1}", Sender, hello.Message);
                Sender.Tell(hello);
            });
        }
    }

    public class Hello
    {
        public Hello(string message)
        {
            Message = message;
        }
        public string Message { get; private set; }
    }
}
