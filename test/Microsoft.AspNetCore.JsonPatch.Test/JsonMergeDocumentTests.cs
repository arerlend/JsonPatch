using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json.Linq;
using Xunit;

namespace Microsoft.AspNetCore.JsonPatch.Test
{
    public class JsonMergeDocumentTests
    {
        [Fact]
        public void JsonMergeDocument_BasicBehaviorTest()
        {
            var jsonObject = JObject.Parse("{\"foo\": \"bar\"}").ToObject<object>();
            var mergeDocument = JObject.Parse("{\"foo\": \"baz\"}");
            var mergeDoc = new JsonMergeDocument(mergeDocument);
            var res = mergeDoc.MergePatch(jsonObject, null);
            Assert.Equal(JObject.FromObject(res), mergeDocument);
        }
    }
}
