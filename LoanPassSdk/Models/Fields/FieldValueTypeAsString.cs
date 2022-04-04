

namespace Take112Tango.Libs.LoanPassSdk.Models.Fields
{
    public class FieldValueTypeAsString : AnyOfFieldValueType
    {
        public FieldValueTypeOpt Type { get; } = FieldValueTypeOpt.String;
        public StringFieldFormat Format { get; set; }
    }
}
