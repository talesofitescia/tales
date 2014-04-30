using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame1
{
    class AttackSystem : ISystem
    {
        Engine engine;
        List<AttackNode> targets;

        public AttackSystem(Engine engine)
        {
            this.engine = engine;
        }

        public void update(GameTime gameTime)
        {
            targets = engine.getNodeList(new AttackNode().GetType()).Cast<AttackNode>().ToList();
            
            foreach (AttackNode target in targets)
            {

            }
        }
    }
}
