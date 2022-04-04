

namespace Take112Tango.Libs.LoanPassSdk.Models.Fields
{
    public class FieldValueAsString : AnyOfFieldValue
    {
        public FieldValueOpt Type { get; } = FieldValueOpt.String;
        public string Value { get; set; }
    }
}
