using System;
using System.Collections.Generic;
using System.IO;
using Avro;
using Avro.File;
using Avro.Generic;

namespace HarvestHollow.Utilities;

/// <summary>
/// Handles reading and writing Avro data to and from files.
/// </summary>
public static class ProcessAvroData
{
    /// <summary>
    /// Reads data from an Avro file and returns a list of structs populated with the Avro data.
    /// </summary>
    /// <typeparam name="TStruct">The type of the struct that corresponds to the Avro schema.</typeparam>
    /// <param name="avroFilePath">The path to the Avro file.</param>
    /// <param name="schemaFilePath">The path to the Avro schema (.avsc) file.</param>
    /// <returns>A list of structs populated with the Avro data.</returns>
    /// <exception cref="FileNotFoundException">Thrown when the Avro file or schema file is not found.</exception>
    public static List<TStruct> s_ReadAvroData<TStruct>(string avroFilePath, string schemaFilePath) where TStruct : class, new()
    {
        // Load the Avro schema
        var schema = Schema.Parse(File.ReadAllText(schemaFilePath));

        var records = new List<TStruct>();

        // Read the Avro file
        using (var reader = DataFileReader<TStruct>.OpenReader(avroFilePath))
        {
            while (reader.HasNext())
            {
                // Read the next record
                TStruct record = reader.Next();
                records.Add(record);
            }
        }

        return records;
    }
    /// <summary>
    /// Writes a list of structs to an Avro file based on the specified schema.
    /// </summary>
    /// <typeparam name="TStruct">The type of the struct that corresponds to the Avro schema.</typeparam>
    /// <param name="avroOutFilePath">The output path for the Avro file.</param>
    /// <param name="schemaFilePath">The path to the Avro schema (.avsc) file.</param>
    /// <param name="data">A list of structs to be written to the Avro file.</param>
    /// <exception cref="FileNotFoundException">Thrown when the schema file is not found.</exception>
    public static void s_WriteAvroData<TStruct>(string avroOutFilePath, string schemaFilePath, List<TStruct> data) where TStruct : class
    {
        // Load the Avro schema
        var schema = Schema.Parse(File.ReadAllText(schemaFilePath));

        using (var writer = DataFileWriter<TStruct>.OpenWriter(new GenericDatumWriter<TStruct>(schema), avroOutFilePath))
        {
            // Write each record to the Avro file
            foreach (var record in data)
            {
                writer.Append(record);
            }
        }
    }
}