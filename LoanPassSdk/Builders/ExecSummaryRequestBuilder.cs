
using System;
using System.Collections.Generic;
using Take112Tango.Libs.LoanPassSdk.DTO;
using Take112Tango.Libs.LoanPassSdk.Models;

namespace Take112Tango.Libs.LoanPassSdk.Builders
{
    public class ExecSummaryRequestBuilder : ExecSummaryRequest.IBuilder
    {
        private DateTime _time = DateTime.Now;
        private readonly List<FieldValueMapping> _fields = new();

        public ExecSummaryRequest.IBuilder WithTime(DateTime value)
        {
            _time = value;
            return this;
        }

        public ExecSummaryRequest.IBuilder WithField(FieldValueMapping value)
        {
            _fields.Add(value);
            return this;
        }

        public ExecSummaryRequest.IBuilder WithFields(List<FieldValueMapping> values)
        {
            _fields.AddRange(values);
            return this;
        }

        public ExecSummaryRequest Build()
        {
            var fieldsCopy = new List<FieldValueMapping>(_fields);
            return new ExecSummaryRequest(_time, fieldsCopy);
        }
    }
}
