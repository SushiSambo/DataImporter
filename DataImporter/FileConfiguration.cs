using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataImporter
{
    public class FileConfiguration
    {
        public string FileName { get; set; }

        public string Delimiter { get; set; }

        public string Header { get; set; }

        public bool HasFieldsEnclosedInQuotes { get; set; }
    }
}
