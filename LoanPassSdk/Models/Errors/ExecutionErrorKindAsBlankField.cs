namespace Take112Tango.Libs.LoanPassSdk.Models.Errors
{
    public class ExecutionErrorKindAsBlankField : AnyOfExecutionErrorKind
    {
        public ExecutionErrorKindOpt Type { get; } = ExecutionErrorKindOpt.BlankField;

        public string FieldId { get; set; }
    }
}
