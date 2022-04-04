//using System;
//using System.Collections.Generic;
//using Take112Tango.Libs.LoanPassSdk.Generated;
//using Take112Tango.Libs.LoanPassSdk.Utils;

//namespace Take112Tango.Libs.LoanPassSdk.Dynamic
//{
//    public static class KnownEnumIdExt
//    {
//        private static readonly Dictionary<string, KnownEnumId> Value2Enum;
//        private static readonly Dictionary<string, HashSet<string>> ValueToVariantIds;
//        static KnownEnumIdExt()
//        {
//            var values = Enum.GetValues(typeof(KnownEnumId));
//            Value2Enum = Helper.MapValue2Obj<KnownEnumId>(values);

//            static HashSet<string> ValueGenerator(object enumVal)
//            {
//                var attribute = ((Enum)enumVal).GetAttributeOfType<TextTagsAttribute>();
//                return new HashSet<string>(attribute.Tags);

//            }

//            ValueToVariantIds = Helper.MapValue2Obj(values, ValueGenerator);
//        }

//        public static KnownEnumId? ToEnum(string key)
//        {
//            return Value2Enum.GetValueOrDefault(key);
//        }

//        public static HashSet<string> ToVariantIds(string key)
//        {
//            return ValueToVariantIds.GetValueOrDefault(key);
//        }
//    }
//}
