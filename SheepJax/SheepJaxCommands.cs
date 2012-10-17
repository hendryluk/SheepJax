using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace SheepJax
{
    public abstract class SheepJaxCommands
    {
        protected readonly IList<SheepJaxInvoke> Invokes = new List<SheepJaxInvoke>();
        
        public IEnumerable<SheepJaxInvoke> Invocations
        {
            get { return Invokes; }
        }

        public string GetJson(JsonSerializerSettings settings)
        {
            return JsonConvert.SerializeObject(Invokes, Formatting.None, settings);
        }

        public static SheepJaxCommands<dynamic> Dynamic(Action<dynamic> command = null)
        {
            return new SheepJaxCommands<dynamic>(command);
        }
    }

    public class SheepJaxCommands<T> : SheepJaxCommands
    {
        public T Client { get; private set; }

        public SheepJaxCommands(Action<T> command = null)
        {
            Client = SheepJaxProxyGenerator.Instance.Create<T>(invoke => Invokes.Add(invoke));

            if (command != null)
                command(Client);
        }
    }
}