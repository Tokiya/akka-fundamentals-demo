using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStreaming.Messages
{
    public class IncrementCountMessage
    {
        public string MovieTitle { get; private set; }
        public IncrementCountMessage(string movieTitle)
        {
            MovieTitle = movieTitle;
        }
    }
}
