using System;
using System.Reactive;
using Newtonsoft.Json;
using System.Linq;

namespace SheepJax.Comet
{
    public class PollableTaskConverter: JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var bus = SheepJaxed.PollingCommandBus;
            var pollable = ((PollableTask)value);

            var converters = serializer.Converters.ToArray();
            var observer = bus.GetObserver(pollable.Id);

            pollable.Start(
                Observer.Create<SheepJaxInvoke>(i => observer.OnNext(JsonConvert.SerializeObject(i, Formatting.None, converters)), 
                    observer.OnError, observer.OnCompleted));

            serializer.Serialize(writer, pollable.Id);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotSupportedException();
        }

        public override bool CanConvert(Type objectType)
        {
            return typeof (PollableTask).IsAssignableFrom(objectType);
        }
    }
}