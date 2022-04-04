

using System.Collections.Generic;

namespace Take112Tango.Libs.LoanPassSdk.Models.Prices
{
    public class PriceScenarioStatusAsError : AnyOfPriceScenarioStatus
    {
        public PriceScenarioStatusOpt Type { get; } = PriceScenarioStatusOpt.Error;

        public List<ExecutionError> Errors { get; set; }
    }
}
