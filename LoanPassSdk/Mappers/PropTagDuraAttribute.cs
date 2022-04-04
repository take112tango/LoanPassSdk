

using System;
using Take112Tango.Libs.LoanPassSdk.Generated;
using Take112Tango.Libs.LoanPassSdk.Models;

namespace Take112Tango.Libs.LoanPassSdk.Mappers
{
    [AttributeUsage(AttributeTargets.Property)]
    public class PropTagDuraAttribute : PropTagAttribute
    {
        public DurationUnit Unit { get; init; }

        public PropTagDuraAttribute(KnownFieldId field, DurationUnit unit) : base(field)
        {
            Unit = unit;
        }
    }
}
