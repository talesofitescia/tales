using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;


namespace WindowsGame1
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Engine engine;

        Camera2d _camera;
        Texture2D mBackgroundTexture;
        
        //Player player;
        //List<Wall> walls;
        //bool clickDown;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            //IsMouseVisible = true;
            //clickDown = false;
            //graphics.IsFullScreen = true;

            //walls = new List<Wall>();
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            //player = new Player();
            engine = new Engine(Content);
            base.Initialize();
            
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            // TODO: use this.Content to load your game content here
            mBackgroundTexture = Content.Load<Texture2D>("gta_map2");
            _camera = new Camera2d(mBackgroundTexture.Width, mBackgroundTexture.Height, GraphicsDevice);
            //Player.LoadContent(Content);
            //Wall.LoadContent(Content);
        }

        private void CameraMouvement(Entity entity)
        {
            /*
            // Les flèches pour le déplacement
            KeyboardState keyboardState = Keyboard.GetState();
            Vector2 movement = Vector2.Zero;
            if (keyboardState.IsKeyDown(Keys.Left))
                movement.X--;
            if (keyboardState.IsKeyDown(Keys.Right))
                movement.X++;
            if (keyboardState.IsKeyDown(Keys.Up))
                movement.Y--;
            if (keyboardState.IsKeyDown(Keys.Down))
                movement.Y++;
            _camera.Pos += movement * 20;
            //PageDown et PageUp pour le zoom
            if (keyboardState.IsKeyDown(Keys.PageDown))
                _camera.Zoom -= 0.05f;
            if (keyboardState.IsKeyDown(Keys.PageUp))
                _camera.Zoom += 0.05f;
             */
            PositionComponent position = (PositionComponent) entity.get(new PositionComponent(0, 0, 0, 0).GetType());
            float x = position.Position.X;
            float y = position.Position.Y;
            _camera.Pos = new Vector2(x, y);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            /*if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();
            // TODO: Add your update logic here
            player.Update(Mouse.GetState(), Keyboard.GetState(), walls);

            foreach (Wall w in walls)
            {
                w.Update(Mouse.GetState(), Keyboard.GetState());
            }


            if (Mouse.GetState().LeftButton == ButtonState.Pressed && !clickDown)
            {
                walls.Add(new Wall(Mouse.GetState().X, Mouse.GetState().Y, 32, Color.Black));
                clickDown = true;
            }
            if (Mouse.GetState().LeftButton == ButtonState.Released && clickDown)
            {
                clickDown = false;
            }*/

            CameraMouvement(engine.getHero());
            engine.update(gameTime);

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            //spriteBatch.Begin();
            
            /*foreach (Wall w in walls)
            {
                w.Draw(spriteBatch);
            }
            player.Draw(spriteBatch);*/
            
            
            
            //engine.Draw(spriteBatch);
            //spriteBatch.End();
            //base.Draw(gameTime);


            GraphicsDevice.Clear(Color.Black);
            spriteBatch.Begin(SpriteSortMode.Immediate,
                BlendState.AlphaBlend, SamplerState.PointClamp,
                null, null, null, _camera.GetTransformation());
            spriteBatch.Draw(mBackgroundTexture, Vector2.Zero, mBackgroundTexture.Bounds, Color.White);
            engine.Draw(spriteBatch);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
