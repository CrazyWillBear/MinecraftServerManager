using System.Diagnostics;
using System.IO;

namespace MinecraftServerSoftware.Servers
{
    public class Servers
    {
        public bool ServerExists(string servername)
        {
            if (Directory.Exists(@".\server\" + servername))
                return true;
            return false;
        }

        public bool ServerRunning()
        {
            var javaRunning = false;
            var cmdRunning = false;
            foreach (var process in Process.GetProcesses())
            {
                if (process.ProcessName.Contains("java")) javaRunning = true;
                if (process.ProcessName.Contains("cmd")) cmdRunning = true;
            }

            if (cmdRunning && javaRunning)
                return true;
            return false;
        }
    }
}