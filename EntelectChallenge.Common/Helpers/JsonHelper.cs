using System.IO;
using Newtonsoft.Json;

namespace EntelectChallenge.Common.Helpers
{
    public static class JsonHelper
    {
        public static T LoadOrCreateFile<T>(string fullFilePath) where T : new()
        {
            T obj;

            if (!File.Exists(fullFilePath))
            {
                obj = new T();
                var json = JsonConvert.SerializeObject(obj);

                File.WriteAllText(fullFilePath, json);

                return obj;
            }

            return LoadFile<T>(fullFilePath);
        }

        public static T LoadFile<T>(string fullFilePath)
        {
            var json = File.ReadAllText(fullFilePath);

            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}
