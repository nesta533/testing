using System;
using System.Threading.Tasks;
using Akka.Actor;

namespace AKKASwitchTesting
{
    class Program
    {
        static void Main(string[] args)
        {
            var system = ActorSystem.Create("Sample");
            var actor = system.ActorOf<FreeBusyActor>();
            Task.Run(async () => {
                for (var i = 0; i < 10; i++)
                {
                    actor.Tell("get busy");
                    await Task.Delay(40);
                }

                await Task.Delay(500);
            }).Wait();

            Console.ReadLine();

        }

        public class FreeBusyActor : ReceiveActor
        {
            public FreeBusyActor()
            {
                Free();
            }

            void Free()
            {
                Receive<string>(s =>
                {
                    if (s == "get busy")
                    {
                        Console.WriteLine("Getting busy....");
                        Become(Busy);
                        Task.Delay(90).ContinueWith(_ => "you're free").PipeTo(Self, Self);

                    }

                });
            }

            void Busy()
            {
                Receive<string>(s =>
                {
                    if (s == "you're free" && Sender.Equals(Self))
                    {
                        Console.WriteLine("Getting free....");
                        Become(Free);
                    }
                    else
                    {
                        Console.WriteLine("Not dong anything, I'm busy...");
                    }

                });
            }

        }
    }
}
