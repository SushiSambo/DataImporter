using System.IO;
namespace DataImporter.interfaces
{
    interface IOrderConverter
    {
        IOrderReaderStrategy GetOrderReaderStrategy();

        IOrderWriterStrategy GetOrderWriterStrategy();

        void Import(StreamReader stream);

        ILogger ExceptionLogger { get; set;}
    }
}
