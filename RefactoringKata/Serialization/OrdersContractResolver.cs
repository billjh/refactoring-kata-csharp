using System;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using RefactoringKata.Enums;

namespace RefactoringKata.Serialization
{
    public class OrdersContractResolver : DefaultContractResolver
    {
        protected override string ResolvePropertyName(string propertyName)
        {
            return propertyName.ToLower();
        }

        protected override JsonConverter ResolveContractConverter(Type objectType)
        {
            if (objectType == typeof(ProductColor))
            {
                return new ProductColorConverter();
            }
            if (objectType == typeof(ProductSize))
            {
                return new ProductSizeConverter();
            }
            return base.ResolveContractConverter(objectType);
        }

        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            var property = base.CreateProperty(member, memberSerialization);

            if (property.DeclaringType == typeof(Product) && property.PropertyName == "size")
            {
                property.ShouldSerialize = instance => ((Product) instance).Size != ProductSize.SIZE_NOT_APPLICABLE;
            }

            return property;
        }
    }
}