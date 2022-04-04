

using System;

namespace Take112Tango.Libs.LoanPassSdk.Dynamic
{
    [AttributeUsage(AttributeTargets.Field)]
    public class TextTagsAttribute : Attribute
    {
        public string Name { get; init; }
        public string[]  Tags { get; init; }
        public TextTagsAttribute(string name, params string[] tags)
        {
            Name = name;
            Tags = tags;
        }
    }
}
