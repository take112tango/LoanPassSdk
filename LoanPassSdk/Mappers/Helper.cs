using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Take112Tango.Libs.LoanPassSdk.Models;
using Take112Tango.Libs.LoanPassSdk.Models.Fields;

namespace Take112Tango.Libs.LoanPassSdk.Mappers
{
    public static class Helper
    {
        public static object GetFieldValue(this AnyOfFieldValue field)
        {
            if (field == null)
                return null;

            object value = null;
            switch (field.Type)
            {
                case FieldValueOpt.Number:
                    FieldValueAsNumber numberField = (FieldValueAsNumber)field;
                    value = numberField.Value;
                    break;
                case FieldValueOpt.String:
                    FieldValueAsString textField = (FieldValueAsString)field;
                    value = textField.Value;
                    break;
                case FieldValueOpt.Enum:
                    FieldValueAsEnum enumField = (FieldValueAsEnum)field;
                    value = enumField.VariantId;
                    break;
                case FieldValueOpt.Duration:
                    FieldValueAsDuration duraField = (FieldValueAsDuration)field;
                    value = duraField.Count;
                    break;
                default:
                    throw new NotImplementedException($"Unsupported type {field.Type}");
            }
            return value;
        }

        private static Attribute GetAttribute(MemberInfo member, Type[] targetAttrTypes)
        {
            foreach (Type attrType in targetAttrTypes)
            {
                var targetAttr = member.GetCustomAttribute(attrType);
                if (targetAttr != null)
                    return targetAttr;
            }
            return null;
        }

        public static List<AnnotatedTarget<PropertyInfo>> BuildTargets(object sourceTop
            , Type[] targetAttrTypes
            , bool bIgnoreFieldValueNull = true)
        {
            var sourceStack = new Stack<object>();
            sourceStack.Push(sourceTop);

            var result = new List<AnnotatedTarget<PropertyInfo>>();

            while (sourceStack.Count > 0)
            {
                object source = sourceStack.Pop();
                if (source == null)
                    continue;

                PropertyInfo[] props = source.GetType().GetProperties();
                foreach (var prop in props)
                {
                    var targetAttr = GetAttribute(prop, targetAttrTypes);
                    if (targetAttr == null)
                        continue;

                    object value = prop.GetValue(source);
                    if (bIgnoreFieldValueNull && value == null)
                        continue;

                    if (targetAttr is PropTagNestedAttribute)
                    {
                        if (value != null)
                            sourceStack.Push(value);
                    }
                    else
                    {
                        var target = new AnnotatedTarget<PropertyInfo>
                        {
                            Source = source,
                            Member = prop,
                            Attr = targetAttr,
                            Value = value

                        };
                        result.Add(target);
                    }
                }
            }

            if (result.Count <= 0)
            {
                string st = string.Join(", ", targetAttrTypes.Select(type => nameof(type)));
                throw new ArgumentException
                    ($"{nameof(sourceTop)} contains no attribute in {st}");
            }

            return result;
        }
    }
}
