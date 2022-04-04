using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Take112Tango.Libs.LoanPassSdk.Models;
using Take112Tango.Libs.LoanPassSdk.Utils;

namespace Take112Tango.Libs.LoanPassSdk.TypeGenerator.CodeGen.CS
{
    public class EnumDefCodeGen : IEnumDefCodeGen
    {
        private const string Indent = "\t\t";
        private class Meta
        {
            public string EnumValue { get; init; }
            public HashSet<string> VariantIds { get; init; }
            public string EnumName { get; init; }
        }


        /// <summary>
        /// [EnumMember(Value = "borrower-type")]
        /// [TextTags("VariantIds", "1", "2")]
        /// BorrowerType
        /// </summary>
        /// <param name="meta"></param>
        /// <returns></returns>
        private static string ToCode(Meta meta)
        {
            var st = new StringBuilder();
            st.AppendFormat($"[EnumMember(Value = \"{meta.EnumValue}\")]");
            st.AppendLine();

            string temp = StringUtil.ToCSV(meta.VariantIds);
            st.AppendFormat($"{Indent}[TextTags(\"VariantIds\", {temp})]");
            st.AppendLine();

            st.AppendFormat($"{Indent}{meta.EnumName}");
            st.AppendLine();

            return st.ToString();
        }

        public Task<string> ExecuteAsync(IEnumerable<EnumType> enumTypes)
        {
            var task = Task.Run( () =>
            {
                var bag = new ConcurrentBag<string>();
                Parallel.ForEach(enumTypes, item =>
                {
                    var variantIds = new HashSet<string>
                        (item.Variants.Select(variant => variant.Id).Distinct());

                    var meta = new Meta()
                    {
                        EnumValue = item.Id,
                        VariantIds = variantIds,
                        EnumName = item.Id.ToVarName()
                    };

                    string st = ToCode(meta);
                    bag.Add(st);
                });


                string code = $"//Count: {bag.Count}\n{Indent}";
                code += string.Join($"{Indent},", bag);
                return code;
            });

            return task;
        }
    }
}
