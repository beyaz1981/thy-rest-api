using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIModel.Helper
{
    public static class LogHelper
    {
        public static void Save(string process, string SessionID, string content)
        {
            string WorkPath =  $"{AppDomain.CurrentDomain.BaseDirectory}\\Logs\\{SessionID}";  //HttpContext.Current.Server.MapPath("~");
            if (!Directory.Exists(WorkPath))
                Directory.CreateDirectory(WorkPath);

            StreamWriter sw = null;
            try
            {
                sw = new StreamWriter($"{WorkPath}\\{process}.txt", true);
                sw.WriteLine(DateTime.Now.ToString());
                sw.WriteLine(content);
                sw.Flush();
                sw.Close();
            }
            catch
            {
            }
        }
    }
}
