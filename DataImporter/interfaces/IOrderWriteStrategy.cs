using System.Collections.Generic;

namespace DataImporter.interfaces
{
    public interface IOrderWriterStrategy
    {
        IOrderRepository OrderRepository { get; set; }
        void Write(IEnumerable<Order> orders);
    }
}
