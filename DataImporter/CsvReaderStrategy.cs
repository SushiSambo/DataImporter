using DataImporter.interfaces;
using System.Collections.Generic;
using Microsoft.VisualBasic.FileIO;
using System.IO;
using System;
using System.Linq;

namespace DataImporter
{
    public class CsvReaderStrategy : IOrderReaderStrategy
    {
        private FileConfiguration _fileConfiguration;
        private IRowValidator _rowValidator;
        private List<ColumnConfiguration> _columns;

        public CsvReaderStrategy(FileConfiguration fileConfiguration, IRowValidator rowValidator, List<ColumnConfiguration> columns)
        {
            _fileConfiguration = fileConfiguration;
            _rowValidator = rowValidator;
            _columns = columns;
        }

        public IEnumerable<Order> Read(StreamReader streamReader)
        {
            var orderList = new List<Order>();
            using (var parser = new TextFieldParser(streamReader)
                {
                    Delimiters = new[] { _fileConfiguration.Delimiter },
                    TextFieldType = FieldType.Delimited,
                    HasFieldsEnclosedInQuotes = _fileConfiguration.HasFieldsEnclosedInQuotes,
                })
            {
                var header = parser.ReadFields();
                if (header == null)
                {
                    throw new InvalidDataException("File is empty");
                }

                if (_columns.Count > header.Length)
                {
                    throw new InvalidDataException("Header is missing columns requested");
                }

                var actionsToPerform = new Dictionary<int, Action<object,Order>>();

                //configure where the indexes of each column are
                for (int i = 0; i < header.Length; i++)
                {
                    var matchingColumn = _columns.Find(match => string.Compare(header[i],match.SourceColumnName, true) == 0);
                    if (matchingColumn == null)
                    {
                        throw new InvalidDataException(string.Format("No matching configuration for this column in the header can be found: {0}", header[i]));
                    }
                    actionsToPerform.Add(i, matchingColumn.ActionToPerform);
                }

                while (!parser.EndOfData)
                {
                    var incomingFields = parser.ReadFields();
                    var order = new Order();
                    
                    //change to a yield return
                    actionsToPerform.ToList().ForEach(p => p.Value(incomingFields[p.Key], order));

                    order.OrderState = _rowValidator.IsValid(order);
                    yield return order;
                }
            }
        }
    }
}
