
namespace Take112Tango.Libs.LoanPassSdk.Models.Errors
{
    public class ExecutionErrorSourceAsDataTableLookup : AnyOfExecutionErrorSource
    {
        public ExecutionErrorSourceOpt Type { get; } = ExecutionErrorSourceOpt.DataTableLookup;

        public string LookupId { get; set; }
    }
}
