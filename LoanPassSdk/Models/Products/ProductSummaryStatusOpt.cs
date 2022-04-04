
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Take112Tango.Libs.LoanPassSdk.Models.Products
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ProductSummaryStatusOpt
    {
        [EnumMember(Value = "available")]
        Available,
        [EnumMember(Value = "approved")]
        Approved,
        [EnumMember(Value = "rejected")]
        Rejected,
        [EnumMember(Value = "error")]
        Error,
        [EnumMember(Value = "missing-configuration")]
        MissingConfiguration,
        [EnumMember(Value = "no-pricing")]
        NoPricing
    }
}
