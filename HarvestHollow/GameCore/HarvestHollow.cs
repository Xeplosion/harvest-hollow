using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace HarvestHollow.GameCore;

/// <summary> 
/// The main game class for Harvest Hollow. Inherits from Microsoft.Xna.Framework.Game. 
/// </summary>
public class HarvestHollow : Game
{
    private readonly GraphicsDeviceManager _graphics;
    private SpriteBatch? _spriteBatch;

    /// <summary>
    /// Constructor used to initialize graphical settings for the game.
    /// </summary>
    public HarvestHollow()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "./Content";

        // Set preferred back buffer format and dimensions.
        _graphics.PreferredBackBufferFormat = SurfaceFormat.Color;
        _graphics.PreferredBackBufferWidth = 1920;
        _graphics.PreferredBackBufferHeight = 1080;

        // Set full-screen mode and orientation support.
        _graphics.IsFullScreen = true;
        _graphics.SupportedOrientations = DisplayOrientation.LandscapeLeft | DisplayOrientation.LandscapeRight;

        // Configure multi-sampling and vertical sync.
        _graphics.PreferMultiSampling = false; // Redundant; set once.
        _graphics.HardwareModeSwitch = false;
        _graphics.SynchronizeWithVerticalRetrace = true;

        // Set presentation interval.
        _graphics.GraphicsDevice.PresentationParameters.PresentationInterval = PresentInterval.One;

        // Set texture sampling state.
        _graphics.GraphicsDevice.SamplerStates[0] = SamplerState.PointClamp;

        // Apply changes.
        _graphics.ApplyChanges();

        // Optional: Disable the fixed time step if not needed.
        IsFixedTimeStep = false;
        _graphics.SynchronizeWithVerticalRetrace = false;
        IsMouseVisible = false;
    }
    /// <summary>
    /// Initializes non-graphical content and settings for the game.
    /// </summary>
    protected override void Initialize()
    {
        // Loads all non-graphical content.
        Console.WriteLine("Running initialization logic...");

        Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

        if (ProjectSettings.LoadLevelEditor)
        {
            // Code for level editor here.
        }
        else
        {
            // Regular launch initialization.
        }

        base.Initialize();
    }
    internal Assets? _gameAssets;
    /// <summary>
    /// Loads graphical, and audio content, as well as all game assets.
    /// </summary>
    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        // TODO: add all loading screen assets.

        _gameAssets = new Assets(Content);
    }
    /// <summary>
    /// Updates game state, processes input, and handles game logic.
    /// </summary>
    /// <param name="gameTime">Provides information about the timing of the game loop.</param>
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
    /// <summary>
    /// Draws all game content onto the screen.
    /// </summary>
    /// <param name="gameTime">Provides information about the timing of the game loop.</param>
    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.Black);

        // Renders all game assets and sprites.

        base.Draw(gameTime);
    }
}
