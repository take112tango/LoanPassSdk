
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Take112Tango.Libs.LoanPassSdk.Models
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum StringFieldFormat
    {
        [EnumMember(Value = "plain")]
        Plain,
        [EnumMember(Value = "us-state-code")]
        UsStateCode,
        [EnumMember(Value = "us-county-code")]
        UsCountyCode
    }
}
