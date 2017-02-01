using Akka.Actor;
using MovieStreaming.Messages;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using MovieStreaming.Exceptions;

namespace MovieStreaming.Actors
{
    public class MoviePlayCounterActor:ReceiveActor
    {
        Dictionary<string, int> _moviePlayCount;
        public MoviePlayCounterActor()
        {
            _moviePlayCount = new Dictionary<string, int>();
            Receive<IncrementCountMessage>(message => Handle(message));
        }

        private void Handle(IncrementCountMessage message)
        {
            if (!_moviePlayCount.ContainsKey(message.MovieTitle))
                _moviePlayCount[message.MovieTitle] = 0;
            _moviePlayCount[message.MovieTitle]++;
            Console.WriteLine($"{message.MovieTitle} count {_moviePlayCount[message.MovieTitle]}");

            if (message.MovieTitle == "twilight")
            {
                throw new TerribleMovieException();
            }
        }

        protected override void PreRestart(Exception reason, object message)
        {
            base.PreRestart(reason, message);
            Console.WriteLine("prerestart .......");
        }

        protected override void PostStop()
        {
            base.PostStop();

            Console.WriteLine("post stop .......");
        }

        protected override void PostRestart(Exception reason)
        {
            base.PostRestart(reason);
            Console.WriteLine("post restart");
        }
    }
}