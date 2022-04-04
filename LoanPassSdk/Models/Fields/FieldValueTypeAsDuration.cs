using System;

namespace Take112Tango.Libs.LoanPassSdk.Models.Fields
{
    public class FieldValueTypeAsDuration : AnyOfFieldValueType
    {
        public FieldValueTypeOpt Type { get; } = FieldValueTypeOpt.Duration;

        public double? MinimumDays { get; set; }
        public double? MaximumDays { get; set; }
        public double? MinimumMonths { get; set; }
        public double? MaximumMonths { get; set; }
    }
}
