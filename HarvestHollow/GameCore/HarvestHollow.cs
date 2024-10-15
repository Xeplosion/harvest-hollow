using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Steamworks;

namespace HarvestHollow.GameCore;

/// <summary> 
/// The main game class for Harvest Hollow. Inherits from Microsoft.Xna.Framework.Game. 
/// </summary>
public class HarvestHollow : Game
{
    private readonly GraphicsDeviceManager _graphics;
    private SpriteBatch? _spriteBatch;
    private const int _minScreenWidth = 500;
    private const int _minScreenHeight = 500;

    /// <summary>
    /// Constructor used to initialize graphical settings for the game.
    /// </summary>
    public HarvestHollow()
    {
        // Initialize graphics device manager and content directory.
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "./Content";

        // Screen settings: resolution, format, full-screen mode, and orientation.
        _graphics.PreferredBackBufferFormat = SurfaceFormat.Color;
        _graphics.PreferredBackBufferWidth = 1080;
        _graphics.PreferredBackBufferHeight = 720;
        _graphics.IsFullScreen = true;
        _graphics.SupportedOrientations = DisplayOrientation.LandscapeLeft | DisplayOrientation.LandscapeRight;

        // Frame rate and vertical sync control.
        _graphics.SynchronizeWithVerticalRetrace = true;  // Enable VSync
        IsFixedTimeStep = false;                          // Disable fixed time step for unlocked frame rate
        TargetElapsedTime = TimeSpan.FromSeconds(1.0f / 60.0f);  // Target 60 FPS

        // Hardware mode and anti-aliasing settings.
        _graphics.HardwareModeSwitch = false;  // Soft full-screen switch for smoother transitions
        _graphics.PreferMultiSampling = false;  // Disable multi-sampling to maintain pixel art clarity

        // Apply all changes to graphics settings.
        _graphics.ApplyChanges();

        // Window settings: title, resizing, and behavior options.
        Window.Title = $"Harvest Hollow - {ProjectSettings.Version}";
        Window.AllowUserResizing = true;
        Window.ClientSizeChanged += onClientSizeChanged;
        Window.AllowAltF4 = true;
        Window.IsBorderless = false;  // Window with borders and title bar for better control

        // Mouse visibility.
        IsMouseVisible = false;  // Set according to game design preferences
    }
    private bool _isClientSizeChanged = false;
    /// <summary>
    /// Handles window resizing events.
    /// </summary>
    private void onClientSizeChanged(object? sender, EventArgs e)
    {
        // Let the game loop know that the client size has changed.
        _isClientSizeChanged = true;
    }
    public void ClientSizeChangedEvents()
    {
        // Enforces a minimum window size.
        _isClientSizeChanged = false;
        _graphics.PreferredBackBufferWidth = Math.Max(Window.ClientBounds.Width, _minScreenWidth);
        _graphics.PreferredBackBufferHeight = Math.Max(Window.ClientBounds.Height, _minScreenHeight);
        _graphics.ApplyChanges();

        // Update any game logic that depends on the new window size.
    }
    /// <summary>
    /// Initializes non-graphical content and settings for the game.
    /// </summary>
    protected override void Initialize()
    {
        // Changes to the graphical settings after GraphicsDevice initialization:
        _graphics.GraphicsDevice.SamplerStates[0] = SamplerState.PointClamp;  // Use point clamp for pixel-perfect scaling
        _graphics.GraphicsDevice.BlendState = BlendState.AlphaBlend;  // Enable alpha blending for transparency
        _graphics.GraphicsDevice.PresentationParameters.PresentationInterval = PresentInterval.One;  // Lock to the monitor's refresh rate

        // Loads all non-graphical content.
        Console.WriteLine("Running initialization logic...");

        Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

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
    private bool _isF11Pressed = false;
    /// <summary>
    /// Updates game state, processes input, and handles game logic.
    /// </summary>
    /// <param name="gameTime">Provides information about the timing of the game loop.</param>
    protected override void Update(GameTime gameTime)
    {
        // Handle window resizing events.
        if (_isClientSizeChanged)
        {
            ClientSizeChangedEvents();
        }
        // Handle input commands.
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // Check if F11 key is pressed to toggle full-screen mode.
        if (Keyboard.GetState().IsKeyDown(Keys.F11))
        {
            if (!_isF11Pressed)
            {
                _isF11Pressed = true;
                _graphics.ToggleFullScreen();
            }
        }
        else
        {
            _isF11Pressed = false;
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
