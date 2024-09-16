using System;
using System.Threading;
using System.Security.Cryptography;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
using Zambrin.Content;

namespace Zambrin
{
    public class Zambrin : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        public Zambrin()
        {
            // Graphical settings.
            _graphics = new GraphicsDeviceManager(this);
            _graphics.IsFullScreen = true;
            _graphics.PreferMultiSampling = false;
            _graphics.HardwareModeSwitch = false;
            _graphics.ApplyChanges();

            // Optional: Disable the fixed time step if not needed.
            IsFixedTimeStep = false;
            _graphics.SynchronizeWithVerticalRetrace = false;
            IsMouseVisible = false;
        }

        protected override void Initialize()
        {
            // Loads all non-graphical content.
            Console.WriteLine("Running initialization logic...");
            base.Initialize();
        }
        internal Assets GameAssets;
        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // Loads all graphical game content.
            Console.WriteLine("Loading game content...");

            Content.RootDirectory = "./Content";
            GameAssets = new Assets(Content);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // Runs prior to Draw() method.

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // Renders all game assets and sprites.

            base.Draw(gameTime);
        }
    }
}