using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame1
{
    public enum Direction
    {
        Up, Down, Left, Right
    };
    class Player
    {
        Rectangle hitbox;
        static Texture2D texture;

        Direction direction;
        SpriteEffects effect;
        bool animation;
        // 1 changement d'image une fois toutes les 1/animationSpeed
        int timer;
        int animationSpeed = 5;

        int FrameLine;
        int FrameColumn;
        public int Speed { get; set; }
        public Player()
        {
            hitbox = new Rectangle(0, 0, 25, 27);
            FrameLine = 1;
            FrameColumn = 2;
            animation = true;
            direction = Direction.Down;
            timer = 0;
            effect = SpriteEffects.None;

            Speed = 2;
        }

        public static void LoadContent(ContentManager content)
        {
            texture = content.Load<Texture2D>("pikachu");
        }

        void animate()
        {
            timer++;
            if (timer == animationSpeed)
            {
                timer = 0;
                if (animation)
                {
                    FrameColumn++;
                    if (FrameColumn == 3)
                        animation = false;
                }
                else
                {
                    FrameColumn--;
                    if (FrameColumn == 1)
                        animation = true;
                }
            }
            
        }
        public void Update(MouseState mouse, KeyboardState keyboard, List<Wall> walls)
        {
            if (keyboard.IsKeyDown(Keys.Up))
            {
                Rectangle newHitbox = new Rectangle(hitbox.X, hitbox.Y - Speed, hitbox.Width, hitbox.Width);
                bool collide = false;
                foreach (Wall wall in walls)
                {
                    if (newHitbox.Intersects(wall.hitbox))
                    {
                        collide = true;
                        break;
                    }
                }

                if (!collide)
                    hitbox.Y -= Speed;
                direction = Direction.Up;
                animate();
            }
            else if (keyboard.IsKeyDown(Keys.Down))
            {
                Rectangle newHitbox = new Rectangle(hitbox.X, hitbox.Y + Speed, hitbox.Width, hitbox.Width);
                bool collide = false;
                foreach (Wall wall in walls)
                {
                    if (newHitbox.Intersects(wall.hitbox))
                    {
                        collide = true;
                        break;
                    }
                }
                if (!collide)
                    hitbox.Y += Speed;
                direction = Direction.Down;
                animate();
            }
            else if (keyboard.IsKeyDown(Keys.Left))
            {
                Rectangle newHitbox = new Rectangle(hitbox.X - Speed, hitbox.Y, hitbox.Width, hitbox.Width);
                bool collide = false;
                foreach (Wall wall in walls)
                {
                    if (newHitbox.Intersects(wall.hitbox))
                    {
                        collide = true;
                        break;
                    }
                }
                if (!collide)
                    hitbox.X -= Speed;
                direction = Direction.Left;
                animate();
            }
            else if (keyboard.IsKeyDown(Keys.Right))
            {
                Rectangle newHitbox = new Rectangle(hitbox.X + Speed, hitbox.Y, hitbox.Width, hitbox.Width);
                bool collide = false;
                foreach (Wall wall in walls)
                {
                    if (newHitbox.Intersects(wall.hitbox))
                    {
                        collide = true;
                        break;
                    }
                }
                if (!collide)
                    hitbox.X += Speed;
                direction = Direction.Right;
                animate();
            }

            if (keyboard.IsKeyUp(Keys.Up) && keyboard.IsKeyUp(Keys.Down) && keyboard.IsKeyUp(Keys.Left) && keyboard.IsKeyUp(Keys.Right))
            {
                FrameColumn = 2;
                //direction = Direction.Down;
            }

            switch (direction)
            {
                case Direction.Up: FrameLine = 2;
                    effect = SpriteEffects.None;
                    break;
                case Direction.Down: FrameLine = 1;
                    effect = SpriteEffects.None;
                    break;
                case Direction.Left: FrameLine = 3;
                    effect = SpriteEffects.FlipHorizontally;
                    break;
                case Direction.Right: FrameLine = 3;
                    effect = SpriteEffects.None;
                    break;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Player.texture, hitbox, new Rectangle((FrameColumn - 1) * 25, (FrameLine - 1) * 27, 25, 27),
                Color.White, 0f, new Vector2(0, 0), effect, 0f);
        }
    }
}
