
using System;
using System.Collections.Generic;
using Take112Tango.Libs.LoanPassSdk.Builders;
using Take112Tango.Libs.LoanPassSdk.Models;

namespace Take112Tango.Libs.LoanPassSdk.DTO
{
    public class ExecSummaryRequest : ReqResBase
    {
        public List<FieldValueMapping> CreditApplicationFields { get; init; } = new();

        public ExecSummaryRequest() { }

        public ExecSummaryRequest(DateTime time, List<FieldValueMapping> fields) : base(time)
        {
            CreditApplicationFields = fields;
        }


        public static FieldValueMapping.IBuilder FieldsBuilder() => new FieldValueMappingBuilder();
        public static IBuilder Builder() => new ExecSummaryRequestBuilder();


        public interface IBuilder
        {
            IBuilder WithTime(DateTime instant);
            IBuilder WithField(FieldValueMapping field);
            IBuilder WithFields(List<FieldValueMapping> fields);
            ExecSummaryRequest Build();
        }
    }
}
