using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;

namespace Microsoft.AspNetCore.JsonPatch
{
    interface IJsonMergeDocument
    {
        IContractResolver ContractResolver { get; set; }

        JObject GetMergeDocument();
    }
}
