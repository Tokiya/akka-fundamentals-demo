using Akka.Actor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStreaming.Remote
{
    class Program
    {
        static ActorSystem MovieStreamingActorSystem;
        static void Main(string[] args)
        {
            MovieStreamingActorSystem = ActorSystem.Create("MovieStreamingActorSystem");

            MovieStreamingActorSystem.AwaitTermination();
        }
    }
}
