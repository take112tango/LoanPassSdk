using System;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Take112Tango.Libs.LoanPassSdk.Utils
{
    public static class JsonUtil
    {
        private static readonly JsonSerializerSettings DefaultSettings;

        static JsonUtil()
        {
            var contractResolver = new DefaultContractResolver
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            };

            DefaultSettings = new JsonSerializerSettings
            {
                ContractResolver = contractResolver,
                Formatting = Formatting.Indented,
                DateTimeZoneHandling = DateTimeZoneHandling.Utc
            };
        }

        public static string ToJson(this object obj, JsonSerializerSettings settings = null)
        {
            if (obj == null)
                return null;

            settings ??= DefaultSettings;

            string stJson = null;
            try
            {
                stJson = JsonConvert.SerializeObject(obj, settings);
            }
            catch (Exception)
            {
                throw;
            }
            return stJson;
        }

        public static void ToJsonStream(this object obj, Stream s, JsonSerializerSettings settings = null)
        {
            settings ??= DefaultSettings;

            using var writer = new StreamWriter(s, new UTF8Encoding(false), 1024, true);
            using var jsonWriter = new JsonTextWriter(writer);
            JsonSerializer ser = JsonSerializer.Create(settings);
            ser.Serialize(jsonWriter, obj);
            jsonWriter.Flush();
        }

        //public static T CloneJson<T>(this object obj)
        //{
        //    T cloned = default(T);
        //    if (obj == null)
        //        return cloned;

        //    try
        //    {
        //        using var ms = new MemoryStream();
        //        obj.ToJsonStream(ms);
        //        ms.Seek(0, SeekOrigin.Begin);
        //        cloned = ms.FromJson<T>();

        //        //string stJson = JsonConvert.SerializeObject(obj);
        //        //cloned = JsonConvert.DeserializeObject<T>(stJson);
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //    return cloned;
        //}

        public static T FromJson<T>(this string stJson, JsonSerializerSettings settings = null)
        {
            T cloned = default;
            if (string.IsNullOrEmpty(stJson))
                return cloned;

            settings ??= DefaultSettings;
            try
            {
                cloned = JsonConvert.DeserializeObject<T>(stJson, settings);
            }
            catch (Exception)
            {
                throw;
            }
            return cloned;
        }

        public static T FromJsonFile<T>(string filename, JsonSerializerSettings settings = null)
        {
            using var stream = File.OpenRead(filename);
            return stream.FromJson<T>(settings);
        }

        public static T FromJson<T>(this Stream s, JsonSerializerSettings settings = null)
        {
            settings ??= DefaultSettings;

            using var reader = new StreamReader(s);
            using var jsonReader = new JsonTextReader(reader);
            JsonSerializer ser = JsonSerializer.Create(settings);
            return ser.Deserialize<T>(jsonReader);
        }

    }
}
