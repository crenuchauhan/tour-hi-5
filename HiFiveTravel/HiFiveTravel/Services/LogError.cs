using HiFiveTravel.Interfaces;

namespace HiFiveTravel.Services
{
    /*Method To Save log to ErroLog text file in ErrorLog folder whenever get any exception */
    public class LogError : ILogError
    {
        public void LogErrorFile(Exception ex, IWebHostEnvironment _env)
        {
            string message = string.Format("Time: {0}", DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt"));
            string filename = "ErrorLog.txt";
            message += Environment.NewLine;
            message += "-----------------------------------------------------------";

            message += Environment.NewLine;
            message += string.Format("Message: {0}", ex.Message);
            message += Environment.NewLine;
            message += string.Format("StackTrace: {0}", ex.StackTrace);
            message += Environment.NewLine;
            message += string.Format("Source: {0}", ex.Source);
            message += Environment.NewLine;
            message += string.Format("TargetSite: {0}", ex.TargetSite.ToString());
            message += Environment.NewLine;
            message += "-----------------------------------------------------------";
            message += Environment.NewLine;
            string path = _env.ContentRootPath + "/ErrorLog/" + filename;
            // string path = Server.MapPath("~/ErrorLog/ErrorLog.txt");
            using (StreamWriter writer = new StreamWriter(path, true))
            {
                writer.WriteLine(message);
                writer.Close();
            }
        }
    }
}
