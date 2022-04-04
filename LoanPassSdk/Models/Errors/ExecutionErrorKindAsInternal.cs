namespace Take112Tango.Libs.LoanPassSdk.Models.Errors
{
    public class ExecutionErrorKindAsInternal : AnyOfExecutionErrorKind
    {
        public ExecutionErrorKindOpt Type { get; } = ExecutionErrorKindOpt.Internal;

        public string Message { get; set; }
    }
}
