using JsonSubTypes;
using Newtonsoft.Json;
using Take112Tango.Libs.LoanPassSdk.Models.Fields;

namespace Take112Tango.Libs.LoanPassSdk.Models
{
    [JsonConverter(typeof(JsonSubtypes), nameof(Type))]
    [JsonSubtypes.KnownSubType(typeof(FieldValueAsNumber), FieldValueOpt.Number)]
    [JsonSubtypes.KnownSubType(typeof(FieldValueAsString), FieldValueOpt.String)]
    [JsonSubtypes.KnownSubType(typeof(FieldValueAsEnum), FieldValueOpt.Enum)]
    [JsonSubtypes.KnownSubType(typeof(FieldValueAsDuration), FieldValueOpt.Duration)]
    public interface AnyOfFieldValue
    {
        FieldValueOpt Type { get; }
    }
}
