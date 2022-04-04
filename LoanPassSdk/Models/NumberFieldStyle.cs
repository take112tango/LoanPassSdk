using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Take112Tango.Libs.LoanPassSdk.Models
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum NumberFieldStyle
    {
        [EnumMember(Value = "plain")]
        Plain,
        [EnumMember(Value = "percent")]
        Percent,
        [EnumMember(Value = "dollar")]
        Dollar
    }
}
