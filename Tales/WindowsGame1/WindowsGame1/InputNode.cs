﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame1
{
    class InputNode : Node
    {
        public PositionComponent Position { get; set; }
        public CollisionComponent Collision { get; set; }
        public VelocityComponent Velocity { get; set; }
    }
}
