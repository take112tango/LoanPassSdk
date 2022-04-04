using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Take112Tango.Libs.LoanPassSdk.DTO;
using Take112Tango.Libs.LoanPassSdk.Utils;

namespace Take112Tango.Libs.LoanPassSdk.Tests.DTO
{
    [TestClass()]
    public class ExecSummaryRequestTests
    {
        private const string FileOkRequest = @"TestData\ExecSummary\ok_request.json";

        internal static ExecSummaryRequest CreateRequest()
        {
            var filepath = PathUtil.CombineRunningDir(FileOkRequest);
            return JsonUtil.FromJsonFile<ExecSummaryRequest>(filepath);
        }

        [TestMethod()]
        public void DeserializeTest()
        {
            //Arrange
            //Act
            var result = CreateRequest();


            //Assert
            Console.Write(result.ToJson());

            Assert.IsNotNull(result.CurrentTime);
        }
    }
}