using System;
using Akka.Actor;
using Akka.Configuration;

namespace DeployTarget
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var system = ActorSystem.Create("DeployTarget", ConfigurationFactory.ParseString(@"
            akka {
                suppress-json-serializer-warning = on
                actor {
                  provider = ""Akka.Remote.RemoteActorRefProvider, Akka.Remote""
                }

                remote {
                    helios.tcp {
                        port = 8090
                        hostname = localhost
                    }
                }
            }")))
            {
                Console.ReadKey();
            }
        }
    }
}
