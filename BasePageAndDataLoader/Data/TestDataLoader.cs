using System.IO;
using Newtonsoft.Json;

namespace SolarTechnology.Data
{

    public static class TestDataLoader
    {
        /// <summary>
        /// Loads test data from a JSON file.
        /// </summary>
        /// <typeparam name="T">The type of object to deserialize the data into.</typeparam>
        /// <param name="filePath">The relative or absolute path to the JSON file.</param>
        /// <returns>The deserialized object of type T.</returns>
        public static ManufacturerData LoadJson(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException($"The file '{filePath}' was not found.");
            }

            string jsonData = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<ManufacturerData>(jsonData);
        }
                
        public static void SaveJson<T>(string filePath, T objectToSave)
        {
            File.WriteAllText(filePath, JsonConvert.SerializeObject(objectToSave));
        }

        /// <summary>
        /// Loads test data from a CSV file.
        /// </summary>
        /// <param name="filePath">The relative or absolute path to the CSV file.</param>
        /// <returns>A list of string arrays representing the rows in the CSV file.</returns>
        public static List<string[]> LoadCsv(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException($"The file '{filePath}' was not found.");
            }

            var lines = File.ReadAllLines(filePath);
            return lines.Select(line => line.Split(',')).ToList();
        }

        /// <summary>
        /// Loads test data from a plain text file.
        /// </summary>
        /// <param name="filePath">The relative or absolute path to the text file.</param>
        /// <returns>A string representing the content of the text file.</returns>
        public static string LoadText(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException($"The file '{filePath}' was not found.");
            }

            return File.ReadAllText(filePath);
        }
    }

}
