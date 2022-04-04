
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Take112Tango.Libs.LoanPassSdk.Models.Products
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ProductExecutionStatusOpt
    {
        [EnumMember(Value = "rejected")]
        Rejected,
        [EnumMember(Value = "error")]
        Error,
        [EnumMember(Value = "no-pricing")]
        NoPricing,
        [EnumMember(Value = "ok")]
        Ok
    }
}
