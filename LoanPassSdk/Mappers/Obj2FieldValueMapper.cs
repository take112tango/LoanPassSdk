
using System;
using System.Collections.Generic;
using System.Reflection;
using Take112Tango.Libs.LoanPassSdk.Generated;
using Take112Tango.Libs.LoanPassSdk.Models;

namespace Take112Tango.Libs.LoanPassSdk.Mappers
{
    public class Obj2FieldValueMapper
    {
        private static readonly Type[] DefaultOrderedTargetAttrTypes =
        {
            typeof(PropTagNestedAttribute),
            typeof(PropTagAttribute),
            typeof(PropTagDuraAttribute)
        };

        private readonly List<AnnotatedTarget<PropertyInfo>> _targets;

        public Obj2FieldValueMapper(object source) : this(source, null)
        {

        }

        public Obj2FieldValueMapper(object source, Type[] targetAttrTypes)
        {
            targetAttrTypes ??= DefaultOrderedTargetAttrTypes;
            _targets = Helper.BuildTargets(source, targetAttrTypes);
        }


        private static void AddField(AnnotatedTarget<PropertyInfo> target, FieldValueMapping.IBuilderStrong builder)
        {
            KnownFieldId fieldId = ((PropTagAttribute)target.Attr).Field;

            object value = target.Value;
            if (value == null)
                return;

            object extra = null;
            if (target.Attr is PropTagDuraAttribute attribute)
                extra = attribute.Unit;

            builder.Field(fieldId, value, extra);
        }

        public List<FieldValueMapping> Map()
        {
            FieldValueMapping.IBuilderStrong builder = FieldValueMapping.Builder();

            foreach (var target in _targets)
            {
                AddField(target, builder);
            }

            List<FieldValueMapping> result = builder.Build();
            return result;

        }

    }
}
