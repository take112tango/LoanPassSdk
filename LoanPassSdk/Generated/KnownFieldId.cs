using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Take112Tango.Libs.LoanPassSdk.Dynamic;
using Take112Tango.Libs.LoanPassSdk.Models.Fields;


// ReSharper disable InconsistentNaming
// ReSharper disable IdentifierTypo
// ReSharper disable UnusedMember.Global
// 
// This source code was auto-generated in 12/30/2021 07:04:46
// 
namespace Take112Tango.Libs.LoanPassSdk.Generated
{
	/// <summary>
	/// Field definitions auto generated from LoanPass API for strong type checking
	/// </summary>
	[GeneratedCode("Take112Tango.Libs.LoanPassSdk.TypeGenerator.CodeGen.CS.FieldDefCodeGen", "1.0.0.0")]
	[JsonConverter(typeof(StringEnumConverter))]
	public enum KnownFieldId
	{
		[EnumMember(Value = "desired-loan-term")]
		[LPFieldTag("field@desired-loan-term", FieldValueTypeOpt.Duration)]
		DESIRED_LOAN_TERM
		, [EnumMember(Value = "loan-purpose")]
		[LPFieldTag("field@loan-purpose", FieldValueTypeOpt.Enum, "loan-purpose")]
		LOAN_PURPOSE
		, [EnumMember(Value = "state")]
		[LPFieldTag("field@state", FieldValueTypeOpt.String)]
		STATE
		, [EnumMember(Value = "base-loan-amount")]
		[LPFieldTag("field@base-loan-amount", FieldValueTypeOpt.Number)]
		BASE_LOAN_AMOUNT
		, [EnumMember(Value = "after-repair-value-arv")]
		[LPFieldTag("field@after-repair-value-arv", FieldValueTypeOpt.Number)]
		AFTER_REPAIR_VALUE_ARV

	}

	public static class KnownFieldIdExt
	{
		private static readonly Dictionary<string, KnownFieldId> Value2Enum;
		private static readonly Dictionary<KnownFieldId, string> Enum2Value;
		private static readonly Dictionary<KnownFieldId, LPFieldTagAttribute> Enum2LPFieldTag;

		static KnownFieldIdExt()
		{
			var values = Enum.GetValues(typeof(KnownFieldId));

			Value2Enum = Helper.MapValue2Obj<KnownFieldId>(values);
			Enum2Value = Helper.MapObj2Value<KnownFieldId>(values);
			Enum2LPFieldTag = Helper.MapObj2LPFieldTag<KnownFieldId>(values);
		}

		public static KnownFieldId? ToEnum(string key)
		{
			return Value2Enum.GetValueOrDefault(key);
		}

		public static string ToValue(KnownFieldId key)
		{
			return Enum2Value.GetValueOrDefault(key);
		}

		public static LPFieldTagAttribute ToLPFieldTag(KnownFieldId key)
		{
			return Enum2LPFieldTag.GetValueOrDefault(key);
		}

		public static LPFieldTagAttribute Validate(this LPFieldTagAttribute tag, FieldValueTypeOpt expectedType, string context)
		{
			if (tag == null)
				throw new ArgumentNullException($"{context} tag cannot be null.");
			if (tag.Type != expectedType)
				throw new ArgumentException($"{context} tag expects type of {expectedType} vs. actual type of {tag.Type}");
			return tag;
		}

	}
}
