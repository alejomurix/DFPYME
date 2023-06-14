using System;
using System.IO;

namespace Utilities
{
    public  class FilesIO
    {
        static StreamWriter sw;

        static string pathLog = @"\logs\";

        static string nameFileLog;

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
    }
}
