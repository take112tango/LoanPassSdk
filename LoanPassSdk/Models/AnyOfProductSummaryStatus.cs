
using JsonSubTypes;
using Newtonsoft.Json;
using Take112Tango.Libs.LoanPassSdk.Models.Products;

namespace Take112Tango.Libs.LoanPassSdk.Models
{
    [JsonConverter(typeof(JsonSubtypes), nameof(Type))]
    [JsonSubtypes.KnownSubType(typeof(ProductSummaryStatusAsApproved), ProductSummaryStatusOpt.Approved)]
    [JsonSubtypes.KnownSubType(typeof(ProductSummaryStatusAsAvailable), ProductSummaryStatusOpt.Available)]
    [JsonSubtypes.FallBackSubType(typeof(ProductSummaryStatusAsOthers))]
    public interface AnyOfProductSummaryStatus
    {
        ProductSummaryStatusOpt Type { get; init; }
    }
}
