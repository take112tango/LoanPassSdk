using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Take112Tango.Libs.LoanPassSdk.DTO;
using Take112Tango.Libs.LoanPassSdk.Utils;

namespace Take112Tango.Libs.LoanPassSdk.Tests.DTO
{
    [TestClass()]
    public class ErrorResponseTests
    {
        [TestMethod()]
        public void DeserializeTest()
        {
            //Arrange
            var filename = PathUtil.CombineRunningDir(@"TestData\error_response.json");

            //Act
            var result = JsonUtil.FromJsonFile<ErrorResponse>(filename);


            //Assert
            Console.Write(result.ToJson());
        }
    }
}