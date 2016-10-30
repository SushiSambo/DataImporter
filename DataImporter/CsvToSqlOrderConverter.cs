using DataImporter.interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataImporter
{
    /// <summary>
    /// This code merely acts as bridge between the reader and writer
    /// </summary>
    public class CsvToSqlOrderConverter : IOrderConverter
    {
        public IOrderReaderStrategy _orderReaderStrategy = new CsvReaderStrategy();
        public IOrderWriterStrategy _orderWriterStrategy = new SqlWriterStrategy();

        public IRowValidator RowValidator { get; set; }
        public List<ColumnConfiguration> Columns { get; set; }
      
        public void Import(StreamReader stream)
        {
            //Put any further specific code here
            var orders = _orderReaderStrategy.Read(RowValidator,Columns,stream);
            _orderWriterStrategy.Write(orders);
        }

        //Still to do
        public ILogger ExceptionLogger
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        //Not great, refactor to parent class
        public IOrderReaderStrategy GetOrderReaderStrategy()
        {
            return _orderReaderStrategy;
        }

        public IOrderWriterStrategy GetOrderWriterStrategy()
        {
            return _orderWriterStrategy;
        }
    }
}
