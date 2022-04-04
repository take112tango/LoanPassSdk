

using Take112Tango.Libs.LoanPassSdk.Utils;

namespace Take112Tango.Libs.LoanPassSdk.TypeGenerator.Settings
{
    public static class LPConst
    {
        

        public static class Field
        {
            public const string ID_PREFIX = "field@";
            public  static readonly int ID_PREFIX_LENGTH = ID_PREFIX.Length;

            public const string CALC_ID_PREFIX = "calc@";
            public static readonly int CALC_ID_PREFIX_LENGTH = CALC_ID_PREFIX.Length;
        }

        public static string ToFieldIdLP(this string input)
        {
            input = input.ToVarNameLP();
            return $"{Field.ID_PREFIX}{input}";
        }
    }
}
