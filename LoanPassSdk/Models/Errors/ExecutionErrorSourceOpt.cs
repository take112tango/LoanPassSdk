using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Take112Tango.Libs.LoanPassSdk.Models.Errors
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ExecutionErrorSourceOpt
    {
        [EnumMember(Value = "rule")]
        Rule,
        [EnumMember(Value = "calculated-field")]
        CalculatedField,
        [EnumMember(Value = "data-table-lookup")]
        DataTableLookup,
        [EnumMember(Value = "pricing-calculation")]
        PricingCalculation
    }
}
