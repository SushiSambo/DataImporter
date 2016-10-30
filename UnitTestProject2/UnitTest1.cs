using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataImporter;
using System.Collections.Generic;
using Moq;
using System.Text;
using System.IO;
using DataImporter.interfaces;
using System.Linq;

namespace UnitTestProject2
{
    [TestClass]
    public class TestImporter
    {
        [TestMethod]
        public void TestGivenData()
        {
            var validator = new Mock<IRowValidator>();
            validator.Setup(p => p.IsValid(It.IsAny<Order>())).Returns(new OrderState() { IsValid = true });
            
            var columns = new List<ColumnConfiguration>();
            columns.Add(new ColumnConfiguration()
            {
                SourceColumnName = "Make",
                DestinationColumName = "Make",
                ActionToPerform = (obj, order) => { order.Make = obj.ToString(); }

            });
            columns.Add(new ColumnConfiguration() { SourceColumnName = "Model", 
                DestinationColumName = "Model",
                ActionToPerform = (obj, order) => { order.Model = obj.ToString(); }                
            });

            var readerStrategy = new CsvReaderStrategy(
                new FileConfiguration() { Delimiter = ",", FileName = "blah", HasFieldsEnclosedInQuotes = true, Header = "Make,Model" },
                validator.Object,
                columns
                );
            
            var builder = new StringBuilder();
            builder.AppendLine("Make,Model");
            builder.AppendLine("BMW,3i8");

            var expectedList = new List<Order>() { new Order() { Make = "BMW", Model = "3i8", OrderState = new OrderState { IsValid = true} } };

            using (var streamReader = new StreamReader(
                new MemoryStream(Encoding.ASCII.GetBytes(builder.ToString()))))
            {
                var orderList = readerStrategy.Read(streamReader);
                int i=0;
                foreach (var item in orderList)
                {
                    Assert.AreEqual(expectedList[i++], item);
                }
            }
        }
        //Other tests should include for invalid rows, failure
        //Todo testing for Writer, creating an OrderRepository
    }
}
   