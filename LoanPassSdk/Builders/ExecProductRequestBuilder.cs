
using System;
using System.Collections.Generic;
using Take112Tango.Libs.LoanPassSdk.DTO;
using Take112Tango.Libs.LoanPassSdk.Models;

namespace Take112Tango.Libs.LoanPassSdk.Builders
{
    public class ExecProductRequestBuilder : ExecSummaryRequestBuilder, ExecProductRequest.IBuilder
    {
        private string _productId;

        public ExecProductRequest.IBuilder WithProdId(string prodId)
        {
            _productId = prodId;
            return this;
        }

        ExecProductRequest ExecProductRequest.IBuilder.Build()
        {
            var request = new ExecProductRequest(_productId, base.Build());

            return request;
        }

        #region Hide Base
        public new ExecProductRequest.IBuilder WithTime(DateTime value)
        {
            base.WithTime(value);
            return this;
        }

        public new ExecProductRequest.IBuilder WithField(FieldValueMapping value)
        {
            base.WithField(value);
            return this;
        }

        public new ExecProductRequest.IBuilder WithFields(List<FieldValueMapping> values)
        {
            base.WithFields(values);
            return this;
        }
        #endregion
    }
}
