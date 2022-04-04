
using System.Collections.Generic;
using Take112Tango.Libs.LoanPassSdk.Builders;
using Take112Tango.Libs.LoanPassSdk.Generated;

namespace Take112Tango.Libs.LoanPassSdk.Models
{
    public class FieldValueMapping
    {
        public string FieldId { get; set; }
        public AnyOfFieldValue Value { get; set; }

        public static IBuilderStrong BuilderStrong() => Builder();
        
        public static IBuilder Builder() => new FieldValueMappingBuilder();
        
        public interface IBuilderStrong
        {
            List<FieldValueMapping> Build();

            IBuilderStrong Field(KnownFieldId fieldId,  object value, params object[] extra);

            IBuilderStrong FieldEnum(KnownFieldId fieldId, string variantId);
            IBuilderStrong FieldNumber(KnownFieldId fieldId, double value);
            IBuilderStrong FieldString(KnownFieldId fieldId, string value);
            IBuilderStrong FieldDuration(KnownFieldId fieldId, double count, DurationUnit unit);
        }

        public interface IBuilder : IBuilderStrong
        {
            IBuilder FieldEnum(string fieldId, string enumTypeId, string variantId);
            IBuilder FieldNumber(string fieldId, double value);
            IBuilder FieldString(string fieldId, string value);
            IBuilder FieldDuration(string fieldId, double count, DurationUnit unit);
        }
    }
}
