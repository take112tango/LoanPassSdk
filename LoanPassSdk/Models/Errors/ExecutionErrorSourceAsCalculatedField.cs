
namespace Take112Tango.Libs.LoanPassSdk.Models.Errors
{
    public class ExecutionErrorSourceAsCalculatedField : AnyOfExecutionErrorSource
    {
        public ExecutionErrorSourceOpt Type { get; } = ExecutionErrorSourceOpt.CalculatedField;

        public string FieldId { get; set; }
    }
}
