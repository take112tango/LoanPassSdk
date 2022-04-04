using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Take112Tango.Libs.LoanPassSdk.Dynamic;
using Take112Tango.Libs.LoanPassSdk.Generated;
using Take112Tango.Libs.LoanPassSdk.Utils;

namespace Take112Tango.Libs.LoanPassSdk.Tests.Dynamic
{
    [TestClass()]
    public class KnownEnumIdExtTests
    {
        [TestMethod()]
        public void ToEnumTest()
        {
            //Arrange
            KnownEnumId expected = KnownEnumId.LOAN_PURPOSE;
            string key = Helper.GetEnumMemberValue(expected);

            //Act
            KnownEnumId? result = KnownEnumIdExt.ToEnum(key);

            //Assert
            Assert.IsNotNull(result);
            Console.Write(result);
            Assert.AreEqual(expected, result.Value);
        }

        [TestMethod()]
        public void ToValueTest()
        {
            //Arrange
            KnownEnumId key = KnownEnumId.LOAN_PURPOSE;
            string expected = Helper.GetEnumMemberValue(key);


            //Act
            string result = KnownEnumIdExt.ToValue(key);

            //Assert
            Assert.IsNotNull(result);
            Console.Write(result);
            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void ToVariantIdsTest()
        {
            //Arrange
            KnownEnumId enumId = KnownEnumId.LOAN_PURPOSE;
            string key = Helper.GetEnumMemberValue(enumId);

            //Act
            HashSet<string> result = KnownEnumIdExt.ToVariantIds(key);

            //Assert
            Assert.IsNotNull(result);
            Console.Write(result.ToJson());
        }
    }
}