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
    class GameMain
    {
        Rectangle hitbox;
        public static Texture2D texture;

        public GameMain()
        {
            hitbox = new Rectangle(0, 0, 16, 16);
        }

        public static void LoadContent(ContentManager content)
        {
            //texture = content.Load<Texture2D>("test");
            texture = content.Load<Texture2D>("pikachu_test");
        }
        public void Update(MouseState mouse, KeyboardState keyboard)
        {
            if (keyboard.IsKeyDown(Keys.Up))
            {
                hitbox.Y--;
            }
            if (keyboard.IsKeyDown(Keys.Down))
            {
                hitbox.Y++;
            }
            if (keyboard.IsKeyDown(Keys.Left))
            {
                hitbox.X--;
            }
            if (keyboard.IsKeyDown(Keys.Right))
            {
                hitbox.X++;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            //spriteBatch.Draw(GameMain.texture, hitbox, Color.White);
        }
    }
}
