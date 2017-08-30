using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;

namespace Microsoft.AspNetCore.JsonPatch.Converters
{
    class JsonMergeDocumentConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return true;
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue,
            JsonSerializer serializer)
        {
            if (objectType != typeof(JsonMergeDocument))
            {
                throw new ArgumentException(Resources.FormatParameterMustMatchType("objectType", "JsonMergeDocument"), "objectType");
            }

            try
            {
                if (reader.TokenType == JsonToken.Null)
                {
                    return null;
                }

                // load jObject
                var jObject = JObject.Load(reader);

                // Populate the object properties
                // container target: the JsonPatchDocument. 
                var container = new JsonMergeDocument(jObject);

                return container;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value is IJsonMergeDocument)
            {
                var jsonMergeDocument = (IJsonMergeDocument)value;
                var mergeDocument = jsonMergeDocument.GetMergeDocument();

                // write out the operations, no envelope
                serializer.Serialize(writer, mergeDocument);
            }
        }
    }
}
