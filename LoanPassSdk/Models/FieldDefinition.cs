
using JsonSubTypes;
using Newtonsoft.Json;
using Take112Tango.Libs.LoanPassSdk.Models.Fields;

namespace Take112Tango.Libs.LoanPassSdk.Models
{
    public class FieldDefinition
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public AnyOfFieldValueType ValueType { get; set; }
        
        public FieldCondition Condition { get; set; }
    }
}
