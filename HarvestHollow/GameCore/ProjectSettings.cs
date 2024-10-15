namespace HarvestHollow.GameCore;

/// <summary>
/// A record containing project settings for Harvest Hollow.
/// </summary>
public record ProjectSettings
{
    /// <summary>The name of the game in the title bar.</summary>
    public static readonly string Name = "Harvest Hollow";
    /// <summary>The current version of the application.</summary>
    public static readonly string Version = "0.0.0";
    /// <summary>Description used for Steam page and other hosting platforms.</summary>
    public static readonly string Description = "A 2D JRPG styled game.";
    /// <summary>Information about the author of Harvest Hollow.</summary>
    public static readonly string Author = "Foster Cavender (Xeplosion) <xeplosion@xegames.online>";
    /// <summary>The software license of Harvest Hollow.</summary>
    public static readonly string License = "GNU";
    /// <summary>Enables editor settings.</summary>
    public static readonly bool Developer = true;
    /// <summary>Enables a more detailed output for debugging Harvest Hollow.</summary>
    public static readonly bool DetailedOutput = false;
    /// <summary>Whether or not the project should except custom launch commands at build time.</summary>
    public static readonly bool CustomLaunchCommands = false;
}