using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_Apteka.Model
{
    public class Logger
    {
        private string fullFileLog;

        internal Logger()
        {
            InitialLogFile();
        }
        private void InitialLogFile()
        {
            var filecontext = new Context();
            string filelog = $"{DateTime.Today.Month}.{DateTime.Today.Year}.txt";
            string folderLog = @"C:\My_apteka\Log";
            fullFileLog = filecontext.GetFileLog(folderLog, filelog);
        }
        public void Log(string message)
        {
            var filecontext = new Context();
            var logDate = DateTime.Now;
            var log = $"{logDate.ToShortDateString()} {logDate.ToShortTimeString()} {message}";
            filecontext.WriteLog(log, fullFileLog);
        }
    }
}
