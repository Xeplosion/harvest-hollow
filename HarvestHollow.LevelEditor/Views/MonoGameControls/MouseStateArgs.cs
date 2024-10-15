using System.Windows;
using System.Windows.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace HarvestHollow.LevelEditor.Views.MonoGameControls;

public class MouseStateArgs
{
    private readonly IInputElement _element;
    private readonly MouseEventArgs _args;

    public MouseStateArgs(IInputElement element, MouseEventArgs args)
    {
        _element = element;
        _args = args;
    }

    public Vector2 Position => _args.GetPosition(_element).s_ToVector2();
    public ButtonState LeftButton => s_convertButtonState(_args.LeftButton);
    public ButtonState RightButton => s_convertButtonState(_args.RightButton);
    public ButtonState MiddleButton => s_convertButtonState(_args.MiddleButton);

    private static ButtonState s_convertButtonState(MouseButtonState state) => state == MouseButtonState.Pressed ? ButtonState.Pressed : ButtonState.Released;
}