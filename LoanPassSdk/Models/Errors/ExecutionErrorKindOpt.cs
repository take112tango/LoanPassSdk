using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Take112Tango.Libs.LoanPassSdk.Models.Errors
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ExecutionErrorKindOpt
    {
        [EnumMember(Value = "blank-field")]
        BlankField,
        [EnumMember(Value = "internal")]
        Internal
    }
}
