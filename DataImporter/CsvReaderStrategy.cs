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
        public FileConfiguration FileConfiguration { get; set; }

        public IEnumerable<Order> Read(IRowValidator rowValidator, List<ColumnConfiguration> columns, StreamReader streamReader)
        {
            var orderList = new List<Order>();
            using (var parser = new TextFieldParser(streamReader)
                {
                    Delimiters = new[] { FileConfiguration.Delimiter },
                    TextFieldType = FieldType.Delimited,
                    HasFieldsEnclosedInQuotes = FileConfiguration.HasFieldsEnclosedInQuotes,
                })
            {
                var header = parser.ReadFields();
                if (header == null)
                {
                    throw new InvalidDataException("File is empty");
                }

                if (columns.Count > header.Length)
                {
                    throw new InvalidDataException("Header is missing columns requested");
                }

                var configuredActionsToPerform = new Dictionary<string, Action<object,Order>>();
                configuredActionsToPerform.Add("model", (obj, order) => { order.Model = obj.ToString(); });
                configuredActionsToPerform.Add("make", (obj, order) => { order.Make = obj.ToString(); });

                var actionsToPerform = new Dictionary<int, Action<object,Order>>();

                //configure where the indexes of each column are
                for (int i = 0; i < header.Length; i++)
                {
                    var matchingColumn = columns.Find(match => string.Compare(header[i],match.SourceColumnName, true) == 0);
                    if (matchingColumn == null)
                    {
                        throw new InvalidDataException(string.Format("No matching configuration for this column in the header can be found: {0}", header[i]));
                    }
                    actionsToPerform.Add(i, configuredActionsToPerform[header[i]]); //todo change this to look it up
                }

                //change to use parallel foreach
                while (!parser.EndOfData)
                {
                    var incomingFields = parser.ReadFields();
                    var order = new Order();
                    
                    //change to a yield return
                    actionsToPerform.ToList().ForEach(p => p.Value(incomingFields[p.Key], order));

                    order.IsValid = rowValidator.IsValid(order);
                    //log if the row is not valid with the validation method

                    yield return order;
                }
            }
        }
    }
}
