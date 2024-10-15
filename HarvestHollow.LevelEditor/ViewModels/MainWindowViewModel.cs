using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using HarvestHollow.LevelEditor.Views.MonoGameControls;
using System.Windows.Controls;
using System.ComponentModel;

namespace HarvestHollow.LevelEditor.ViewModels;

/// <summary>
/// ViewModel for the main window in the Harvest Hollow Level Editor, 
/// inheriting from <see cref="MonoGameViewModel"/>.
/// </summary>
/// <remarks>
/// The <see cref="MainWindowViewModel"/> class manages the game content, 
/// handles input events, updates the game state, and draws graphics using MonoGame.
/// </remarks>
public class MainWindowViewModel : MonoGameViewModel
{
    private SpriteBatch _spriteBatch = default!;
    private Texture2D _texture = default!;
    private Vector2 _position;
    private float _rotation;
    private Vector2 _origin;
    private Vector2 _scale;
    private float _rotationSign = 1;

    /// <summary>
    /// Gets the view model for the menu control.
    /// </summary>
    public MenuControlViewModel MenuViewModel { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="MainWindowViewModel"/> class.
    /// </summary>
    public MainWindowViewModel()
    {
        MenuViewModel = new MenuControlViewModel();
    }

    /// <summary>
    /// Loads the game content, including the sprite batch and textures.
    /// </summary>
    public override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        _texture = Content.Load<Texture2D>("monogame-logo");
    }

    /// <summary>
    /// Handles mouse button release events, toggling the rotation direction.
    /// </summary>
    /// <param name="mouseState">The current mouse state.</param>
    public override void OnMouseUp(MouseStateArgs mouseState)
    {
        _rotationSign *= -1;
    }

    /// <summary>
    /// Updates the game state, calculating position and rotation based on time.
    /// </summary>
    /// <param name="gameTime">The time elapsed since the last update.</param>
    public override void Update(GameTime gameTime)
    {
        _position = GraphicsDevice.Viewport.Bounds.Center.ToVector2();
        _rotation = (float)Math.Sin(_rotationSign * gameTime.TotalGameTime.TotalSeconds) / 4f;
        _origin = _texture.Bounds.Center.ToVector2();
        _scale = Vector2.One;
    }

    /// <summary>
    /// Draws the game graphics to the screen.
    /// </summary>
    /// <param name="gameTime">The time elapsed since the last draw.</param>
    public override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        _spriteBatch.Begin();
        _spriteBatch.Draw(_texture, _position, null, Color.White, _rotation, _origin, _scale, SpriteEffects.None, 0f);
        _spriteBatch.End();
    }
}

