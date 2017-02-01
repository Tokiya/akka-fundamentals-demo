using Akka.Actor;
using MovieStreaming.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStreaming.Actors
{
    public class UserCoordinatorActor:ReceiveActor
    {
        Dictionary<int, IActorRef> _users;

        public UserCoordinatorActor()
        {
            _users = new Dictionary<int, IActorRef>();

            Receive<PlayMovieMessage>(message =>
            {
                CreateChildUserIfnotExists(message.UserId);
                IActorRef child = _users[message.UserId];
                child.Tell(message);
            });
            Receive<StopMovieMessage>(message =>
            {
                CreateChildUserIfnotExists(message.UserId);
                IActorRef child = _users[message.UserId];
                child.Tell(message);
            });
        }

        private void CreateChildUserIfnotExists(int userId)
        {
            if (!_users.ContainsKey(userId))
            {
                IActorRef newChild = Context.ActorOf(Props.Create(() => new UserActor(userId)), "User" + userId);
                _users[userId] = newChild;
            }
        }
    }
}
