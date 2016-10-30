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

        //Not complete, could use EntityFramework here
        public void Write(IEnumerable<Order> orders)
        {
            throw new NotImplementedException();
        }
    }
}
