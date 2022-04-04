

using System;
using System.Collections.Generic;
using System.Text;

namespace Take112Tango.Libs.LoanPassSdk.Utils
{
    public static class StringUtil
    {
        public static string ToCSV<T>(IEnumerable<T> values, bool bDedup = true)
        {
            if (values == null)
                return null;

            var sb = new StringBuilder();

            string format = "{0}";
            if (typeof(T) == typeof(string) || typeof(T) == typeof(char))
            {
                format = "\"{0}\"";
            }

            if (!bDedup)
            {
                foreach (T value in values)
                {
                    if (sb.Length > 0)
                    {
                        sb.Append(",");
                    }
                    sb.AppendFormat(format, value);
                }
            }
            else
            {
                var hashSet = new HashSet<T>();
                foreach (T value in values)
                {
                    if (hashSet.Contains(value))
                        continue;
                    if (sb.Length > 0)
                    {
                        sb.Append(",");
                    }
                    sb.AppendFormat(format, value);
                    hashSet.Add(value);
                }
            }


            return sb.ToString().Trim();
        }


        public static HashSet<string> ToStringHashSet(this string text, string postfix = null)
        {
            text = text.Trim();
            if (string.IsNullOrEmpty(text))
                return new HashSet<string>();
            var stArray = text.Split(new char[] { ',', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            var stList = new HashSet<string>();
            foreach (var st in stArray)
            {
                var stTrim = st.Trim();
                if (string.IsNullOrEmpty(stTrim))
                    continue;
                if (!string.IsNullOrEmpty(postfix))
                    stTrim = $"{stTrim}{postfix}";
                if (stList.Contains(stTrim))
                    continue;

                stList.Add(stTrim);
            }
            return stList;
        }
    }
}
