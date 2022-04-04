
using System;
using System.Collections.Generic;
using Take112Tango.Libs.LoanPassSdk.Models;

namespace Take112Tango.Libs.LoanPassSdk.DTO
{
    public class ExecProductResponse : ReqResBase
    {
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductCode { get; set; }
        public string InvestorName { get; set; }
        public string InvestorCode { get; set; }
        public bool? IsPricingEnabled { get; set; }
        public List<FieldValueMapping> ProductFields { get; set; }
        public List<FieldValueMapping> CalculatedFields { get; set; }
        public AnyOfProductExecutionStatus Status { get; set; }
    }
}
