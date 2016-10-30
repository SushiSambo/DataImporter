using System.IO;
namespace DataImporter.interfaces
{
    interface IOrderConverter
    {
        void Import(StreamReader stream, IOrderReaderStrategy reader, IOrderWriterStrategy writer);

        ILogger ExceptionLogger { get; set;}
    }
}
