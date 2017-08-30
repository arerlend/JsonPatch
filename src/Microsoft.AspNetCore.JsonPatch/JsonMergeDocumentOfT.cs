using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;

namespace Microsoft.AspNetCore.JsonPatch
{
    public class JsonMergeDocuument<TModel> : IJsonMergeDocument where TModel : class
    {
        public IContractResolver ContractResolver { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public JObject GetMergeDocument()
        {
            throw new NotImplementedException();
        }
    }
}
