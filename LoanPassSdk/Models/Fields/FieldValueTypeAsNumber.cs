
namespace Take112Tango.Libs.LoanPassSdk.Models.Fields
{
    public class FieldValueTypeAsNumber : AnyOfFieldValueType
    {
        public FieldValueTypeOpt Type { get; } = FieldValueTypeOpt.Number;

        public double? Minimum { get; set; }
        public double? Maximum { get; set; }
        public double? Precision { get; set; }

        public NumberFieldStyle Style { get; set; }
    }
}
