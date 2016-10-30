using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataImporter;
using System.Collections.Generic;

namespace UnitTestProject2
{
    [TestClass]
    public class TestImporter
    {
        [TestMethod]
        public void TestGivenData()
        {
            var readerStrategy = new CsvReaderStrategy();
            //Need to mock out the TextFieldReader here, and ColumnConfig
            //readerStrategy.Read(
            //var builder = new StringBuilder 
            var testList = new List<Order>() { new Order(){ Make = "B<W", Model = "3i8"}};
            //Assert(readerStrategy.Read(), testList);
        }
        //Other tests should include for invalid rows, failures
        //Todo testing for Writer, creating an OrderRepository
    }
}
   