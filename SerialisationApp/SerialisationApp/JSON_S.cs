using Newtonsoft.Json;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace SerialisationApp
{
    class JSON_S
    {
        static readonly string _path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        static void Main(string[] args)
        {
            //create a trainee
            Trainee tl = new Trainee { FirstName = "Cathy", LastName = "French", SpartaNo = 100 };
            SerializeToFileJSON(tl);
            Trainee t2 = DeserializeFromFileJSON("SerialisationApp.Trainee.json");
        }

        private static Trainee DeserializeFromFileJSON(string fileName)
        {
            // create the file path
            var filePath = $"{_path}/{fileName}";
            // create a Stream object for reading
            Stream file = File.OpenRead(filePath);
            // create the BinaryFormatter and use it
            BinaryFormatter reader = new BinaryFormatter();
            var trainee = (Trainee)reader.Deserialize(file);
            file.Close();
            return trainee;
        }

        private static void SerializeToFileJSON(Object o)
        {
            // create the file path
            var filePath = $"{_path}/{o}.json";
            string jsonString = JsonConvert.SerializeObject(o);
            File.WriteAllText(filePath, jsonString);
        }
    }
}
