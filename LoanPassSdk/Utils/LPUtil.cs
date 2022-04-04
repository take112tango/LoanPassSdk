

using System;

namespace Take112Tango.Libs.LoanPassSdk.Utils
{
    public static class LPUtil
    {
        private const char NAME_SEPARATOR_LP = '-';
        private const char NAME_SEPARATOR_NOT_LP = '_';

        private static bool IsVarNameStartingWithInt(string input, char separator)
        {
            string[] words = input.Split(separator);
            if (words.Length <= 0)
                return false;

            string firstWord = words[0];
            return int.TryParse(firstWord, out _); ;
        }

        public static string ToVarName(this string input)
        {
            string output = input
                .ToUpper()
                .Replace(NAME_SEPARATOR_LP, NAME_SEPARATOR_NOT_LP);

            if (IsVarNameStartingWithInt(output, NAME_SEPARATOR_NOT_LP))
                output = NAME_SEPARATOR_NOT_LP + output;
            
            return output;
        }

        public static string ToVarNameLP(this string input)
        {
            int index = input.IndexOf(NAME_SEPARATOR_NOT_LP);
            if (index == 0)
                input = input.Substring(1);

            string output = input
                .ToLower()
                .Replace(NAME_SEPARATOR_NOT_LP, NAME_SEPARATOR_LP);
            return output;
        }
    }
}
