

using System.Collections.Generic;

namespace Take112Tango.Libs.LoanPassSdk.Models.Prices
{
    public class PriceScenarioSummaryStatusAsAvailable : AnyOfPriceScenarioSummaryStatus
    {
        public PriceScenarioSummaryStatusOpt Type { get; init; } = PriceScenarioSummaryStatusOpt.Available;

        public List<string> RequiredFieldIds { get; set; }
    }
}
