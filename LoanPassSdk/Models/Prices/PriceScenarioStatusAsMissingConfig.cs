

namespace Take112Tango.Libs.LoanPassSdk.Models.Prices
{
    public class PriceScenarioStatusAsMissingConfig : AnyOfPriceScenarioStatus
    {
        public PriceScenarioStatusOpt Type { get; } = PriceScenarioStatusOpt.MissingConfiguration;
    }
}
