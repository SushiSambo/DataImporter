using DataImporter.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataImporter
{
    public class SqlWriterStrategy : IOrderWriterStrategy
    {
        //Not complete, should use EntityFramework here, or create a list and bulk insert
        //Note that since Read has yield return, it will only excecute when the Order list is enumerated
        public void Write(IEnumerable<Order> orders)
        {
            orders.ToList().ForEach(lineItem => OrderRepository.Add(lineItem));
        }


        public IOrderRepository OrderRepository
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
