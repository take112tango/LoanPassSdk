
using JsonSubTypes;
using Newtonsoft.Json;
using Take112Tango.Libs.LoanPassSdk.Models.Prices;

namespace Take112Tango.Libs.LoanPassSdk.Models
{
    [JsonConverter(typeof(JsonSubtypes), nameof(Type))]
    [JsonSubtypes.KnownSubType(typeof(PriceScenarioStatusAsApproved), PriceScenarioStatusOpt.Approved)]
    [JsonSubtypes.KnownSubType(typeof(PriceScenarioStatusAsError), PriceScenarioStatusOpt.Error)]
    [JsonSubtypes.KnownSubType(typeof(PriceScenarioStatusAsMissingConfig), PriceScenarioStatusOpt.MissingConfiguration)]
    [JsonSubtypes.KnownSubType(typeof(PriceScenarioStatusAsRejected), PriceScenarioStatusOpt.Rejected)]
    public interface AnyOfPriceScenarioStatus
    {
        PriceScenarioStatusOpt Type { get; }
    }
}
