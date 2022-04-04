

using System.Collections.Generic;

namespace Take112Tango.Libs.LoanPassSdk.Models.Products
{
    public class ProductExecutionStatusAsRejected : AnyOfProductExecutionStatus
    {
        public ProductExecutionStatusOpt Type { get; } = ProductExecutionStatusOpt.Rejected;

        public List<ExecutionError> Errors { get; set; }
    }
}