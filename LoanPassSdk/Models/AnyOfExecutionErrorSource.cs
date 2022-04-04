

using System;
using JsonSubTypes;
using Newtonsoft.Json;
using Take112Tango.Libs.LoanPassSdk.Models.Errors;

namespace Take112Tango.Libs.LoanPassSdk.Models
{
    [JsonConverter(typeof(JsonSubtypes), nameof(Type))]
    [JsonSubtypes.KnownSubType(typeof(ExecutionErrorSourceAsRule), ExecutionErrorSourceOpt.Rule)]
    [JsonSubtypes.KnownSubType(typeof(ExecutionErrorSourceAsDataTableLookup), ExecutionErrorSourceOpt.DataTableLookup)]
    [JsonSubtypes.KnownSubType(typeof(ExecutionErrorSourceAsCalculatedField), ExecutionErrorSourceOpt.CalculatedField)]
    [JsonSubtypes.KnownSubType(typeof(ExecutionErrorSourceAsPricingCalculation), ExecutionErrorSourceOpt.PricingCalculation)]
    public interface AnyOfExecutionErrorSource
    {
        ExecutionErrorSourceOpt Type { get; }
    }
}
