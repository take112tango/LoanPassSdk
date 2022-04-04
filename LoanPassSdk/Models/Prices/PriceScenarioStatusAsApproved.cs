

using System.Collections.Generic;

namespace Take112Tango.Libs.LoanPassSdk.Models.Prices
{
    public class PriceScenarioStatusAsApproved : AnyOfPriceScenarioStatus
    {
        public PriceScenarioStatusOpt Type { get; } = PriceScenarioStatusOpt.Approved;

        public List<PriceAdjustmentValue> PriceAdjustments { get; set; }
        public List<MarginAdjustmentValue> MarginAdjustments { get; set; }
        public List<RateAdjustmentValue> RateAdjustments { get; set; }
        public List<StipulationValue> Stipulations { get; set; }
    }
}
