using Akka.Actor;
using MovieStreaming.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStreaming.Actors
{
    public class UserActor : ReceiveActor
    {
        private string _currentlyWatching;
        private int userId;

        public UserActor()
        {
            Stopped();
            //Receive<PlayMovieMessage>(message => HandlePlayMovieMessage(message));
            //Receive<StopMovieMessage>(message => HandleStopMovieMessage(message));
        }

        public UserActor(int userId):this()
        {
            this.userId = userId;
        }

        private void Playing()
        {
            Receive<PlayMovieMessage>(message => Console.WriteLine("Error Can not  start playing movie when is currently playing..."));
            Receive<StopMovieMessage>(message => StopPlayingMovie());
            Console.WriteLine("User actor became playing");
        }

        private void Stopped()
        {
            Receive<PlayMovieMessage>(message => StartPlayingMovie(message.MovieTitle));
            Receive<StopMovieMessage>(message =>
                Console.WriteLine("Erro... Can not stop when nothing is playing"));
            Console.WriteLine("User became stopped");
        }

        //private void HandleStopMovieMessage(StopMovieMessage message)
        //{
        //    if (_currentlyWatching == null)
        //        Console.WriteLine("Erro... Can not stop");
        //    else
        //        StopPlayingMovie();
        //}

        private void StopPlayingMovie()
        {
            Console.WriteLine($"user {userId} Stopping: {_currentlyWatching}");
            _currentlyWatching = null;
            Become(Stopped);
        }

        //private void HandlePlayMovieMessage(PlayMovieMessage message)
        //{
        //    if (_currentlyWatching != null)
        //        Console.WriteLine("Error...can not play movie");
        //    else
        //        StartPlayingMovie(message.MovieTitle);
        //}

        private void StartPlayingMovie(string movieTitle)
        {
            _currentlyWatching = movieTitle;
            Console.WriteLine($"user {userId} watching: {_currentlyWatching}");
            Context.ActorSelection("/user/Playback/PlaybackStatistics/MoviePlayerCounter").Tell(new IncrementCountMessage(movieTitle));
            Become(Playing);
        }


    }
}
