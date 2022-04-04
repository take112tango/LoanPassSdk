
using System.Collections.Generic;
using Take112Tango.Libs.LoanPassSdk.Models;

namespace Take112Tango.Libs.LoanPassSdk.DTO
{
    public class ExecSummaryResponse : ReqResBase
    {
        public ExecutionSummaryTotals Totals { get; set; }

        public List<ExecutionProductSummary> Products { get; set; }
    }
}
