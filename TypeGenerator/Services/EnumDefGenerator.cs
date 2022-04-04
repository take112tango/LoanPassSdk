using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;
using Take112Tango.Libs.LoanPassSdk.Models;
using Take112Tango.Libs.LoanPassSdk.TypeGenerator.CodeGen;
using Take112Tango.Libs.LoanPassSdk.TypeGenerator.Settings;


namespace Take112Tango.Libs.LoanPassSdk.TypeGenerator.Services
{
    public class EnumDefGenerator
    {
        private readonly List<EnumType> _enumTypes;
        private readonly GenSettings _settings;
        private readonly IEnumDefCodeGen _codeGen;
        public EnumDefGenerator(IEnumerable<EnumType> enumTypes
                                    , GenSettings settings
                                    , IEnumDefCodeGen codeGen)
        {
            _enumTypes = new List<EnumType>(enumTypes);
            _settings = settings;
            _codeGen = codeGen;
        }

        private GenSettings.Common Shared => _settings.Shared;
        private GenSettings.EnumDef Enum => _settings.Enum;
        public string FileTemplate => Enum.FileTemplate;

        public async Task<string> ExecuteAsync()
        {
            var task1 = File.ReadAllTextAsync(FileTemplate);
            var task2 = _codeGen.ExecuteAsync(_enumTypes);

            string template = await task1;
            string code = await task2;

            var assembly = GetType().Assembly.GetName();

            code = template.Replace(Token.PACKAGE, Shared?.PackageName)
                .Replace(Token.GEN_TOOL_NAME, _codeGen.GetType().FullName)
                .Replace(Token.GEN_TOOL_VER, assembly.Version?.ToString())
                .Replace(Token.TIMESTAMP, DateTime.UtcNow.ToString(CultureInfo.InvariantCulture))
                .Replace(Token.CLASS, Enum.ClassName)
                .Replace(Token.X1, code);

            return code;
        }
    }
}
