

namespace Take112Tango.Libs.LoanPassSdk.Models.Fields
{
    public class FieldValueTypeAsEnum : AnyOfFieldValueType
    {
        public FieldValueTypeOpt Type { get; } = FieldValueTypeOpt.Enum;
        public string EnumTypeId { get; set; }
    }
}
