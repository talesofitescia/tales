using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame1
{
    class PatrolSystem : ISystem
    {
        Engine engine;
        List<PatrolNode> targets;

        public PatrolSystem(Engine engine)
        {
            this.engine = engine;
        }
        // A virer !!!!!!!!!!!!
        Direction direction = Direction.Right;
        int largeur = 0;
        public void update(GameTime gameTime)
        {
            targets = engine.getNodeList(new PatrolNode().GetType()).Cast<PatrolNode>().ToList();
            foreach (PatrolNode target in targets)
            {
                target.Collision.Collide = false;

                Rectangle rectangle;
                int x = target.Position.Position.X;
                int y = target.Position.Position.Y;
                int width = target.Position.Position.Width;
                int height = target.Position.Position.Height;
                int velocityX = target.Velocity.velocityX;
                int velocityY = target.Velocity.velocityY;
                rectangle = new Rectangle(x, y, width, height);


                switch (direction)
                {
                    case Direction.Left:
                        if (largeur < 20)
                        {
                            largeur++;
                            rectangle = new Rectangle(x - largeur, y, width, height);
                        }
                        else
                        {
                            largeur = 0;
                            direction = Direction.Right;
                        }
                        break;
                    case Direction.Right:
                        if (largeur < 20)
                        {
                            largeur++;
                            rectangle = new Rectangle(x + largeur, y, width, height);
                        }
                        else
                        {
                            largeur = 0;
                            direction = Direction.Left;
                        }
                        break;
                }
                target.Collision.Position = rectangle;
            }
        }
    }
}
