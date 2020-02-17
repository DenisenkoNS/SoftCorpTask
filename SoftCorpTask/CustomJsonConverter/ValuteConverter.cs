using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SoftCorpTask.Models;
using System;
using System.Collections.Generic;

namespace SoftCorpTask.Data
{
    public class ValutesConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteStartArray();
            foreach (var valute in (List<Valute>)value)
            {
                writer.WriteRawValue(JsonConvert.SerializeObject(valute));
            }
            writer.WriteEndArray();
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var response = new List<Valute>();
            JObject valutes = JObject.Load(reader);
            foreach (var valute in valutes)
            {
                var p = JsonConvert.DeserializeObject<Valute>(valute.Value.ToString());
                p.ID = valute.Key;
                response.Add(p);
            }
            return response;
        }
        public override bool CanConvert(Type objectType) => objectType == typeof(List<Valute>);
    }
}
