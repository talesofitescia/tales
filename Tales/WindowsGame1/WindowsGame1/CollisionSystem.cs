using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame1
{
    class CollisionSystem : ISystem
    {
        List<CollisionNode> targets;
        Engine engine;
        public CollisionSystem(Engine engine)
        {
            this.engine = engine;
        }
        public void update(GameTime gameTime)
        {
            targets = engine.getNodeList(new CollisionNode().GetType()).Cast<CollisionNode>().ToList();

            foreach (CollisionNode target in targets)
            {

                foreach (CollisionNode obj in targets)
                {
                    if (target != obj && target.Collision.Position.Intersects(obj.Collision.Position))
                    {
                        target.Collision.Collide = true;
                        break;
                    }
                }
            }
        }
    }
}
