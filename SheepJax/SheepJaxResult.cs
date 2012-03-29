using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace SheepJax
{
    public class SheepJaxResult<T> : SheepJaxResultBase
    {
        private readonly IList<SheepJaxInvoke> _invokes = new List<SheepJaxInvoke>();
        
        public T Command { get; private set; }
        
        public IEnumerable<SheepJaxInvoke> Invocations
        {
            get { return _invokes; }
        }

        public SheepJaxResult(params JsonConverter[] jsonConverters)
            : base(jsonConverters)
        {
            Command = SheepJaxProxyGenerator.Instance.Create<T>(invoke => _invokes.Add(invoke));
        }

        public SheepJaxResult(Action<T> command, params JsonConverter[] jsonConverters)
            : this(jsonConverters)
        {
            if(command != null)
                command(Command);
        }

        public override void ExecuteResult(ControllerContext context)
        {
            var settings = CreateSerializerSettings(context);
            var response = context.HttpContext.Response;
            response.ContentType = "application/json";

            WriteInvocations(response, Invocations, settings);
        }
    }
}