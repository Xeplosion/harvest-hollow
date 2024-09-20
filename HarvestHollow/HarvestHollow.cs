using System;
using System.Threading;
using System.Security.Cryptography;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

using HarvestHollow.Content;
using HarvestHollow.Tiles;
using System.Diagnostics;

namespace HarvestHollow
{
    public class HarvestHollow : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        public HarvestHollow()
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
        internal TileScroller Tiles;
        protected override void Initialize()
        {
            // Loads all non-graphical content.
            Console.WriteLine("Running initialization logic...");
            ProjectSettingsStruct settings = Content.Load<ProjectSettingsStruct>("./Content/Settings");
            ProjectSettings.CreateSettings(settings);

            // Initialize tile scrolling engine
            Tiles = new TileScroller(GraphicsDevice.DisplayMode.Width, GraphicsDevice.DisplayMode.Height);

            if (ProjectSettings.LoadLevelEditor)
            {
                // Code for level editor here.
            } else
            {
                // Regular launch initialization.
            }

            base.Initialize();
        }
        internal Assets GameAssets;
        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: add all loading screen assets.

            // Loads all audio and graphical content.
            Console.WriteLine("Loading game content...");

            Content.RootDirectory = "./Content";
            //GameAssets = new Assets(Content);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // Runs prior to Draw() method.
            if (ProjectSettings.LoadLevelEditor)
            {
                // Code for level editor here.
                base.Update(gameTime);
                return; // No need to update the rest of the game.
            }

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