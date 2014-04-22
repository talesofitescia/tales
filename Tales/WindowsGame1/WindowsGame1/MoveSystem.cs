using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame1
{
    class MoveSystem : ISystem
    {
        Engine engine;
        List<MoveNode> targets;

        public MoveSystem(Engine engine)
        {
            this.engine = engine;
        }
        public void update(Microsoft.Xna.Framework.GameTime gameTime)
        {
            targets = engine.getNodeList(new MoveNode().GetType()).Cast<MoveNode>().ToList();
            foreach (MoveNode target in targets)
            {
                Rectangle col = target.Collision.Position;
                Rectangle rect = target.Position.Position;

                if (!target.Collision.Collide)
                {
                    //target.Position.Position = target.Collision.Position;
                    target.Position.Position = new Rectangle(col.X, col.Y, col.Width, col.Height);
                    target.Display.Animate = true;
                }
                if (rect.X == col.X && rect.Y == col.Y)
                {
                    target.Display.Animate = false;
                    target.Display.FrameColumns = 1;
                }
            }
            
        }
    }
}
