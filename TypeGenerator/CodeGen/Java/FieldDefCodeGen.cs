using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Take112Tango.Libs.LoanPassSdk.Models;
using Take112Tango.Libs.LoanPassSdk.Models.Fields;
using Take112Tango.Libs.LoanPassSdk.Utils;
using static Take112Tango.Libs.LoanPassSdk.TypeGenerator.Settings.LPConst.Field;

namespace Take112Tango.Libs.LoanPassSdk.TypeGenerator.CodeGen.Java
{
    public class FieldDefCodeGen : IFieldDefCodeGen
    {
        private const string Indent = "\t";
        private class Meta
        {
            public string EnumValue { get; init; }
            public string FieldId { get; init; }
            public FieldValueTypeOpt FieldType { get; init; }
            public string EnumRefId { get; init; }
            public string EnumName { get; init; }
        }

        private static string ToCode(Meta meta)
        {
            var st = new StringBuilder();
            st.AppendFormat($"{meta.EnumName} (\"{meta.FieldId}\", {meta.FieldType}");
            if (!string.IsNullOrEmpty(meta.EnumRefId))
                st.AppendFormat($", \"{meta.EnumRefId}\"");

            st.AppendFormat(")");
            return st.ToString();
        }

        public Task<string> ExecuteAsync(IEnumerable<FieldDefinition> fields)
        {
            var task = Task.Run( () =>
            {
                var bag = new ConcurrentBag<string>();
                Parallel.ForEach(fields, item =>
                {
                    var valueType = item.ValueType;
                    string fieldId = item.Id;
                    string enumValue = fieldId[ID_PREFIX_LENGTH..];


                    string enumTypeId = null;
                    if (valueType is FieldValueTypeAsEnum valueTypeAsEnum)
                        enumTypeId = valueTypeAsEnum.EnumTypeId;

                    var meta = new Meta()
                    {
                        EnumValue = enumValue,
                        FieldId = fieldId,
                        FieldType = valueType.Type,
                        EnumRefId = enumTypeId,
                        EnumName = enumValue.ToVarName()
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
