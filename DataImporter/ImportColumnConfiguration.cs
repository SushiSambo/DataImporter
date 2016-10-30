using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataImporter
{
    public class ImportColumn
    {
        public string SourceColumn { get; set; }
        public string TargetColumn { get; set; }
        public string TargetDataType { get; set; }
    }
}
