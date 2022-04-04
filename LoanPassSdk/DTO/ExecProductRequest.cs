

using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Take112Tango.Libs.LoanPassSdk.Builders;
using Take112Tango.Libs.LoanPassSdk.Models;

namespace Take112Tango.Libs.LoanPassSdk.DTO
{
    public class ExecProductRequest : ExecSummaryRequest
    {
        [JsonProperty(Order = -1)]
        public string ProductId { get; set; }

        public ExecProductRequest() { }

        public ExecProductRequest(string productId, ExecSummaryRequest sumRequest) 
            : base(sumRequest.CurrentTime, sumRequest.CreditApplicationFields)
        {
            ProductId = productId;
        }


        public new static ExecProductRequest.IBuilder Builder() => new ExecProductRequestBuilder();

        public new interface IBuilder : ExecSummaryRequest.IBuilder
        {
            IBuilder WithProdId(string prodId);
            new ExecProductRequest Build();

            #region Hide Base
            new ExecProductRequest.IBuilder WithTime(DateTime instant);
            new ExecProductRequest.IBuilder WithField(FieldValueMapping field);
            new ExecProductRequest.IBuilder WithFields(List<FieldValueMapping> fields);
            #endregion
        }
    }
}
