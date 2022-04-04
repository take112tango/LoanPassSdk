
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Take112Tango.Libs.LoanPassSdk.Models.Fields
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum FieldValueOpt
    {
        [EnumMember(Value = "enum")]
        Enum,

        [EnumMember(Value = "string")]
        String,

        [EnumMember(Value = "number")]
        Number,

        [EnumMember(Value = "duration")]
        Duration
    }
}
