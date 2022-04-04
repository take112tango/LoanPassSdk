

using System.Collections.Generic;

namespace Take112Tango.Libs.LoanPassSdk.Models.Products
{
    public class ProductSummaryStatusAsAvailable : AnyOfProductSummaryStatus
    {
        public ProductSummaryStatusOpt Type { get; init; } = ProductSummaryStatusOpt.Available;

        public List<string> RequiredFieldIds { get; set; }
    }
}
