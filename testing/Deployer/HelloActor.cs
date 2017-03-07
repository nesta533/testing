using System;
using Akka.Actor;
using EchoActorLib;

namespace Deployer
{
    class HelloActor : ReceiveActor
    {
        class SayHello { }

        private IActorRef _remoteActor;
        private int _helloCounter;
        private ICancelable _helloTask;

        public HelloActor(IActorRef remoteActor)
        {
            _remoteActor = remoteActor;
            Receive<Hello>(hello =>
            {
                Console.WriteLine("Received {1} from {0}", Sender, hello.Message);
            });

            Receive<SayHello>(sayHello =>
            {
                _remoteActor.Tell(new Hello("hello" + _helloCounter++));
            });
        }

        protected override void PreStart()
        {
            _helloTask = Context.System.Scheduler.ScheduleTellRepeatedlyCancelable(TimeSpan.FromSeconds(1),
                TimeSpan.FromSeconds(1), Context.Self, new SayHello(), ActorRefs.Nobody);
        }

        protected override void PostStop()
        {
            _helloTask.Cancel();
        }
    }
}
