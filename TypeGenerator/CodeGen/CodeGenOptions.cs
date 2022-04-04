
using System;

namespace Take112Tango.Libs.LoanPassSdk.TypeGenerator.CodeGen
{
    public enum LanguageOpt
    {
        Cs, //C#
        Java,
        Gql, //GraphQL
        Ts, //TypeScript
    }

    [Flags]
    public enum TypeDefTargets
    {
        None = 0,
        Enum = 1 << 0,
        Field = 1 << 1,
        All = 0xFFFF,
    }
}
