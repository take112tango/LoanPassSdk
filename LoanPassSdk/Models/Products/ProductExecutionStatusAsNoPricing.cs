

namespace Take112Tango.Libs.LoanPassSdk.Models.Products
{
    public class ProductExecutionStatusAsNoPricing : AnyOfProductExecutionStatus
    {
        public ProductExecutionStatusOpt Type { get; } = ProductExecutionStatusOpt.NoPricing;
    }
}