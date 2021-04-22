using System;
using System.Diagnostics;
using System.IO;
using System.Net;

namespace MinecraftServerSoftware_Installer.Utils
{
    public class PreInstallation
    {
        public static bool DetectJavaInstallation()
        {
            try
            {
                ProcessStartInfo procStartInfo =
                    new ProcessStartInfo("java");
                procStartInfo.UseShellExecute = false;
                procStartInfo.CreateNoWindow = true;
                Process proc = new Process();
                proc.StartInfo = procStartInfo;
                proc.Start();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static void InstallJava()
        {
            WebClient wc = new WebClient();
            wc.DownloadFile("https://javadl.oracle.com/webapps/download/AutoDL?BundleId=244584_d7fc238d0cbf4b0dac67be84580cfb4b", @"C:\Users\" + Environment.UserName + @"\Downloads\java-installer.exe");
            Process proc = System.Diagnostics.Process.Start(@"C:\Users\" + Environment.UserName +
                                                            @"\Downloads\java-installer.exe");
            proc.WaitForExit();
            File.Delete(@"C:\Users\" + Environment.UserName + @"\Downloads\java-installer.exe");
        }
    }
}