using System.Collections.Generic;

// These structures and classes are used both by the game and level editor.

namespace HarvestHollow.Content.World
{
    // A world is a collection of levels.
    internal class World
    {
    }

    // JSON structure of a world.
    internal struct WorldStructure : IIdentifier
    {
        // World identification.
        public string IID { get; set; }
        public string UID { get; set; }
        public string Documentation { get; set; }

        // World values.
        public List<TableOfContentsStructure> TableOfContents { get; set; }
        public int WorldGridSize { get; set; }
        public int WorldGridWidth { get; set; }
        public int WorldGridHeight { get; set; }
        public int DefaultWorldWidth { get; set; }
        public int DefaultWorldHeight { get; set; }
        public double DefaultPivotX { get; set; }
        public double DefaultPivotY { get; set; }
        public int DefaultEntityWidth { get; set; }
        public int DefaultEntityHeight { get; set; }
        public List<IDefinitionsStructure> IDefinitions { get; set; }
        public List<LevelReferencesStructure> LevelReferences { get; set; }
    }

    // Quick access to entities. (player, doors, etc.)
    internal struct TableOfContentsStructure
    {
        // TODO: add necessary structure.
    }

    // Contains all level component definitions.
    internal struct IDefinitionsStructure
    {
        public List<IDefinition> Layers { get; set; }
        public List<EntityStructure> Entities { get; set; }
        public List<TileLayerStructure> Tilesets { get; set; }
        public List<IDefinition> Enumerations { get; set; }
    }

    // Different types of definition structures.
    internal struct AutoLayerStructure : IEditor, IIdentifier, IDefinition
    {
        // IDefinition identification.
        public string IID { get; set; }
        public string UID { get; set; }

        // Editor settings.
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

        // IDefinition properties.
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
    internal struct AutoLayerRuleStructure
    {
        // TODO: add the necessary structure data.
    }
    internal struct IntGridStructure : IEditor, IIdentifier, IDefinition
    {
        // IDefinition identification.
        public string IID { get; set; }
        public string UID { get; set; }

        // Editor settings.
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

        // IDefinition properties.
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
    internal struct IntGridGroupStructure
    {
        // TODO: add the necessary structure data.
    }
    internal struct EntityStructure : IEditor, IIdentifier, IDefinition
    {
        // IDefinition identification.
        public string IID { get; set; }
        public string UID { get; set; }

        // Editor settings.
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

        // IDefinition properties.
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
    internal struct TileLayerStructure : IEditor, IIdentifier, IDefinition
    {
        // IDefinition identification.
        public string IID { get; set; }
        public string UID { get; set; }

        // Editor settings.
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

        // IDefinition properties.
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
    internal struct Enumeration : IIdentifier, IEditor
    {
        // IDefinition identification.
        public string IID { get; set; }
        public string UID { get; set; }

        // Editor settings.
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

        // Actual enum values.
        public string[] EnumValues { get; set; }
    }

    // Actual level data is stored and processed in separate files.
    // This is just a reference to those files via their IIDs.
    internal struct LevelReferencesStructure
    {
        public string[] IID { get; set; }
        public string[] UID { get; set; }
    }
}
