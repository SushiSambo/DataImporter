using System.Collections.Generic;
using System.IO;

namespace DataImporter.interfaces
{
    public interface IOrderReaderStrategy
    {
        IEnumerable<Order> Read(StreamReader streamReader);
    }
}   
