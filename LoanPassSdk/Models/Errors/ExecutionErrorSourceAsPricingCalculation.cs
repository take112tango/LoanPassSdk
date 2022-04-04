
namespace Take112Tango.Libs.LoanPassSdk.Models.Errors
{
    public class ExecutionErrorSourceAsPricingCalculation : AnyOfExecutionErrorSource
    {
        public ExecutionErrorSourceOpt Type { get; } = ExecutionErrorSourceOpt.PricingCalculation;

        public string FieldId { get; set; }
    }
}
