using System;
using System.Reactive;
using Common.Logging;
using Newtonsoft.Json;
using System.Linq;

namespace SheepJax.Comet
{
    public class PollableTaskConverter: JsonConverter
    {
        private static readonly ILog _logger = LogManager.GetLogger<PollableTask>();

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var bus = SheepJaxComet.PollingCommandBus;
            var pollable = ((PollableTask)value);

            var converters = serializer.Converters.ToArray();
            var observer = bus.GetObserver(pollable.Id);

            pollable.Start(
                Observer.Create<SheepJaxInvoke>(i => observer.OnNext(JsonConvert.SerializeObject(i, Formatting.None, converters)), 
                    ex=>
                        {
                            _logger.Error("Exception occured in a pollable task", ex);
                            observer.OnError(ex);
                        }, 
                    observer.OnCompleted));

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