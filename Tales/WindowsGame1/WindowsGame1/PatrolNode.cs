using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame1
{
    class PatrolNode : Node
    {
        public CollisionComponent Collision { get; set; }
        public PositionComponent Position { get; set; }
        public VelocityComponent Velocity { get; set; }
        public PatrolComponent Patrol { get; set; }
        public RangeOfViewComponent Range { get; set; }
    }
}
