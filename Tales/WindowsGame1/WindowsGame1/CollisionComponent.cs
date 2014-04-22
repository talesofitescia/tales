using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame1
{
    class CollisionComponent
    {
        public Rectangle Position { get; set; }
        public bool Collide { get; set; }
        public CollisionComponent()
        {
            Collide = false;
        }
    }
}
