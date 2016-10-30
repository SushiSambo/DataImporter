using DataImporter.interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Concurrent;

namespace DataImporter
{
    /// <summary>
    /// This code merely acts as bridge between the reader and writer
    /// </summary>
    public class CsvToSqlOrderConverter : IOrderConverter
    {
        public void Import(StreamReader stream, IOrderReaderStrategy reader, IOrderWriterStrategy writer)
        {
            var orders = reader.Read(stream);
            writer.Write(orders);
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
    }
}
