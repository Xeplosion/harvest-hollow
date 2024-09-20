using System;
using System.IO;
using System.Text.Json;
using Newtonsoft.Json.Schema;

namespace HarvestHollow.Tiles
{
    internal class JsonConverter
    {
        // Handles naming conventions for JSON serialization.
        private readonly JsonSerializerOptions _serializeOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            PropertyNameCaseInsensitive = false,
            WriteIndented = true
        };

        // Serialize an object to a JSON string.
        public void SerializeJson(string filePath, object obj)
        {
            string jsonString = JsonSerializer.Serialize(obj, _serializeOptions);
            File.WriteAllText(filePath, jsonString);

        }

        // Deserialize a JSON string to an object.
        public TJsonData DeserializeJson<TJsonData>(string filePath)
        {
            string jsonString = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<TJsonData>(jsonString, _serializeOptions);
        }
    }
}
