using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame1
{
    class InputSystem : ISystem
    {
        List<InputNode> targets;
        Engine engine;
        public InputSystem(Engine engine)
        {
            this.engine = engine;
        }
        
        public void update(GameTime gameTime)
        {
            KeyboardState keyboard = Keyboard.GetState();
            MouseState mouse = Mouse.GetState();

            targets = engine.getNodeList(new InputNode().GetType()).Cast<InputNode>().ToList();
            foreach (InputNode target in targets)
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
                
                if (keyboard.IsKeyDown(Keys.Up))
                {
                    rectangle = new Rectangle(x, y - velocityY, width, height);
                    target.Position.Direction = Direction.Up;
                }
                else if (keyboard.IsKeyDown(Keys.Down))
                {
                    rectangle = new Rectangle(x, y + velocityY, width, height);
                    target.Position.Direction = Direction.Down;
                }
                else if (keyboard.IsKeyDown(Keys.Left))
                {
                    rectangle = new Rectangle(x - velocityX, y, width, height);
                    target.Position.Direction = Direction.Left;
                }
                else if (keyboard.IsKeyDown(Keys.Right))
                {
                    rectangle = new Rectangle(x + velocityX, y, width, height);
                    target.Position.Direction = Direction.Right;
                }

                target.Collision.Position = rectangle;
            }
        }
    }
}
