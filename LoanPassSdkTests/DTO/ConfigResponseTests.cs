using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Take112Tango.Libs.LoanPassSdk.DTO;
using Take112Tango.Libs.LoanPassSdk.Utils;

namespace Take112Tango.Libs.LoanPassSdk.Tests.DTO
{
    [TestClass()]
    public class ConfigResponseTests
    {
        [TestMethod()]
        public void DeserializeTest()
        {
            //Arrange
            var filename = PathUtil.CombineRunningDir(@"TestData\config_response.json");

            //Act
            var result = ConfigResponse.FromJsonFile(filename);


            //Assert
            Console.Write(result.ToJson());
        }
    }
}