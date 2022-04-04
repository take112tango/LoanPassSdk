

using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Take112Tango.Libs.LoanPassSdk.Models.Prices
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum PriceScenarioStatusOpt
    {
        [EnumMember(Value = "approved")]
        Approved,
        [EnumMember(Value = "rejected")]
        Rejected,
        [EnumMember(Value = "error")]
        Error,
        [EnumMember(Value = "missing-configuration")]
        MissingConfiguration
    }
}
