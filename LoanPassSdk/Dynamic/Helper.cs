

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Take112Tango.Libs.LoanPassSdk.Utils;

namespace Take112Tango.Libs.LoanPassSdk.Dynamic
{
    public static class Helper
    {
        private static Dictionary<TKey,TValue> CreateMap<TKey,TValue>(Array items
            , Func<object, TKey> keyGenerator
            , Func<object, TValue> valueGenerator)
        {
            var map = new Dictionary<TKey, TValue>();
            foreach (var item in items)
            {
                TKey key = keyGenerator(item);
                TValue value = valueGenerator(item);

                map.Add(key, value);
            }

            return map;
        }

        public static T GetAttributeOfType<T>(this Enum enumName) where T : Attribute
        {
            var type = enumName.GetType();
            var memInfo = type.GetMember(enumName.ToString());
            var attributes = memInfo[0].GetCustomAttributes(typeof(T), false);
            return (attributes.Length > 0) ? (T)attributes[0] : null;
        }

        public static string GetEnumMemberValue(object enumVal)
        {
            var attribute = ((Enum) enumVal).GetAttributeOfType<EnumMemberAttribute>();
            string key = attribute?.Value;
            return key;
        }

        public static LPFieldTagAttribute GetLPFieldTagAttribute(object enumVal)
        {
            return ((Enum)enumVal).GetAttributeOfType<LPFieldTagAttribute>();
        }

        public static Dictionary<string, TValue> MapValue2Obj<TValue>(Array items
            , Func<object, TValue> valueGenerator)
        {
            return CreateMap(items, GetEnumMemberValue, valueGenerator);
        }

        public static Dictionary<string, TValue> MapValue2Obj<TValue>(Array items)
        {
            return MapValue2Obj(items, (item) => (TValue)item);
        }

        public static Dictionary<TKey, string> MapObj2Value<TKey>(Array items
            , Func<object, TKey> keyGenerator)
        {
            return CreateMap(items, keyGenerator, GetEnumMemberValue);
        }

        public static Dictionary<TKey, string> MapObj2Value<TKey>(Array items)
        {
            return MapObj2Value(items, (item) => (TKey) item);
        }

        public static Dictionary<TKey, LPFieldTagAttribute> MapObj2LPFieldTag<TKey>(Array items
            , Func<object, TKey> keyGenerator)
        {
            return CreateMap(items, keyGenerator, GetLPFieldTagAttribute);
        }

        public static Dictionary<TKey, LPFieldTagAttribute> MapObj2LPFieldTag<TKey>(Array items)
        {
            return MapObj2LPFieldTag(items, (item) => (TKey)item);
        }
    }
}
