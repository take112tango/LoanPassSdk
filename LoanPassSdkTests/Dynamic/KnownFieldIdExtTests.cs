using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Take112Tango.Libs.LoanPassSdk.Dynamic;
using Take112Tango.Libs.LoanPassSdk.Generated;

namespace Take112Tango.Libs.LoanPassSdk.Tests.Dynamic
{
    [TestClass()]
    public class KnownFieldIdExtTests
    {
        [TestMethod()]
        public void ToEnumTest()
        {
            //Arrange
            var expected = KnownFieldId.LOAN_PURPOSE;
            string key = Helper.GetEnumMemberValue(expected);

            //Act
            KnownFieldId? result = KnownFieldIdExt.ToEnum(key);

            //Assert
            Assert.IsNotNull(result);
            Console.Write(result);
            Assert.AreEqual(expected, result.Value);
        }

        [TestMethod()]
        public void ToValueTest()
        {
            //Arrange
            var key = KnownFieldId.LOAN_PURPOSE;
            string expected = Helper.GetEnumMemberValue(key);

            //Act
            string result = KnownFieldIdExt.ToValue(key);

            //Assert
            Assert.IsNotNull(result);
            Console.Write(result);
            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void ToLPFieldTagTest()
        {
            //Arrange
            var key = KnownFieldId.LOAN_PURPOSE;
            string expected = Helper.GetLPFieldTagAttribute(key).RefId;

            //Act
            string result = KnownFieldIdExt.ToLPFieldTag(key).RefId;

            //Assert
            Assert.IsNotNull(result);
            Console.Write(result);
            Assert.AreEqual(expected, result);
        }
    }
}