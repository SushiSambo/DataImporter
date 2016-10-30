using System;
namespace DataImporter.interfaces
{
    public interface IRowValidator
    {
        /// <summary>
        /// Check for validity of the order row, for example length of strings
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        OrderState IsValid(Order order);
    }
}
