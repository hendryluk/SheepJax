using System;
using System.IO;
using System.Reflection;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace SheepJax
{
    public class ViewResultConverter : JsonConverter
    {
        private readonly ControllerContext _context;

        public ViewResultConverter(ControllerContext context)
        {
            _context = context;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var vr = value as ViewResultBase;
            var view = vr.View;
            if (view == null)
            {
                if (string.IsNullOrEmpty(vr.ViewName))
                    vr.ViewName = _context.RouteData.GetRequiredString("action");
                view =
                    ((ViewEngineResult)
                     vr.GetType().GetMethod("FindView", BindingFlags.Instance | BindingFlags.NonPublic)
                         .Invoke(vr, new[] {_context})).View;
            }

            using (var sw = new StringWriter())
            {
                view.Render(new ViewContext(_context, view, vr.ViewData, vr.TempData, sw), sw);
                writer.WriteValue(sw.GetStringBuilder().ToString());
            } 
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotSupportedException();
        }

        public override bool CanConvert(Type objectType)
        {
            return typeof (ViewResultBase).IsAssignableFrom(objectType);
        }
    }
}