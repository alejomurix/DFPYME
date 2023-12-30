using System;
using System.IO;

namespace Utilities
{
    public class FilesIO
    {
        static StreamWriter sw;

        static readonly string pathLog = @"\logs\";

        static string nameFileLog;

        static readonly string pathDocumentsElectonic = @"\documentsElectonic\";

        public static void SaveLog(string pathFile, string message)
        {
            try 
            {
                nameFileLog = "log-" + DateTime.Now.Day + "-" + DateTime.Now.Month + "-" + DateTime.Now.Year +
                    "-" + DateTime.Now.Hour + "-" + DateTime.Now.Minute + "-" + DateTime.Now.Second + "-" + DateTime.Now.Millisecond + ".txt";
                sw = File.CreateText(pathFile + pathLog + nameFileLog);
                sw.WriteLine(message);
                sw.Close();
            }
            catch { }
        }

        public static void SaveDocumentsElectonic(string pathFile, string number, string content)
        {
            try
            {
                nameFileLog = "DIAN_" + number + ".json";
                sw = File.CreateText(pathFile + pathDocumentsElectonic + nameFileLog);
                sw.WriteLine(content);
                sw.Close();
            }
            catch { }
        }
    }
}
