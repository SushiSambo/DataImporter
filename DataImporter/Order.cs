using System;
namespace DataImporter
{
    /// <summary>
    /// Data Access Object for Order
    /// </summary>
     public class Order
     {
         public string Make { get; set; }
         public string Model { get; set; }
         public decimal BasePrice { get; set; }//todo convert this to type money when saving by formatting string
         public int Cylinders { get; set; }
         public int Power { get; set; }
         public string Fuel { get; set; }
         public decimal Weight { get; set; }
         public DateTime Introduced { get; set; } 
         public bool IsConvertible { get; set; }
         public OrderState OrderState { get; set; }

         public override bool Equals(object obj)
         {
             return Equals((Order)obj);
         }

         public override int GetHashCode()
         {
             return base.GetHashCode();
         }

         private bool Equals(Order other)
         {
             return Make == other.Make &&
                 Model == other.Model &&
                 BasePrice == other.BasePrice &&
                 Cylinders == other.Cylinders &&
                 Power == other.Power &&
                 Fuel == other.Fuel &&
                 Power == other.Power &&
                 Fuel == other.Fuel &&
                 Weight == other.Weight &&
                 IsConvertible == other.IsConvertible &&
                 OrderState.IsValid == other.OrderState.IsValid &&
                 OrderState.ValidationMessage == other.OrderState.ValidationMessage;
         }
     }

     public struct OrderState
     {
         public bool IsValid { get; set; }
         public string ValidationMessage { get; set; }
     }
}
