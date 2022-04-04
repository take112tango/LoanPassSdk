

using System.Collections.Generic;

namespace Take112Tango.Libs.LoanPassSdk.Models.Products
{
    public class ProductExecutionStatusAsError : AnyOfProductExecutionStatus
    {
        public ProductExecutionStatusOpt Type { get; } = ProductExecutionStatusOpt.Error;

        public List<ExecutionError> Errors { get; set; }
    }
}
