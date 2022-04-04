using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Take112Tango.Libs.LoanPassSdk.Dynamic;
using Take112Tango.Libs.LoanPassSdk.Utils;


// ReSharper disable InconsistentNaming
// ReSharper disable IdentifierTypo
// ReSharper disable UnusedMember.Global
// 
// This source code was auto-generated in 12/30/2021 07:04:46
// 
namespace Take112Tango.Libs.LoanPassSdk.Generated
{
    /// <summary>
    /// Field definitions auto generated from LoanPass API for strong type checking
    /// </summary>
    [GeneratedCode("Take112Tango.Libs.LoanPassSdk.TypeGenerator.CodeGen.CS.EnumDefCodeGen", "1.0.0.0")]
    [JsonConverter(typeof(StringEnumConverter))]
    public enum KnownEnumId
    {
        [EnumMember(Value = "loan-purpose")]
        [TextTags("VariantIds", "purchase", "refinance", "assumption", "mortgage-modification")]
        LOAN_PURPOSE
        , [EnumMember(Value = "channel")]
        [TextTags("VariantIds", "correspondent", "wholesale")]
        CHANNEL

    }

    public static class KnownEnumIdExt
    {
        private static readonly Dictionary<string, KnownEnumId> Value2Enum;
        private static readonly Dictionary<KnownEnumId, string> Enum2Value;
        private static readonly Dictionary<string, HashSet<string>> ValueToVariantIds;
        static KnownEnumIdExt()
        {
            var values = Enum.GetValues(typeof(KnownEnumId));
            Value2Enum = Helper.MapValue2Obj<KnownEnumId>(values);
            Enum2Value = Helper.MapObj2Value<KnownEnumId>(values);

            static HashSet<string> ValueGenerator(object enumVal)
            {
                var attribute = ((Enum)enumVal).GetAttributeOfType<TextTagsAttribute>();
                return new HashSet<string>(attribute.Tags);

            }

            ValueToVariantIds = Helper.MapValue2Obj(values, ValueGenerator);
        }

        public static KnownEnumId? ToEnum(string key)
        {
            return Value2Enum.GetValueOrDefault(key);
        }

        public static string ToValue(KnownEnumId key)
        {
            return Enum2Value.GetValueOrDefault(key);
        }

        public static HashSet<string> ToVariantIds(string key)
        {
            return ValueToVariantIds.GetValueOrDefault(key);
        }

        public static bool IsValidVariantId(string key, string variantId)
        {
            HashSet<string> varianIdSet = ValueToVariantIds.GetValueOrDefault(key);
            return varianIdSet != null && varianIdSet.Contains(variantId);
        }

        public static void ValidateVariantId(string key, string variantId)
        {
            if (!IsValidVariantId(key, variantId))
                throw new KeyNotFoundException($"KnownEnumId ({key}) does not contain VariantId ({variantId})");
        }
    }
}
