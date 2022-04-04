

namespace Take112Tango.Libs.LoanPassSdk.Models.Fields
{
    public class FieldValueAsEnum : AnyOfFieldValue
    {
        public FieldValueOpt Type { get; } = FieldValueOpt.Enum;
        public string EnumTypeId { get; set; }
        public string VariantId { get; set; }
    }
}
