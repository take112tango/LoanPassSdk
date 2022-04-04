
namespace Take112Tango.Libs.LoanPassSdk.Models.Fields
{
    public class FieldValueAsNumber : AnyOfFieldValue
    {
        public FieldValueOpt Type { get; } = FieldValueOpt.Number;
        public double? Value { get; set; }
    }
}
