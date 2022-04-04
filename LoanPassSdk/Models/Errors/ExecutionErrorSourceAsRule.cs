
namespace Take112Tango.Libs.LoanPassSdk.Models.Errors
{
    public class ExecutionErrorSourceAsRule : AnyOfExecutionErrorSource
    {
        public ExecutionErrorSourceOpt Type { get; } = ExecutionErrorSourceOpt.Rule;

        public string RuleId { get; set; }
    }
}
