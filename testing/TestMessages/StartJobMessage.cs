using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Akka.Actor;

namespace TestMessages
{
    public class StartJobMessage
    {
        public StartJobMessage(TestJob job, IActorRef requestor)
        {
            Job = job;
            Requestor = requestor;
        }

        public TestJob Job{ get; private set; }

        public IActorRef Requestor { get; private set; }
    }
}
