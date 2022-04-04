using Microsoft.VisualStudio.TestTools.UnitTesting;
using Take112Tango.Libs.LoanPassSdk.Utils;

namespace Take112Tango.Libs.LoanPassSdk.Tests.Utils
{
    [TestClass()]
    public class LPUtilTests
    {
        [TestMethod()]
        public void ToVarNameTest()
        {
            //Arrange
            string input = "three-month-bank-statement";
            string expected = "THREE_MONTH_BANK_STATEMENT";

            //Act
            string result = input.ToVarName();


            //Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void ToVarNameTest_With_Prefix_Int()
        {
            //Arrange
            string input = "3-month-bank-statement";
            string expected = "_3_MONTH_BANK_STATEMENT";

            //Act
            string result = input.ToVarName();


            //Assert
            Assert.AreEqual(expected, result);
        }


        [TestMethod()]
        public void ToVarNameLPTest()
        {
            //Arrange
            string input = "THREE_MONTH_BANK_STATEMENT";
            string expected = "three-month-bank-statement";

            //Act
            string result = input.ToVarNameLP();


            //Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void ToVarNameLPTest_With_Prefix_Separator()
        {
            //Arrange
            string input = "_3_MONTH_BANK_STATEMENT";
            string expected = "3-month-bank-statement";

            //Act
            string result = input.ToVarNameLP();


            //Assert
            Assert.AreEqual(expected, result);
        }
    }
}