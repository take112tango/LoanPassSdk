

using System.Collections.Generic;

namespace Take112Tango.Libs.LoanPassSdk.Models.Prices
{
    public class PriceScenarioStatusAsRejected : AnyOfPriceScenarioStatus
    {
        public PriceScenarioStatusOpt Type { get; } = PriceScenarioStatusOpt.Rejected;

        public List<Rejection> Rejections { get; set; }
        public List<ExecutionError> Errors { get; set; }
    }
}
