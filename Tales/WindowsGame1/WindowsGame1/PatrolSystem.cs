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
        public void update(GameTime gameTime)
        {
            targets = engine.getNodeList(new PatrolNode().GetType()).Cast<PatrolNode>().ToList();

            Rectangle pos;
            // Représente un rectange dont la surface représente la porté d'une entité
            Rectangle vRange;
            int range;
            foreach (PatrolNode target in targets)
            {
                //On regarde si un gentil est dans le range du méchant
                range = target.Range.Range;
                pos = target.Position.Position;
                vRange = new Rectangle(pos.X - range, pos.Y - range, 2 * range + pos.Width, 2 * range + pos.Height);
                PositionComponent heroPosition = (PositionComponent) engine.getHero().get(new PositionComponent(0, 0, 0, 0).GetType());
                if (vRange.Intersects(heroPosition.Position))
                {
                    break;
                }
                
                target.Collision.Collide = false;
                Rectangle rectangle;
                int x = target.Position.Position.X;
                int y = target.Position.Position.Y;
                int width = target.Position.Position.Width;
                int height = target.Position.Position.Height;
                int velocityX = target.Velocity.velocityX;
                int velocityY = target.Velocity.velocityY;
                rectangle = new Rectangle(x, y, width, height);
                PatrolState state = target.Patrol.State;
                PatrolState lastState = target.Patrol.LastState;
                int maxOffset = target.Patrol.MaxOffset;
                double timeCheck = target.Patrol.LastUpdateMilliseconds;

                switch (state)
                {
                    case PatrolState.Up:
                        if (target.Patrol.Offset <= maxOffset)
                        {
                            rectangle = new Rectangle(x, y - velocityY, width, height);
                            target.Patrol.Offset++;
                        }
                        else
                        {
                            target.Patrol.Offset = 0;
                            target.Patrol.LastState = PatrolState.Up;
                            target.Patrol.State = PatrolState.Wait;
                            target.Patrol.LastUpdateMilliseconds = gameTime.TotalGameTime.TotalMilliseconds;
                        }
                        break;
                    case PatrolState.Down:
                        if (target.Patrol.Offset <= maxOffset)
                        {
                            rectangle = new Rectangle(x, y + velocityY, width, height);
                            target.Patrol.Offset++;;
                        }
                        else
                        {
                            target.Patrol.Offset = 0;
                            target.Patrol.LastState = PatrolState.Down;
                            target.Patrol.State = PatrolState.Wait;
                            target.Patrol.LastUpdateMilliseconds = gameTime.TotalGameTime.TotalMilliseconds;
                        }
                        break;
                    case PatrolState.Left:
                        if (target.Patrol.Offset <= maxOffset)
                        {
                            rectangle = new Rectangle(x - velocityX, y, width, height);
                            target.Patrol.Offset++;
                        }
                        else
                        {
                            target.Patrol.Offset = 0;
                            target.Patrol.LastState = PatrolState.Left;
                            target.Patrol.State = PatrolState.Wait;
                            target.Patrol.LastUpdateMilliseconds = gameTime.TotalGameTime.TotalMilliseconds;
                        }
                        break;
                    case PatrolState.Right:
                        if (target.Patrol.Offset <= maxOffset)
                        {
                            rectangle = new Rectangle(x + velocityX, y, width, height);
                            target.Patrol.Offset++;
                        }
                        else
                        {
                            target.Patrol.Offset = 0;
                            target.Patrol.LastState = PatrolState.Right;
                            target.Patrol.State = PatrolState.Wait;
                            target.Patrol.LastUpdateMilliseconds = gameTime.TotalGameTime.TotalMilliseconds;
                        }
                        break;
                    case PatrolState.Wait:
                        if (gameTime.TotalGameTime.TotalMilliseconds - target.Patrol.LastUpdateMilliseconds > 1500)
                        {
                            switch (lastState)
                            {
                                case PatrolState.Up:
                                    target.Patrol.State = PatrolState.Right;
                                    break;
                                case PatrolState.Down:
                                    target.Patrol.State = PatrolState.Left;
                                    break;
                                case PatrolState.Left:
                                    target.Patrol.State = PatrolState.Up;
                                    break;
                                case PatrolState.Right:
                                    target.Patrol.State = PatrolState.Down;
                                    break;
                            }
                        }
                        break;
                }
                target.Collision.Position = rectangle;
            }
        }
    }
}
