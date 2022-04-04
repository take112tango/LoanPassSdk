

using System;
using Take112Tango.Libs.LoanPassSdk.Generated;

namespace Take112Tango.Libs.LoanPassSdk.Mappers
{
    [AttributeUsage(AttributeTargets.Property)]
    public class PropTagAttribute : Attribute
    {
        public KnownFieldId Field { get; init; }

        public PropTagAttribute(KnownFieldId field)
        {
            Field = field;
        }
    }
}
