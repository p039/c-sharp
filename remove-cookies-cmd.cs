using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace RemoveCookies
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Cookies);

            if (Precondition.InvokePrompt("/c DEL /F /S /Q " + path))
            {
                Console.WriteLine("Files are deleted");
            }           
        }
    }

    public class Precondition
    {
        public static bool InvokePrompt(string command)
        {
            try
            {
                Process process = new Process();
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.WindowStyle = ProcessWindowStyle.Hidden;
                startInfo.FileName = "cmd.exe";
                startInfo.Arguments = command;
                process.StartInfo = startInfo;
                process.Start();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
