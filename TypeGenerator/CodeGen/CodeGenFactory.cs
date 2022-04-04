

using System;


namespace Take112Tango.Libs.LoanPassSdk.TypeGenerator.CodeGen
{
    public static class CodeGenFactory
    {
        public static IFieldDefCodeGen CreateFieldDef(LanguageOpt language)
        {
            IFieldDefCodeGen codeGen = language switch
            {
                LanguageOpt.Cs => new CS.FieldDefCodeGen(),
                LanguageOpt.Java => new Java.FieldDefCodeGen(),
                //_ => throw new NotImplementedException(
                //    $"{nameof(FieldDefCodeGen)} for {language} is not supported yet."),

            };

            return codeGen;
        }

        public static IEnumDefCodeGen CreateEnumDef(LanguageOpt language)
        {
            IEnumDefCodeGen codeGen = language switch
            {
                LanguageOpt.Cs => new CS.EnumDefCodeGen(),
                LanguageOpt.Java => new Java.EnumDefCodeGen(),
                LanguageOpt.Gql => new GQL.EnumDefCodeGen(),
                //_ => throw new NotImplementedException($"{nameof(EnumDefCodeGen)} for {language} is not supported yet."),
            };
            return codeGen;
        }
    }
}
