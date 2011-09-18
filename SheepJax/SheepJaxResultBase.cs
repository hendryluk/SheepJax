using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace SheepJax
{
    public abstract class SheepJaxResultBase: ActionResult
    {
        private readonly JsonConverter[] _jsonConverters;
        protected SheepJaxResultBase(params JsonConverter[] jsonConverters)
        {
            _jsonConverters = jsonConverters;
        }

        protected JsonSerializerSettings CreateSerializerSettings(ControllerContext context)
        {
            return new JsonSerializerSettings {Converters = 
                                                   _jsonConverters
                                                   .Union(SheepJaxed.DefaultJsonConverterFactories.Select(f => f(context))).ToList()};
        }

        protected void WriteInvocations(HttpResponseBase response, IEnumerable<SheepJaxInvoke> invocations, JsonSerializerSettings settings)
        {
            response.Write(JsonConvert.SerializeObject(invocations, Formatting.None, settings));
        }
    }
}