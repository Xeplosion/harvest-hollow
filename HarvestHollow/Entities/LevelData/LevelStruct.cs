using System.Collections.Generic;

namespace HarvestHollow.Entities.LevelData;

/// <summary>Background image values for current level.</summary>
public struct BackgroundImage
{
    /// <summary>Values to crop the background image. [cropX, cropY, cropWidth, cropHeight]</summary>
    public IEnumerable<int> CropRect { get; set; }
    /// <summary>Scale values of cropped background image. [scaleX, scaleY]</summary>
    public IEnumerable<float> Scale { get; set; }
    /// <summary>Pixel position of top left corner of background image relative to the level origin. [x, y]</summary>
    public IEnumerable<int> TopLeft { get; set; }
}
/// <summary>Data for an entity instance.</summary>
public struct EntityInstance
{
    /// <summary>User created unique Identifier for the entity.</summary>
    public string Identifier { get; set; }
    /// <summary>Unique instance Identifier for the entity.</summary>
    public string IID { get; set; }
    /// <summary>Reference to the entity definition.</summary>
    public int DefUID { get; set; }
    /// <summary>World X coordinate of the entity in pixels.</summary>
    public int WorldX { get; set; }
    /// <summary>World Y coordinate of the entity in pixels.</summary>
    public int WorldY { get; set; }
    /// <summary>Position of the entity in the layer. [x, y]</summary>
    public IEnumerable<int> PxPos { get; set; }
    /// <summary>Array of floats from 0-1 for entities Pivot. [pivotX, pivotY]</summary>
    public IEnumerable<float> Pivot { get; set; }
}
/// <summary>IntGrid data values for this layer.</summary>
public struct IntGridData
{
    /// <summary>User created unique Identifier for the int grid layer.</summary>
    public string Identifier { get; set; }
    /// <summary>Reference to an integer grid layer definition.</summary>
    public int DefUID { get; set; }
    /// <summary>Value of the int grid cell.</summary>
    public int V { get; set; }
    /// <summary>Position of the grid cell in the layer. [x, y]</summary>
    public IEnumerable<int> Px { get; set; }
}
/// <summary>Defines A level later instance.</summary>
public struct LayerInstance
{
    /// <summary>World Z depth / draw order value of the layer.</summary>
    public int ZIndex { get; set; }
    /// <summary>Layer Type.</summary>
    public string Type { get; set; }
    /// <summary>Reference to the auto layer definition.</summary>
    public int? AutoLayerDefUID { get; set; }
    /// <summary>Reference to the int grid layer definition.</summary>
    public int? IntGridLayerDefUID { get; set; }
    /// <summary>Reference to the tileset layer definition.</summary>
    public int? TilesetLayerDefUID { get; set; }
    /// <summary>Unique instance Identifier for the layer.</summary>
    public string IID { get; set; }
    /// <summary>X offset of the layer in pixels.</summary>
    public int PxOffsetX { get; set; }
    /// <summary>Y offset of the layer in pixels.</summary>
    public int PxOffsetY { get; set; }
    /// <summary>Opacity of the layer.</summary>
    public float Opacity { get; set; }
    /// <summary>Whether or not the level is Visible in the editor.</summary>
    public bool Visible { get; set; }
    /// <summary>Reference to the tileset UID used by this layer.</summary>
    public int TilesetUID { get; set; }
    /// <summary>Width of tiles in the layer.</summary>
    public int TileSizeX { get; set; }
    /// <summary>Height of tiles in the layer.</summary>
    public int TileSizeY { get; set; }
    /// <summary>Grid based width of the layer.</summary>
    public int GridWidth { get; set; }
    /// <summary>Grid based height of the layer.</summary>
    public int GridHeight { get; set; }
    /// <summary>IntGrid layer data for current level.</summary>
    public global::System.Collections.Generic.IEnumerable<IntGridData>? IntGridData { get; set; }
    /// <summary>Tile layer data for current level.</summary>
    public global::System.Collections.Generic.IEnumerable<TileData>? TileData { get; set; }
}
/// <summary>Defines A level in Harvest Hollow.</summary>
public struct LevelStruct
{
    /// <summary>User created unique Identifier for the level.</summary>
    public string Identifier { get; set; }
    /// <summary>Unique instance Identifier for the level.</summary>
    public string IID { get; set; }
    /// <summary>Reference to world IID containing this level.</summary>
    public string WorldIID { get; set; }
    /// <summary>An array listing all levels touching this one.</summary>
    public global::System.Collections.Generic.IEnumerable<string>? Neighbors { get; set; }
    /// <summary>Background color of the level in hex format.</summary>
    public string BgColor { get; set; }
    /// <summary>Reference to the levels background image.</summary>
    public string? BgImage { get; set; }
    /// <summary>Render settings for the level's background image.</summary>
    public global::HarvestHollow.Entities.LevelData.BackgroundImage? BgPos { get; set; }
    /// <summary>Depth of the level in the world.</summary>
    public int WorldDepth { get; set; }
    /// <summary>World X coordinate in pixels.</summary>
    public int WorldX { get; set; }
    /// <summary>World Y coordinate in pixels.</summary>
    public int WorldY { get; set; }
    /// <summary>Width of the level in pixels.</summary>
    public int LevelWidth { get; set; }
    /// <summary>Height of the level in pixels.</summary>
    public int LevelHeight { get; set; }
    /// <summary>Data for each layer in the level.</summary>
    public IEnumerable<LayerInstance> LayerInstances { get; set; }
    /// <summary>Entity data for the current level</summary>
    public global::System.Collections.Generic.IEnumerable<EntityInstance>? EntityInstances { get; set; }
    /// <summary>Enum values for the current layer.</summary>
    public global::System.Collections.Generic.IEnumerable<EnumValue>? enumValues { get; set; }
}
/// <summary>Tile data for current layer.</summary>
public struct TileData
{
    /// <summary>Opacity of the tile.</summary>
    public float A { get; set; }
    /// <summary>Flip flag. F=0 (no flip), F=1 (x flip only), F=2(Y flip only), F=3 (both flips)</summary>
    public int F { get; set; }
    /// <summary>Position of the tile in the layer. [x, y]</summary>
    public IEnumerable<int> PxPos { get; set; }
    /// <summary>Position of tile in the source tileset. [x, y]</summary>
    public string Src { get; set; }
    /// <summary>Tile ID in tileset. (y * GridWidth + x)</summary>
    public int T { get; set; }
}
