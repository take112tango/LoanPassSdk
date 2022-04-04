

using JsonSubTypes;
using Newtonsoft.Json;
using Take112Tango.Libs.LoanPassSdk.Models.Rejections;

namespace Take112Tango.Libs.LoanPassSdk.Models
{
    [JsonConverter(typeof(JsonSubtypes), nameof(Type))]
    [JsonSubtypes.KnownSubType(typeof(RejectionSourceAsRule), RejectionSourceOpt.Rule)]
    public interface AnyOfRejectionSource
    {
        RejectionSourceOpt Type { get; }
    }
}
