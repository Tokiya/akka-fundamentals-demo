using Akka.Actor;
using MovieStreaming.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStreaming.Actors
{
    public class PlaybackStatisticsActor:ReceiveActor
    {
        public PlaybackStatisticsActor()
        {
            Context.ActorOf(Props.Create<MoviePlayCounterActor>(), "MoviePlayerCounter");
        }

        //protected override SupervisorStrategy SupervisorStrategy()
        //{
        //    return new OneForOneStrategy(exception => 
        //    {
        //        if (exception is TerribleMovieException)
        //            return Directive.Resume;
        //        return Directive.Restart;
        //    });
        //}
    }
}
