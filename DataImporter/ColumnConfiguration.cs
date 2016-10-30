using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataImporter
{
    public class ColumnConfiguration
    {
        public string DestinationColumName { get; set; }

        public string SourceColumnName { get; set; }

        //Todo: Change this to be an enum so that we can limit the types
        public string DestinationDataType { get; set; }

        public Action<object,Order> ActionToPerform { get; set; }
    }
}
