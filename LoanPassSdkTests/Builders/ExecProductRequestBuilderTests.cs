using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Take112Tango.Libs.LoanPassSdk.DTO;
using Take112Tango.Libs.LoanPassSdk.Generated;
using Take112Tango.Libs.LoanPassSdk.Models;
using Take112Tango.Libs.LoanPassSdk.Utils;

namespace Take112Tango.Libs.LoanPassSdk.Tests.Builders
{
    [TestClass()]
    public class ExecProductRequestBuilderTests
    {
        [TestMethod()]
        public void BuildTest()
        {
            //Arrange
            var fields = ExecProductRequest.FieldsBuilder()
                .FieldEnum(KnownFieldId.LOAN_PURPOSE, "purchase")
                .FieldNumber(KnownFieldId.BASE_LOAN_AMOUNT, 12)
                .FieldString(KnownFieldId.STATE, "ca")
                .FieldDuration(KnownFieldId.DESIRED_LOAN_TERM, 30, DurationUnit.Years)
                .Build();

            
            //Act
            var request = ExecProductRequest.Builder()
                .WithTime(DateTime.Now)
                .WithFields(fields)
                .WithProdId("some product id")
                .Build();


            //Assert
            Console.WriteLine(request.ToJson());

            Assert.IsNotNull(request);
            Assert.IsInstanceOfType(request, typeof(ExecProductRequest));
            Assert.AreEqual(fields.Count, request.CreditApplicationFields.Count);
        }
    }
}