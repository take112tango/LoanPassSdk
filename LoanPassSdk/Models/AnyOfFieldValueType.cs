

using JsonSubTypes;
using Newtonsoft.Json;
using Take112Tango.Libs.LoanPassSdk.Models.Fields;

namespace Take112Tango.Libs.LoanPassSdk.Models
{
    [JsonConverter(typeof(JsonSubtypes), nameof(Type))]
    [JsonSubtypes.KnownSubType(typeof(FieldValueTypeAsNumber), FieldValueTypeOpt.Number)]
    [JsonSubtypes.KnownSubType(typeof(FieldValueTypeAsString), FieldValueTypeOpt.String)]
    [JsonSubtypes.KnownSubType(typeof(FieldValueTypeAsEnum), FieldValueTypeOpt.Enum)]
    [JsonSubtypes.KnownSubType(typeof(FieldValueTypeAsDuration), FieldValueTypeOpt.Duration)]
    public interface AnyOfFieldValueType
    {
        FieldValueTypeOpt Type { get; }
    }
}
