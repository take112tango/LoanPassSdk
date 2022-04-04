using System;
using System.Collections.Generic;
using System.Data;
using Take112Tango.Libs.LoanPassSdk.Dynamic;
using Take112Tango.Libs.LoanPassSdk.Generated;
using Take112Tango.Libs.LoanPassSdk.Models;
using Take112Tango.Libs.LoanPassSdk.Models.Fields;
using Take112Tango.Libs.LoanPassSdk.Utils;

namespace Take112Tango.Libs.LoanPassSdk.Builders
{
    public class FieldValueMappingBuilder : FieldValueMapping.IBuilder
    {
        private readonly Dictionary<string, FieldValueMapping> _fieldsMap = new();

        public List<FieldValueMapping> Build()
        {
            return new(_fieldsMap.Values);
        }

        private FieldValueMapping.IBuilder AddField(KnownFieldId fieldId, AnyOfFieldValue field)
        {
            return AddField(KnownFieldIdExt.ToValue(fieldId), field);
        }

        private FieldValueMapping.IBuilder AddField(string fieldId, AnyOfFieldValue field)
        {
            _fieldsMap.TryGetValue(fieldId, out var fieldMap);
            if (fieldMap != null)
            {
                string stError = $"Cannot add duplicated field id({fieldId}). Existing field: {fieldMap}";
                throw new DuplicateNameException(stError);
            }

            fieldMap = new FieldValueMapping()
            {
                FieldId = fieldId,
                Value = field
            };
            _fieldsMap.Add(fieldId, fieldMap);
            return this;
        }

        #region Strong Typed
        public FieldValueMapping.IBuilderStrong Field(KnownFieldId fieldId, object value, params object[] extra)
        {
            var tag = KnownFieldIdExt.ToLPFieldTag(fieldId);
            switch (tag.Type)
            {
                case FieldValueTypeOpt.Enum:
                    string variantId;
                    if (value is Enum enumValue)
                    {
                        variantId = Helper.GetEnumMemberValue(enumValue);
                        if (variantId == null)
                            //ltang: Fallback
                            variantId = Enum.GetName(enumValue.GetType(), enumValue);
                    }
                    else if (value is bool bValue)
                        variantId = bValue ? "yes" : "no";
                    else
                        variantId = (string) value;

                    FieldEnum(fieldId, variantId);
                    break;
                case FieldValueTypeOpt.Number:
                    FieldNumber(fieldId, Convert.ToDouble(value));
                    break;
                case FieldValueTypeOpt.String:
                    FieldString(fieldId, (string)value);
                    break;
                case FieldValueTypeOpt.Duration:
                    if (extra.Length <= 0)
                        throw new ArgumentException($"DurationUnit was not set.");

                    DurationUnit unit = (DurationUnit)extra[0];
                    FieldDuration(fieldId, Convert.ToDouble(value), unit);
                    break;
                default:
                    throw new NotImplementedException($"{tag.Type} is unknown.");
            }
            return this;
        }

        public FieldValueMapping.IBuilderStrong FieldEnum(KnownFieldId fieldId, string variantId)
        {
            var tag = KnownFieldIdExt.ToLPFieldTag(fieldId)
                .Validate(FieldValueTypeOpt.Enum, fieldId.ToString());
            

            string fieldIdAsText = tag.Id;
            string enumTypeId = tag.RefId;
            variantId = variantId.ToVarNameLP();

            KnownEnumIdExt.ValidateVariantId(enumTypeId, variantId);


            return FieldEnum(fieldIdAsText, enumTypeId, variantId);
        }

        public FieldValueMapping.IBuilderStrong FieldNumber(KnownFieldId fieldId, double value)
        {
            var tag = KnownFieldIdExt.ToLPFieldTag(fieldId)
                .Validate(FieldValueTypeOpt.Number, fieldId.ToString());

            string fieldIdAsText = tag.Id;
            return FieldNumber(fieldIdAsText, value);

        }

        public FieldValueMapping.IBuilderStrong FieldString(KnownFieldId fieldId, string value)
        {
            var tag = KnownFieldIdExt.ToLPFieldTag(fieldId)
                .Validate(FieldValueTypeOpt.String, fieldId.ToString());

            string fieldIdAsText = tag.Id;
            return FieldString(fieldIdAsText, value);
        }

        public FieldValueMapping.IBuilderStrong FieldDuration(KnownFieldId fieldId, double count, DurationUnit unit)
        {
            var tag = KnownFieldIdExt.ToLPFieldTag(fieldId)
                .Validate(FieldValueTypeOpt.Duration, fieldId.ToString());

            string fieldIdAsText = tag.Id;
            return FieldDuration(fieldIdAsText, count, unit);
        }
        #endregion

        #region Weak Typed
        public FieldValueMapping.IBuilder FieldEnum(string fieldId, string enumTypeId, string variantId)
        {
            variantId = variantId.ToVarNameLP();
            var field = new FieldValueAsEnum() { EnumTypeId = enumTypeId, VariantId = variantId};
            return AddField(fieldId, field);
        }

        public FieldValueMapping.IBuilder FieldNumber(string fieldId, double value)
        {
            var field = new FieldValueAsNumber() { Value = value };
            return AddField(fieldId, field);
        }

        public FieldValueMapping.IBuilder FieldString(string fieldId, string value)
        {
            var field = new FieldValueAsString() { Value = value };
            return AddField(fieldId, field);
        }

        public FieldValueMapping.IBuilder FieldDuration(string fieldId, double count, DurationUnit unit)
        {
            var field = new FieldValueAsDuration() { Count = count, Unit = unit};
            return AddField(fieldId, field);
        }
        #endregion
    }
}
