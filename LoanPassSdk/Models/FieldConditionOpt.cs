

using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Take112Tango.Libs.LoanPassSdk.Models
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum FieldConditionOpt
    {
        [EnumMember(Value = "parent-field-is-not-blank")]
        ParentFieldIsNotBlank,
        [EnumMember(Value = "parent-field-has-value")]
        ParentFieldHasValue
    }
}
