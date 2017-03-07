using Akka.Actor;
using Akka.Configuration;
using EchoActorLib;
using System;

namespace Deployer
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var system = ActorSystem.Create("Deployer", ConfigurationFactory.ParseString(@"
            akka {
                suppress-json-serializer-warning = on

                actor{
                    provider = ""Akka.Remote.RemoteActorRefProvider, Akka.Remote""
                    deployment {
                        /remoteecho {
                            remote = ""akka.tcp://DeployTarget@localhost:8090""
                        }
                    }
                }
                remote {
                    helios.tcp {
                        port = 0
                        hostname = localhost
                    }
                }
            }")))
            {
                // deploy remotely via config
                var remoteEcho1 = system.ActorOf(Props.Create(() => new EchoActor()), "remoteecho");

                //deploy remotely via code
                var remoteAddress = Address.Parse("akka.tcp://DeployTarget@localhost:8090");
                var remoteEcho2 = system.ActorOf(Props.Create(() => new EchoActor()).WithDeploy(Deploy.None.WithScope(
                    new RemoteScope(remoteAddress))), "coderemoteecho");

                system.ActorOf(Props.Create(() => new HelloActor(remoteEcho1)));
                system.ActorOf(Props.Create(() => new HelloActor(remoteEcho2)));

                Console.ReadKey();
            }
        }
    }
}
