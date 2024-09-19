namespace HarvestHollow.Tiles.Structures.Definitions
{
    internal struct EntityDefStruct
    {
        public string Identifier { get; set; }
        public int Uid { get; set; }
        public string Color { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public float PivotX { get; set; }
        public float PivotY { get; set; }
        public TilesetRectDefStruct TileRect { get; set; }
        public EnumDefStruct TileRenderMode { get; set; }
        public int TilesetId { get; set; }
    }
}
