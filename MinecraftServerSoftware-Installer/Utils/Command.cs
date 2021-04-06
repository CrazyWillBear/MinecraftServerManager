using System;
using System.Diagnostics;

namespace MinecraftServerSoftware_Installer.Utils
{
    public class Command
    {
        public static void RunCMD(string command)
            {
                Process proc = null;
                proc = new Process();
                proc.StartInfo.FileName = "cmd.exe";
                proc.StartInfo.Arguments = command;
                proc.StartInfo.CreateNoWindow = false;
                proc.StartInfo.Verb = "runas";
                proc.Start();
                proc.WaitForExit();
                proc.Kill();
            } 
    }
}