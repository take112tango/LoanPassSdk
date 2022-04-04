using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Take112Tango.Libs.LoanPassSdk.Generated;
using Take112Tango.Libs.LoanPassSdk.Models;
using Take112Tango.Libs.LoanPassSdk.Utils;

namespace Take112Tango.Libs.LoanPassSdk.Tests.Builders
{
    [TestClass()]
    public class FieldValueMappingBuilderTests
    {
        #region Strong Typed

        [TestMethod()]
        public void BuildStrongTypedTest_OK()
        {
            //Arrange
            FieldValueMapping.IBuilderStrong builder = FieldValueMapping.BuilderStrong();

            builder.FieldEnum(KnownFieldId.LOAN_PURPOSE, "purchase")
                .FieldNumber(KnownFieldId.BASE_LOAN_AMOUNT, 12)
                .FieldString(KnownFieldId.STATE, "ca")
                .FieldDuration(KnownFieldId.DESIRED_LOAN_TERM, 30, DurationUnit.Years);

            //Act
            List<FieldValueMapping> fields = builder.Build();

            //Assert
            Console.WriteLine(fields.ToJson());

            Assert.IsNotNull(fields);
            Assert.AreEqual(4, fields.Count);
        }

        [TestMethod()]
        [ExpectedException(typeof(KeyNotFoundException), "Invalid variant id.")]
        public void BuildStrongTypedTest_Enum_Invalid_VariantId()
        {
            //Arrange
            FieldValueMapping.IBuilderStrong builder = FieldValueMapping.BuilderStrong();

            //Act
            //Assert
            builder.FieldEnum(KnownFieldId.LOAN_PURPOSE, "whatever");
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException), "Invalid type.")]
        public void BuildStrongTypedTest_String_Invalid_Type()
        {
            //Arrange
            FieldValueMapping.IBuilderStrong builder = FieldValueMapping.BuilderStrong();

            //Act
            //Assert
            builder.FieldString(KnownFieldId.BASE_LOAN_AMOUNT, "whatever");
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException), "Invalid type.")]
        public void BuildStrongTypedTest_Number_Invalid_Type()
        {
            //Arrange
            FieldValueMapping.IBuilderStrong builder = FieldValueMapping.BuilderStrong();

            //Act
            //Assert
            builder.FieldNumber(KnownFieldId.LOAN_PURPOSE, 123);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException), "Invalid type.")]
        public void BuildStrongTypedTest_Duration_Invalid_Type()
        {
            //Arrange
            FieldValueMapping.IBuilderStrong builder = FieldValueMapping.BuilderStrong();

            //Act
            //Assert
            builder.FieldDuration(KnownFieldId.STATE, 30, DurationUnit.Years);
        }

        [TestMethod()]
        [ExpectedException(typeof(DuplicateNameException), "Invalid variant id.")]
        public void BuildStrongTypedTest_Duplication()
        {
            //Arrange
            FieldValueMapping.IBuilderStrong builder = FieldValueMapping.BuilderStrong();

            //Act
            //Assert
            builder.FieldString(KnownFieldId.STATE, "whatever")
                .FieldString(KnownFieldId.STATE, "whatever");
        }
        #endregion

        #region Weak Typed
        [TestMethod()]
        public void BuildWeakTypedTest_OK()
        {
            //Arrange
            FieldValueMapping.IBuilder builder = FieldValueMapping.Builder();

            builder.FieldEnum("field@loan-purpose", "loan-purpose","purchase")
                .FieldNumber("field@base-loan-amount", 12)
                .FieldString("field@state", "ca")
                .FieldDuration("field@desired-loan-term", 30, DurationUnit.Years);

            //Act
            List<FieldValueMapping> fields = builder.Build();

            //Assert
            Console.WriteLine(fields.ToJson());

            Assert.IsNotNull(fields);
            Assert.AreEqual(4, fields.Count);
        }
        #endregion
    }
}