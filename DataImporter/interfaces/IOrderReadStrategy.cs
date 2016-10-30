using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataImporter.interfaces
{
    public interface IOrderReaderStrategy
    {
        IEnumerable<Order> Read(IRowValidator rowValidator, List<ColumnConfiguration> columns, StreamReader streamReader);
    }
}   
