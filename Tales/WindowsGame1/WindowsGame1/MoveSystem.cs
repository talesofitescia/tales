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
                // Si il n'y a pas collision et demande de déplacement, on anime le personnage
                if (!target.Collision.Collide)
                {
                    //target.Position.Position = target.Collision.Position;
                    target.Position.Position = new Rectangle(col.X, col.Y, col.Width, col.Height);
                    target.Display.Animate = true;
                }
                // S'il y a collision, on n'anime pas le personnage et on met position colonne milieu
                else
                {
                    target.Display.Animate = false;
                    target.Display.FrameColumns = 1;
                }
                // Si il n'y a pas de demande de déplacement, on n'anime pas le personnage et ou met position colonne milieu
                if (rect.X == col.X && rect.Y == col.Y)
                {
                    target.Display.Animate = false;
                    target.Display.FrameColumns = 1;
                }
            }
            
        }
    }
}
