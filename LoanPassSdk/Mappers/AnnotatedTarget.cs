

using System;
using System.Reflection;

namespace Take112Tango.Libs.LoanPassSdk.Mappers
{
    public class AnnotatedTarget<T> where T : MemberInfo
    {
        public object Source { get; init; }
        public T Member { get; init; }
        public Attribute Attr { get; init; }
        public object Value { get; init; }
    }
}
