
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Take112Tango.Libs.LoanPassSdk.Generated;
using Take112Tango.Libs.LoanPassSdk.Models;

namespace Take112Tango.Libs.LoanPassSdk.Mappers
{
    public class FieldValue2ObjMapper
    {
        private static readonly Type[] DefaultOrderedTargetAttrTypes =
        {
            typeof(PropTagNestedAttribute),
            typeof(PropTagAttribute),
            typeof(PropTagDuraAttribute)
        };

        private readonly List<AnnotatedTarget<PropertyInfo>> _targets;

        public FieldValue2ObjMapper(object source) : this(source, null)
        {

        }

        public FieldValue2ObjMapper(object source, Type[] targetAttrTypes)
        {
            targetAttrTypes ??= DefaultOrderedTargetAttrTypes;
            _targets = Helper.BuildTargets(source, targetAttrTypes, false);
        }

        public int Map(IEnumerable<FieldValueMapping> fields)
        {
            Dictionary<string, FieldValueMapping> fieldById 
                = fields.ToDictionary(field => field.FieldId, field => field);
            return Map(fieldById);
        }

        public int Map(Dictionary<string, FieldValueMapping> fieldById)
        {
            int countUpdate = 0;
            foreach (AnnotatedTarget<PropertyInfo> target in _targets)
            {
                KnownFieldId knownField = ((PropTagAttribute)target.Attr).Field;
                string fieldId = KnownFieldIdExt.ToValue(knownField);
                fieldById.TryGetValue(fieldId, out var field);
                if (field == null)
                    continue;

                UpdateTarget(target, field);
                countUpdate++;
            }
            return countUpdate;
        }


        private static void UpdateTarget(AnnotatedTarget<PropertyInfo> target, FieldValueMapping field)
        {
            object value = field.Value.GetFieldValue();
            target.Member.SetValue(value, target.Source);
        }

        public static T Create<T>(IEnumerable<FieldValueMapping> fields) where T : new()
        {
            var poco = new T();
            var mapper = new FieldValue2ObjMapper(poco);
            mapper.Map(fields);
            return poco;
        }

        public static T Create<T>(Dictionary<string, FieldValueMapping> fieldById) where T : new()
        {
            var poco = new T();
            var mapper = new FieldValue2ObjMapper(poco);
            mapper.Map(fieldById);
            return poco;
        }
    }
}
