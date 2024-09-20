using System.Text.Json.Serialization;
using MonoGame.Extended.Content.ContentReaders;

namespace HarvestHollow
{
    internal static class ProjectSettings
    {
        public static string Name;
        public static string Version;
        public static string Description;
        public static string Author;
        public static string License;
        public static bool Developer;
        public static bool DetailedOutput;
        public static bool LoadLevelEditor;
        public static bool CustomLaunchCommands;
        public static void CreateSettings(ProjectSettingsStruct settings)
        {
            // Set the project settings.
            Name = settings.Name;
            Version = settings.Version;
            Description = settings.Description;
            Author = settings.Author;
            License = settings.License;
            Developer = settings.Settings.Developer;
            DetailedOutput = settings.Settings.DetailedOutput;
            LoadLevelEditor = settings.Settings.LoadLevelEditor;
            CustomLaunchCommands = settings.Settings.CustomLaunchCommands;
        }
    }
    internal struct ProjectSettingsStruct
    {
        [JsonPropertyName("name")]
        internal string Name { get; set; }
        [JsonPropertyName("version")]
        internal string Version { get; set; }
        [JsonPropertyName("description")]
        internal string Description { get; set; }
        [JsonPropertyName("settings")]
        internal SettingStructure Settings { get; set; }
        [JsonPropertyName("author")]
        internal string Author { get; set; }
        [JsonPropertyName("license")]
        internal string License { get; set; }
    }
    internal struct SettingStructure
    {
        [JsonPropertyName("developer")]
        internal bool Developer { get; set; }
        [JsonPropertyName("detailedOutput")]
        internal bool DetailedOutput { get; set; }
        [JsonPropertyName("loadLevelEditor")]
        internal bool LoadLevelEditor { get; set; }
        [JsonPropertyName("customLaunchCommands")]
        internal bool CustomLaunchCommands { get; set; }
    }
    internal class ProjectSettingsReader : JsonContentTypeReader<ProjectSettingsStruct> { }
}
