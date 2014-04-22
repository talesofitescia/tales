using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame1
{
    class PositionComponent
    {
        public Rectangle Position { get; set; }
        public Direction Direction { get; set; }
        
        public PositionComponent(int x, int y, int width, int height)
        {
            Position = new Rectangle(x, y, width, height);
            Direction = Direction.Down;
        }
    }
    /*enum Direction
    {
        Up,
        Down,
        Left,
        Right
    */
}
