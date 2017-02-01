﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStreaming.Messages
{
    public class StopMovieMessage
    {
        public int UserId { get; private set; }
        public StopMovieMessage(int userId)
        {
            UserId = userId;
        }
    }
}
