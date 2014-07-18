using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using Newtonsoft.Json;

namespace PIT.API
{
    public static class JsonConverter<T> where T : class
    {
        public static IEnumerable<T> CreateList(HttpResponseMessage responseMessage)
        {
            Type type = typeof(List<T>);
            using (var memoryStream = new MemoryStream())
            {
                responseMessage.Content.CopyToAsync(memoryStream).Wait();
                memoryStream.Seek(0L, SeekOrigin.Begin);
                using (var streamReader = new StreamReader(memoryStream))
                {
                    var list = JsonConvert.DeserializeObject(streamReader.ReadToEnd(), type) as IEnumerable<T>;
                    if (list == null)
                        throw new NullReferenceException("items");
                    return list;
                }
            }
        }

        public static HttpContent Create(T model)
        {
            return new JsonContent(JsonConvert.SerializeObject((object)model));
        }

        public static T Create(HttpResponseMessage responseMessage)
        {
            Type type = typeof(T);
            using (var memoryStream = new MemoryStream())
            {
                responseMessage.Content.CopyToAsync(memoryStream).Wait();
                memoryStream.Seek(0L, SeekOrigin.Begin);
                using (var streamReader = new StreamReader(memoryStream))
                {
                    return JsonConvert.DeserializeObject(streamReader.ReadToEnd(), type) as T;
                }
            }
        }
    }
}