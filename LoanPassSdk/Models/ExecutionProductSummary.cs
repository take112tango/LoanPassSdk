
namespace Take112Tango.Libs.LoanPassSdk.Models
{
    public class ExecutionProductSummary
    {
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductCode { get; set; }
        public string InvestorName { get; set; }
        public string InvestorCode { get; set; }
        public bool? IsPricingEnabled { get; set; }

        public AnyOfProductSummaryStatus Status { get; set; }
    }
}
