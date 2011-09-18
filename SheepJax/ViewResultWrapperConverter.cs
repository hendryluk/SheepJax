using System;
using System.IO;
using System.Reflection;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace SheepJax
{
    public class ViewResultWrapperConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var obj = (value as ViewResultWrapper);
            if (obj == null)
            {
                writer.WriteNull();
                return;
            }

            var vr = obj.GetViewResult();
            serializer.Serialize(writer, vr);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override bool CanConvert(Type objectType)
        {
            return typeof (ViewResultWrapper).IsAssignableFrom(objectType);
        }
    }
}