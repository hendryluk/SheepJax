using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace SheepJax
{
    public class SheepJaxResult<T> : SheepJaxResultBase
    {
        private readonly SheepJaxCommands _commands;
        private readonly JsonConverter _jsonConverters;

        public SheepJaxResult(SheepJaxCommands commands, JsonConverter jsonConverters)
        {
            _commands = commands;
            _jsonConverters = jsonConverters;
        }

        protected JsonSerializerSettings CreateSerializerSettings(ControllerContext context)
        {
            return new JsonSerializerSettings
            {
                Converters =
                    _jsonConverters
                    .Union(SheepJaxed.DefaultJsonConverterFactories.Select(f => f(context))).ToList()
            };
        }

        public override void ExecuteResult(ControllerContext context)
        {
            var settings = CreateSerializerSettings(context);
            var response = context.HttpContext.Response;
            response.ContentType = "application/json";

            response.Write(_commands.GetJson(settings));
        }
    }
}