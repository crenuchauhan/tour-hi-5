namespace HiFiveTravel.Interfaces
{
    /*Interface to LogError class*/
    public interface ILogError
    {
        public void LogErrorFile(Exception ex, IWebHostEnvironment _env);
    }
}
