using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataImporter.interfaces
{
    public interface IOrderRepository
    {
        List<Order> GetOrders();
        void Add(Order order);
        void Flush();
    }
}
