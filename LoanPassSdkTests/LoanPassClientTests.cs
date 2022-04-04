#define NO_LOANPASS_API_KEY

using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Take112Tango.Libs.LoanPassSdk.Tests.DTO;
using Take112Tango.Libs.LoanPassSdk.Utils;

namespace Take112Tango.Libs.LoanPassSdk.Tests
{
    [TestClass()]
    public class LoanPassClientTests
    {
        private const string LOANPASS_API_KEY = ""; //Bearer...Put your API key from LoanPass here
        private static ILoanPassClient _client;

        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            var settings = new Settings(LOANPASS_API_KEY);
            _client = new LoanPassClient(settings);
        }


#if NO_LOANPASS_API_KEY
        [Ignore("LOANPASS_API_KEY not found!")]
#endif
        [TestMethod()]
        public async Task GetConfigurationAsyncTest()
        {
            //Arrange
            //Act
            var result = await _client.GetConfigurationAsync();

            //Assert
            Console.Write(result.ToJson());
        }

#if NO_LOANPASS_API_KEY
        [Ignore("LOANPASS_API_KEY not found!")]
#endif
        [TestMethod()]        
        public async Task ExecSummaryAsyncTest()
        {
            //Arrange
            var request = ExecSummaryRequestTests.CreateRequest();

            //Act
            var result = await _client.ExecSummaryAsync(request);

            //Assert
            Console.Write(result.ToJson());
        }

#if NO_LOANPASS_API_KEY
        [Ignore("LOANPASS_API_KEY not found!")]
#endif
        [TestMethod()]        
        public async Task ExecProductAsyncTest()
        {
            //Arrange
            var request = ExecProductRequestTests.CreateRequest();

            //Act
            var result = await _client.ExecProductAsync(request);

            //Assert
            Console.Write(result.ToJson());
        }
    }
}