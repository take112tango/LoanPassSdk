
using System;
using System.Collections.Generic;

namespace Take112Tango.Libs.LoanPassSdk.Utils
{
    public static class EnumUtil
    {
        public static int TextsToEnumFlags(Type enumType, IEnumerable<string> texts, int flagNone)
        {
            int flags = flagNone;
            foreach (var s in texts)
            {
                int enumValue = (int) Enum.Parse(enumType, s, true);
                flags = flags | enumValue;
            }
            return flags;
        }
    }
}
