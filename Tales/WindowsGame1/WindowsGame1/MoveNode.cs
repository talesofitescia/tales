using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame1
{
    class MoveNode : Node
    {
        public PositionComponent Position { get; set; }
        public CollisionComponent Collision { get; set; }
        public DisplayComponent Display { get; set; }
    }
}
