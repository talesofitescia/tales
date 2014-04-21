using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame1
{
    class RenderSystem
    {
        List<RenderNode> targets;
        Engine engine;
        public RenderSystem(Engine engine)
        {
            this.engine = engine;
        }

        public void update(SpriteBatch spriteBatch)
        {
            targets = engine.getNodeList(new RenderNode().GetType()).Cast<RenderNode>().ToList();
            foreach (RenderNode target in targets)
            {
                spriteBatch.Draw(target.display.texture, target.position.position, new Rectangle((2 - 1) * 25, (1 - 1) * 27, 25, 27),
                Color.White);
            }
        }
    }
}
