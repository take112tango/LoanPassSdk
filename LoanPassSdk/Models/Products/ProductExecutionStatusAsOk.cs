using System.Collections.Generic;

namespace Take112Tango.Libs.LoanPassSdk.Models.Products
{
    public class ProductExecutionStatusAsOk : AnyOfProductExecutionStatus
    {
        public ProductExecutionStatusOpt Type { get; } = ProductExecutionStatusOpt.Ok;

        public string RateSheetEffectiveTimestamp { get; set; }
        public List<PriceScenarioResult> PriceScenarios { get; set; }
    }
}