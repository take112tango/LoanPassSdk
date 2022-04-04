using System;
using Take112Tango.Libs.LoanPassSdk.Models.Fields;


namespace Take112Tango.Libs.LoanPassSdk.Dynamic
{
    
    [AttributeUsage(AttributeTargets.Field)]
    public class LPFieldTagAttribute : Attribute
    {
        public string Id { get; init; }
        public FieldValueTypeOpt Type { get; init; }
        public string RefId { get; init; }
        public LPFieldTagAttribute(string id, FieldValueTypeOpt type, string refId = null)
        {
            Id = id;
            Type = type;
            RefId = refId;
        }
    }
}
