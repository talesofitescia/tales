using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame1
{
    class AnimationSystem : ISystem
    {
        List<AnimationNode> targets;
        Engine engine;
        public AnimationSystem(Engine engine)
        {
            this.engine = engine;
        }
        public void update(GameTime gameTime)
        {
            targets = engine.getNodeList(new AnimationNode().GetType()).Cast<AnimationNode>().ToList();
            foreach (AnimationNode target in targets)
            {
                DisplayComponent display = target.display;
                PositionComponent position = target.position;
                switch (position.Direction)
                {
                    case Direction.Up:
                        display.FrameRows = 1;
                        display.Effect = SpriteEffects.None;
                        break;
                    case Direction.Down:
                        display.FrameRows = 0;
                        display.Effect = SpriteEffects.None;
                        break;
                    case Direction.Left:
                        display.FrameRows = 2;
                        display.Effect = SpriteEffects.FlipHorizontally;
                        break;
                    case Direction.Right:
                        display.FrameRows = 2;
                        display.Effect = SpriteEffects.None;
                        break;
                }

                if (target.display.Animate)
                {
                    display.FrameColumns++;
                    if (display.FrameColumns == 3)
                        display.FrameColumns = 0;
                }
            }
        }
    }
}
