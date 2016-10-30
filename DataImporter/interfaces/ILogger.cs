namespace DataImporter.interfaces
{
    public interface ILogger
    {
        //Todo make this more intelligent, perhaps an IObservable collection of failed rows for Read or Write
        void Log(string message);
    }
}
