

using System.Collections.Generic;

namespace Take112Tango.Libs.LoanPassSdk.Models
{
    public class PriceScenarioResult
    {
        public List<FieldValueMapping> PriceScenarioFields { get; set; }

        public List<OptionalFieldValueMapping> CalculatedFields { get; set; }

        public AnyOfPriceScenarioStatus Status { get; set; }
    }
}
