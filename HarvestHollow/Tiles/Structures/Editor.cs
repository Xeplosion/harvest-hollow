// Ignore Spelling: LevelID UID
using System.Collections.Generic;

namespace HarvestHollow.Tiles.Structures
{
    internal interface IEditor
    {
        public string Documentation { get; set; }
        public string UIColor { get; set; }
        public string[] UIFilterTags { get; set; }
        public double InactiveOpacity { get; set; }
        public bool HideInEditorList { get; set; }
        public bool HideFieldsWhenInactive { get; set; }
        public bool CanSelectWhenInactive { get; set; }
        public bool RenderInWorldView { get; set; }
        public string[] RequiredTags { get; set; }
        public string[] ExcludedTags { get; set; }
        public int DefaultTilesetUID { get; set; }
    }
    internal interface IIdentifier
    {
        public string IID { get; set; }
        public string UID { get; set; }

    }
    internal interface IDefinition
    {
        public string Type { get; set; }
        public int GridSize { get; set; }
        public int GuideGridWidth { get; set; }
        public int GuideGridHeight { get; set; }
        public float DisplayOpacity { get; set; }
        public int OffsetX { get; set; }
        public int OffsetY { get; set; }
        public int ParallaxX { get; set; }
        public int ParallaxY { get; set; }
        public bool ParallaxScaling { get; set; }
        public int[] AutoLayerKilled { get; set; }
        public bool AsyncRender { get; set; }
        public List<IntGridStructure> IntGridValues { get; set; }
        public List<IntGridGroupStructure> IntGridValuesGroup { get; set; }
        public List<AutoLayerRuleStructure> AutoRuleGroups { get; set; }
        public double TilePivotX { get; set; }
        public double TilePivotY { get; set; }
    }
}
