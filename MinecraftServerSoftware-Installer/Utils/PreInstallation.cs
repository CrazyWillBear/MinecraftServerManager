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
            wc.DownloadFile("https://github.com/AdoptOpenJDK/openjdk16-binaries/releases/download/jdk-16%2B36/OpenJDK16-jdk_x64_windows_hotspot_16_36.msi", @"C:\Users\" + Environment.UserName + @"\Downloads\open-jdk-installer.msi");
            Process proc = System.Diagnostics.Process.Start(@"C:\Users\" + Environment.UserName +
                                                            @"\Downloads\open-jdk-installer.msi");
            proc.WaitForExit();
            File.Delete(@"C:\Users\" + Environment.UserName + @"\Downloads\open-jdk-installer.msi");
        }
    }
}