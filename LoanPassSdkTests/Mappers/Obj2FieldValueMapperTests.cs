using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Take112Tango.Libs.LoanPassSdk.Generated;
using Take112Tango.Libs.LoanPassSdk.Mappers;
using Take112Tango.Libs.LoanPassSdk.Models;
using Take112Tango.Libs.LoanPassSdk.Utils;

namespace Take112Tango.Libs.LoanPassSdk.Tests.Mappers
{
    [TestClass()]
    public class Obj2FieldValueMapperTests
    {
        internal enum LoanPurposeOpt
        {
            PURCHASE,
            REFINANCE
        }

        internal class PocoNested
        {
            [PropTag(KnownFieldId.AFTER_REPAIR_VALUE_ARV)]
            public double? AfterRepairValue { get; set; } = 88;
        }

        internal class Poco
        {
            [PropTag(KnownFieldId.LOAN_PURPOSE)] 
            public LoanPurposeOpt LoanPurpose { get; set; } = LoanPurposeOpt.PURCHASE;

            [PropTag(KnownFieldId.STATE)]
            public string State { get; set; } = "CA";

            [PropTag(KnownFieldId.BASE_LOAN_AMOUNT)]
            public double? LoanAmount { get; set; } = 99;

            [PropTagDura(KnownFieldId.DESIRED_LOAN_TERM, DurationUnit.Years)]
            public double? LoanTerm { get; set; } = 20;

            [PropTagNested] 
            public PocoNested Nested { get; } = new PocoNested();
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException), "Contains no attribute.")]
        public void MapTest_No_Attribute()
        {
            //Arrange
            //Action
            //Assert
            _ = new Obj2FieldValueMapper(new object());
        }

        internal static List<FieldValueMapping> CreateFields(object poco)
        {
            var mapper = new Obj2FieldValueMapper(poco);
            return mapper.Map();
        }

        [TestMethod()]
        public void MapTest()
        {
            //Arrange
            //Act
            var result = CreateFields(new Poco());

            //Assert
            Console.WriteLine(result.ToJson());

            Assert.IsNotNull(result);
            Assert.AreEqual(5, result.Count);
        }
    }
}