
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Take112Tango.Libs.LoanPassSdk.Models
{

    [JsonConverter(typeof(StringEnumConverter))]
    public enum DurationUnit
    {
        [EnumMember(Value = "days")]
        Days,
        [EnumMember(Value = "weeks")]
        Weeks,
        [EnumMember(Value = "fortnights")]
        Fortnights,
        [EnumMember(Value = "half-months")]
        HalfMonths,
        [EnumMember(Value = "months")]
        Months,
        [EnumMember(Value = "quarters")]
        Quarters,
        [EnumMember(Value = "years")]
        Years
    }
}
