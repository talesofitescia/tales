using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame1
{
    class PositionComponent
    {
        public Rectangle position { get; set; }
        public Direction direction { get; set; }
        
        public PositionComponent(int x, int y, int width, int height)
        {
            position = new Rectangle(x, y, width, height);
            direction = Direction.Down;
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
