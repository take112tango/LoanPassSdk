//using System;
//using System.Collections.Generic;
//using Take112Tango.Libs.LoanPassSdk.Generated;

//namespace Take112Tango.Libs.LoanPassSdk.Dynamic
//{
//    public static class KnownFieldIdExt
//    {
//        private static readonly Dictionary<string, KnownFieldId> Value2Enum;
//        static KnownFieldIdExt()
//        {
//            var values = Enum.GetValues(typeof(KnownFieldId));
//            Value2Enum = Helper.MapValue2Obj<KnownFieldId>(values);
//        }

//        public static KnownFieldId? ToEnum(string key)
//        {
//            return Value2Enum.GetValueOrDefault(key);
//        }

//    }
//}
