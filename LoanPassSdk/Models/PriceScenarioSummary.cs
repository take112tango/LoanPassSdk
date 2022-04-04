

namespace Take112Tango.Libs.LoanPassSdk.Models
{
    public class PriceScenarioSummary
    {
        public double? AdjustedRate { get; set; }
        public DurationValue AdjustedRateLockPeriod { get; set; }
        public double? AdjustedPrice { get; set; }
        public AnyOfPriceScenarioSummaryStatus Status { get; set; }
    }
}
