
using System;
using Take112Tango.Libs.LoanPassSdk.TypeGenerator.CodeGen;

namespace Take112Tango.Libs.LoanPassSdk.TypeGenerator.Settings
{
    public class Generators
    {
        public GenSettings CS { get; set; }
        public GenSettings Java { get; set; }
        public GenSettings GQL { get; set; }

        public GenSettings GetSettings(LanguageOpt language) => language switch
        {
            LanguageOpt.Cs => CS,
            LanguageOpt.Java => Java,
            LanguageOpt.Gql => GQL,
            _ => throw new NotImplementedException($"{language} not implemented!")
        };

    }
}
