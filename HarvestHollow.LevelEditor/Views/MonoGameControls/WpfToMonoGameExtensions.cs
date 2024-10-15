using Microsoft.Xna.Framework;

namespace HarvestHollow.LevelEditor.Views.MonoGameControls;

public static class WpfToMonoGameExtensions
{
    public static Vector2 s_ToVector2(this System.Windows.Point point) => new Vector2((float)point.X, (float)point.Y);
}