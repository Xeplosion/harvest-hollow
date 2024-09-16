using System;
using System.IO;
using System.Text.Json;
using Microsoft.Xna.Framework;

namespace HarvestHollow
{
    public static class ProjectSettings
    {
        // Access project data.
        private static readonly string _jsonText = File.ReadAllText("./Zambrin.json");
        private static readonly JsonStructure _jsonData = JsonConvert.DeserializeObject<JsonStructure>(_jsonText);

        public static readonly string NAME;
        public static readonly string VERSION;
        public static readonly string DESCRIPTION;
        public static readonly bool DEVELOPER;
        public static readonly bool DETAILED_OUTPUT;
        public static readonly bool LOAD_LEVEL_EDITOR;
        public static readonly bool CUSTOM_LAUNCH_COMMANDS;
        public static readonly string AUTHOR;
        public static readonly string LICENSE;

#pragma warning disable S3963 // "static" fields should be initialized inline
        static ProjectSettings()
        {
            // Change the project settings
            NAME = _jsonData.Name;
            VERSION = _jsonData.Version;
            DESCRIPTION = _jsonData.Description;

            DEVELOPER = _jsonData.Settings.Developer;
            DETAILED_OUTPUT = _jsonData.Settings.DetailedOutput;
            LOAD_LEVEL_EDITOR = _jsonData.Settings.LoadLevelEditor;
            CUSTOM_LAUNCH_COMMANDS = _jsonData.Settings.CustomLaunchCommands;

            AUTHOR = _jsonData.Author;
            LICENSE = _jsonData.License;
        }
    }

    // Structs for JSON data
    internal struct JsonStructure
    {
        internal string Name { get; set; }
        internal string Version { get; set; }
        internal string Description { get; set; }
        internal SettingStructure Settings { get; set; }
        internal string Author { get; set; }
        internal string License { get; set; }
    }
    internal struct SettingStructure
    {
        internal bool Developer { get; set; }
        internal bool DetailedOutput { get; set; }
        internal bool LoadLevelEditor { get; set; }
        internal bool CustomLaunchCommands { get; set; }
    }
}

