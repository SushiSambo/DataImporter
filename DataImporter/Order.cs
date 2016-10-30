using System;
namespace DataImporter
{
    /// <summary>
    /// Data Access Object for Order
    /// </summary>
     public class Order
     {
         //[TargetColumn = "Make", MaxSize = 50] //decorate with column properties
         public string Make { get; set; }
         public string Model { get; set; }
         public decimal BasePrice { get; set; }//todo convert this to type money when saving by formatting string
         public int Cylinders { get; set; }
         public int Power { get; set; }
         public string Fuel { get; set; }
         public decimal Weight { get; set; }
         public DateTime Introduced { get; set; } 
         public bool IsConvertible { get; set; }
         public Tuple<bool,string> IsValid { get; set; }
      }
}
