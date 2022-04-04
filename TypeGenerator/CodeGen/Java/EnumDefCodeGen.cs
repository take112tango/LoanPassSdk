using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Take112Tango.Libs.LoanPassSdk.Models;
using Take112Tango.Libs.LoanPassSdk.Utils;

namespace Take112Tango.Libs.LoanPassSdk.TypeGenerator.CodeGen.Java
{
    public class EnumDefCodeGen : IEnumDefCodeGen
    {
        private const string Indent = "\t";
        private class Meta
        {
            public string EnumValue { get; init; }
            public HashSet<string> VariantIds { get; init; }
            public string EnumName { get; init; }
        }


        private static string ToCode(Meta meta)
        {
            var st = new StringBuilder();
            string temp = StringUtil.ToCSV(meta.VariantIds);
            st.AppendFormat($"{meta.EnumName} (\"{meta.EnumValue}\", Set.of({temp}))");
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
                code += string.Join($"\n{Indent},", bag) + ";";
                return code;
            });

            return task;
        }
    }
}
