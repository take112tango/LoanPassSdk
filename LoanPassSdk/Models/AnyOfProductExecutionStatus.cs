

using JsonSubTypes;
using Newtonsoft.Json;
using Take112Tango.Libs.LoanPassSdk.Models.Products;

namespace Take112Tango.Libs.LoanPassSdk.Models
{
    [JsonConverter(typeof(JsonSubtypes), nameof(Type))]
    [JsonSubtypes.KnownSubType(typeof(ProductExecutionStatusAsRejected), ProductExecutionStatusOpt.Rejected)]
    [JsonSubtypes.KnownSubType(typeof(ProductExecutionStatusAsError), ProductExecutionStatusOpt.Error)]
    [JsonSubtypes.KnownSubType(typeof(ProductExecutionStatusAsNoPricing), ProductExecutionStatusOpt.NoPricing)]
    [JsonSubtypes.KnownSubType(typeof(ProductExecutionStatusAsOk), ProductExecutionStatusOpt.Ok)]
    public interface AnyOfProductExecutionStatus
    {
        ProductExecutionStatusOpt Type { get; }
    }
}
