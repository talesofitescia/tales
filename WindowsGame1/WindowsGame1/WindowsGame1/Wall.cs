using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace WindowsGame1
{
    class Wall
    {
        public static Texture2D texture;
        public Rectangle hitbox;
        Color color;

        //public Wall(int x, int y, Texture2D texture)
        public Wall(int x, int y, int size, Color color)
        {
            //Wall.texture = texture;
            this.color = color;
            hitbox = new Rectangle(x, y, size, size);
        }

        // CONSTRUCTOR

        // METHODS
        public static void LoadContent(ContentManager content)
        {
            texture = content.Load<Texture2D>("pixel");
        }

        // UPDATE AND DRAW
        public void Update(MouseState mouse, KeyboardState keyboard)
        {

        }

        public void Draw(SpriteBatch spritebatch)
        {
            spritebatch.Draw(texture, this.hitbox, color);
        }
    }
}
