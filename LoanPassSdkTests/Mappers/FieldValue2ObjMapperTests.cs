using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Take112Tango.Libs.LoanPassSdk.Mappers;
using Take112Tango.Libs.LoanPassSdk.Utils;

namespace Take112Tango.Libs.LoanPassSdk.Tests.Mappers
{
    [TestClass()]
    public class FieldValue2ObjMapperTests
    {
        [TestMethod()]
        public void MapTest()
        {
            //Arrange
            var source = new Obj2FieldValueMapperTests.Poco();
            var fields = Obj2FieldValueMapperTests.CreateFields(source);


            //Act
            var result = FieldValue2ObjMapper.Create<Obj2FieldValueMapperTests.Poco>(fields);


            //Assert
            string stSource = source.ToJson();
            string stResult = result.ToJson();

            Console.WriteLine(stSource);
            Console.WriteLine(stResult);


            Assert.AreEqual(stResult, stResult);
        }
    }
}