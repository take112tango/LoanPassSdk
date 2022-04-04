

using JsonSubTypes;
using Newtonsoft.Json;
using Take112Tango.Libs.LoanPassSdk.Models.Prices;

namespace Take112Tango.Libs.LoanPassSdk.Models
{
    [JsonConverter(typeof(JsonSubtypes), nameof(Type))]
    [JsonSubtypes.KnownSubType(typeof(PriceScenarioSummaryStatusAsAvailable), PriceScenarioSummaryStatusOpt.Available)]
    [JsonSubtypes.FallBackSubType(typeof(PriceScenarioSummaryStatusAsOthers))]
    public interface AnyOfPriceScenarioSummaryStatus
    {
        PriceScenarioSummaryStatusOpt Type { get; init; }
    }
}
