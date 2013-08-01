using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SheepJax
{
    public class SheepJaxed
    {
        public static IList<Func<ControllerContext, JsonConverter>> DefaultJsonConverterFactories { get; set; }
        
        static SheepJaxed()
        {
            var dateTimeConverter = new JavaScriptDateTimeConverter();
            DefaultJsonConverterFactories = new List<Func<ControllerContext, JsonConverter>>
                                                {
                                                    _ => dateTimeConverter, 
                                                    _ => new ViewResultWrapperConverter(),
                                                    context => new ViewResultConverter(context)
                                                };

        }

        public static SheepJaxResult<T> On<T>(Action<T> command = null, params JsonConverter[] jsonConverters)
        {
            return new SheepJaxResult<T>(command, jsonConverters);
        }

        public static SheepJaxResult<dynamic> Dynamic(Action<dynamic> command = null, params JsonConverter[] jsonConverters)
        {
            return On(command, jsonConverters);
        }

        public static SheepJaxResult<IDefaultCommands> Default(Action<IDefaultCommands> command = null, params JsonConverter[] jsonConverters)
        {
            return On(command, jsonConverters);
        }
    }
}