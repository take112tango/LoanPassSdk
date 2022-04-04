

using System;
using JsonSubTypes;
using Newtonsoft.Json;
using Take112Tango.Libs.LoanPassSdk.Models.Errors;

namespace Take112Tango.Libs.LoanPassSdk.Models
{
    [JsonConverter(typeof(JsonSubtypes), nameof(Type))]
    [JsonSubtypes.KnownSubType(typeof(ExecutionErrorKindAsBlankField), ExecutionErrorKindOpt.BlankField)]
    [JsonSubtypes.KnownSubType(typeof(ExecutionErrorKindAsInternal), ExecutionErrorKindOpt.Internal)]
    public interface AnyOfExecutionErrorKind
    {
        ExecutionErrorKindOpt Type { get; }
    }
}
