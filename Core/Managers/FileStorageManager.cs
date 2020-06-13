using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Telegram_bot_starter.Core.Managers
{
    //Store data in files
    public class FileStorageManager<T>
    {
        string FilePath { get; set; }
        public List<T> Entities = new List<T>();

        public FileStorageManager(string filepath)
        {
            FilePath = filepath;
            Entities = LoadFromFile();
        }
        public List<T> Set()
        {
            return Entities;
        }
        public void Add(T entity)
        {
            Entities.Add(entity);
        }
        public void SaveToFileAsync()
        {
            //Save to file
            string jsonFile = JsonConvert.SerializeObject(Entities);

            System.IO.File.WriteAllText(FilePath, jsonFile);
        }
       
        public List<T> LoadFromFile()
        {
            try
            {
                string dataString = System.IO.File.ReadAllText(FilePath);
                return JsonConvert.DeserializeObject<List<T>>(dataString);
            }
            catch (Exception ex)
            {
                if (ex is FileNotFoundException)
                    Console.WriteLine($"File {FilePath} not found");
                else
                    Console.WriteLine(ex.ToString());
            }
            return new List<T>();
        }
    }
}
