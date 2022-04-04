using System;

namespace Take112Tango.Libs.LoanPassSdk.Models.Fields
{
    public class FieldValueAsDuration : AnyOfFieldValue
    {
        public FieldValueOpt Type { get; } = FieldValueOpt.Duration;
        public double? Count { get; set; }
        public DurationUnit Unit { get; set; }
    }
}
