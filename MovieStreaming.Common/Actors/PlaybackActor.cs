using Akka.Actor;
using MovieStreaming.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStreaming.Actors
{
    //public class PlaybackActor : UntypedActor
    public class PlaybackActor : ReceiveActor
    {
        public PlaybackActor()
        {
            Console.WriteLine("Creating playback actor...");

            Context.ActorOf<UserCoordinatorActor>("UserCoordinator");
            Context.ActorOf<PlaybackStatisticsActor>("PlaybackStatistics");
            
            //Receive(typeof(PlayMovieMessage));
            //Receive<PlayMovieMessage>(msg => HandlePlayMovieMessage(msg));
        }

        private void HandlePlayMovieMessage(PlayMovieMessage message) {
                
            Console.WriteLine("Received movie title: " + message.MovieTitle);
            Console.WriteLine("UserId: " + message.UserId);
        }
        //protected override void OnReceive(object message)
        //{
        //    var m = message as PlayMovieMessage;
        //    if (m != null)
        //    {
        //        Console.WriteLine("Received movie title: " + m.MovieTitle);
        //        Console.WriteLine("UserId: " + m.UserId);
        //    }
        //    else
        //        Unhandled(message);
        //}
    }
}
