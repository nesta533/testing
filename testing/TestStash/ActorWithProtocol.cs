using System;
using Akka.Actor;
namespace TestStash
{
    class ActorWithProtocol : UntypedActor, IWithUnboundedStash
    {
        public IStash Stash { get; set; }
        protected override void OnReceive(object message)
        {
            if (message.Equals("open"))
            {
                Console.WriteLine(message);

                BecomeStacked(m =>
               {
                   if (m.Equals("write"))
                   {
                       Console.WriteLine("Write");
                   }
                   else if (m.Equals("close"))
                   {
                       Stash.UnstashAll();
                       UnbecomeStacked();
                   }
                   else
                   {
                       Stash.Stash();
                   }
               });
            }
        }
    }
}
