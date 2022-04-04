

using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Take112Tango.Libs.LoanPassSdk.Models.Rejections
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum RejectionSourceOpt
    {
        [EnumMember(Value = "rule")]
        Rule,
    }
}
