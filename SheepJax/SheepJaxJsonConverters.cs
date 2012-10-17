using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SheepJax
{
    public static class SheepJaxJsonConverters
    {
        static SheepJaxJsonConverters()
        {
            Defaults = new List<JsonConverter>
            {
                new JavaScriptDateTimeConverter()
            };
        }
        public static IList<JsonConverter> Defaults { get; set; }
    }
}