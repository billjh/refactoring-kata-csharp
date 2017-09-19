using System;
using Newtonsoft.Json;
using RefactoringKata.Enums;
using RefactoringKata.Extensions;

namespace RefactoringKata.Serialization
{
    public class ProductColorConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteValue(((ProductColor) value).Display());
        }

        public override bool CanRead
        {
            get { return false; }
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(ProductColor);
        }
    }
}