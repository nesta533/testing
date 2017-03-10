using Akka.Actor;
using System;


namespace TestReceiverTimeout
{
    class Echo : ReceiveActor
    {
        public Echo()
        {
            Receive<string>( s => Console.WriteLine(s));

            Receive<ReceiveTimeout>(timeout => Console.WriteLine(timeout.ToString()));

            Context.SetReceiveTimeout(TimeSpan.FromSeconds(3.0));
        }
    }
}
