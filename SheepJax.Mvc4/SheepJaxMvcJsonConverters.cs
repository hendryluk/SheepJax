using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace SheepJax.Mvc4
{
    public static class SheepJaxMvcJsonConverters
    {
        public static IList<Func<ControllerContext, JsonConverter>> DefaultMvcJsonConverterFactories { get; set; }

        static SheepJaxMvcJsonConverters()
        {
            DefaultMvcJsonConverterFactories = new List<Func<ControllerContext, JsonConverter>>
            {
                _ => new ViewResultWrapperConverter(),
                context => new ViewResultConverter(context)
            };
        }
    }
}
