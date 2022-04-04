using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Take112Tango.Libs.LoanPassSdk.DTO;
using Take112Tango.Libs.LoanPassSdk.Utils;

namespace Take112Tango.Libs.LoanPassSdk.Tests.DTO
{
    [TestClass()]
    public class ExecProductRequestTests
    {
        private const string FileOkRequest = @"TestData\ExecProduct\ok_request.json";

        internal static ExecProductRequest CreateRequest()
        {
            var filepath = PathUtil.CombineRunningDir(FileOkRequest);
            return JsonUtil.FromJsonFile<ExecProductRequest>(filepath);
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