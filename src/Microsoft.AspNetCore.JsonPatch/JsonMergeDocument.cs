using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.JsonPatch.Adapters;
using Microsoft.AspNetCore.JsonPatch.Converters;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;

namespace Microsoft.AspNetCore.JsonPatch
{
    [JsonConverter(typeof(JsonMergeDocumentConverter))]
    public class JsonMergeDocument : IJsonMergeDocument
    {
        public JsonMergeDocument(JObject mergeDocument)
        {
            MergeDocument = mergeDocument;
        }

        public JObject MergeDocument { get; set; }
        public IContractResolver ContractResolver { get; set; }

        public JObject GetMergeDocument()
        {
            return MergeDocument;
        }

        public object MergePatch(object objectToApplyTo, Action<JsonPatchError> logErrorAction)
        {
            var jObjectToApplyTo = JObject.FromObject(objectToApplyTo); // object to apply to.
            var jobj2 = JObject.FromObject(MergeDocument);
            jObjectToApplyTo.Merge(jobj2, new JsonMergeSettings { MergeArrayHandling = MergeArrayHandling.Replace, MergeNullValueHandling = MergeNullValueHandling.Merge });
            return jObjectToApplyTo.ToObject<object>();
        }
    }
}
