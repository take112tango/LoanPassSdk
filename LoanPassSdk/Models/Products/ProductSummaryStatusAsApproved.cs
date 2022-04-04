

using System.Collections.Generic;

namespace Take112Tango.Libs.LoanPassSdk.Models.Products
{
    public class ProductSummaryStatusAsApproved : AnyOfProductSummaryStatus
    {
        
        public ProductSummaryStatusOpt Type { get; init; } = ProductSummaryStatusOpt.Approved;

        public List<PriceScenarioSummary> PriceScenarios { get; set; }

        
    }
}
