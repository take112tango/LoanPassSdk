using System;


namespace Take112Tango.Libs.LoanPassSdk.Models
{
    public class FieldCondition
    {
        public FieldConditionOpt Type { get; }

        public string ParentFieldId { get; set; }

        public AnyOfFieldValue Value { get; set; }
    }
}
