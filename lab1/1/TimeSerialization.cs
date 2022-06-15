using System;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using static Newtonsoft.Json.JsonConvert;

namespace Lab1
{
    class TimeSerialization
    {
        public static void Serialize(Time time)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\nУспiшно створено .json файл.");
            Console.ResetColor();
            string objectToSerialize = System.Text.Json.JsonSerializer.Serialize(time);
            File.WriteAllText("file.json", objectToSerialize);
        }
        public static Time Deserialize(string path)
        {
            string json = File.ReadAllText(path);
            Time JsonDeserialize = JsonConvert.DeserializeObject<Time>(json);
            return JsonDeserialize;
        }
    }
}
