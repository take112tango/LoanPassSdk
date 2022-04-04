using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Take112Tango.Libs.LoanPassSdk.DTO;
using Take112Tango.Libs.LoanPassSdk.TypeGenerator.CodeGen;
using Take112Tango.Libs.LoanPassSdk.TypeGenerator.Services;
using Take112Tango.Libs.LoanPassSdk.Utils;

namespace Take112Tango.Libs.LoanPassSdk.TypeGenerator.Tests.Services
{
    [TestClass()]
    public class EnumDefGeneratorTests
    {
        private static AppConfig _appConfig;
        private static ConfigResponse _response;

        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            _appConfig = JsonUtil.FromJsonFile<AppConfig>(PathUtil.CombineRunningDir(@"appsettings.json"));

            _response = CreateConfigResponse();
            
        }


        internal static ConfigResponse CreateConfigResponse()
        {
            var filename = PathUtil.CombineRunningDir(@"TestData\config_response.json");
            return ConfigResponse.FromJsonFile(filename);
        }

        [TestMethod()]
        public async Task CS_ExecuteAsyncTest()
        {
            //Arrange
            LanguageOpt language = LanguageOpt.Cs;
            var generator = new EnumDefGenerator(_response.Enumerations
                , _appConfig.Generators.GetSettings(language)
                , CodeGenFactory.CreateEnumDef(language));

            //Act
            var result = await generator.ExecuteAsync();

            //Assert
            Console.WriteLine(result);
        }

        [TestMethod()]
        public async Task Java_ExecuteAsyncTest()
        {
            //Arrange
            LanguageOpt language = LanguageOpt.Java;

            var generator = new EnumDefGenerator(_response.Enumerations
                , _appConfig.Generators.GetSettings(language)
                , CodeGenFactory.CreateEnumDef(language));

            //Act
            var result = await generator.ExecuteAsync();

            //Assert
            Console.WriteLine(result);
        }

        [TestMethod()]
        public async Task GQL_ExecuteAsyncTest()
        {
            //Arrange
            LanguageOpt language = LanguageOpt.Gql;

            var generator = new EnumDefGenerator(_response.Enumerations
                , _appConfig.Generators.GetSettings(language)
                , CodeGenFactory.CreateEnumDef(language));

            //Act
            var result = await generator.ExecuteAsync();

            //Assert
            Console.WriteLine(result);
        }
    }
}