using Akka.Actor;
using MovieStreaming.Actors;
using MovieStreaming.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MovieStreaming
{
    class Program
    {
        static ActorSystem MovieStreamingActorSystem;

        static void Main(string[] args)
        {
            MovieStreamingActorSystem = ActorSystem.Create("MovieStreamingActorSystem");
            Console.WriteLine("Actor system created");

            var playbackActorProps = Props.Create<PlaybackActor>();
            IActorRef playbackActorRef = MovieStreamingActorSystem.ActorOf(playbackActorProps, "Playback");

            //IActorRef playbackActorRef = MovieStreamingActorSystem
            //    .ActorSelection("akka.tcp://MovieStreamingActorSystem@127.0.0.1:8092/user/Playback")
            //       .ResolveOne(TimeSpan.FromSeconds(3))
            //    .Result;

            IActorRef userActorRef = MovieStreamingActorSystem.ActorOf<UserActor>("UserActor");

            do
            {
                Thread.Sleep(500);
                Console.WriteLine();
                var cmd = Console.ReadLine();
                if (cmd.StartsWith("play"))
                {
                    var userId = int.Parse(cmd.Split(',')[1]);
                    var title = cmd.Split(',')[2];
                    var msg = new PlayMovieMessage(title, userId);
                    MovieStreamingActorSystem.ActorSelection("/user/Playback/UserCoordinator").Tell(msg);
                }
                if (cmd.StartsWith("stop"))
                {
                    var userId = int.Parse(cmd.Split(',')[1]);
                    var title = cmd.Split(',')[2];
                    var msg = new StopMovieMessage(userId);
                    MovieStreamingActorSystem.ActorSelection("/user/Playback/UserCoordinator").Tell(msg);
                }
                if (cmd == "exit")
                {
                    MovieStreamingActorSystem.Terminate();
                    Console.ReadKey();
                    Environment.Exit(1);

                }
            } while (true);



            //userActorRef.Tell(new PlayMovieMessage("Akka The Movie", 9));
            //Console.ReadLine();
            //userActorRef.Tell(new StopMovieMessage());
            //Console.ReadLine();
            //userActorRef.Tell(new PlayMovieMessage("test1", 9));
            //Console.ReadLine();
            //userActorRef.Tell(new StopMovieMessage());
            //Console.ReadLine();
            //userActorRef.Tell(new PlayMovieMessage("test2", 9));
            //Console.ReadLine();
            //userActorRef.Tell(new StopMovieMessage());
            //Console.ReadLine();
            //userActorRef.Tell(new PlayMovieMessage("test3", 9));
            //Console.ReadLine();
            //userActorRef.Tell(new StopMovieMessage());
            //Console.ReadLine();
            //userActorRef.Tell(new StopMovieMessage());
            //Console.ReadLine();
            MovieStreamingActorSystem.Terminate();
        }
    }
}
