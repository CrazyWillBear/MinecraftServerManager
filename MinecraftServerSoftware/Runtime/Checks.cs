using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Octokit;

namespace MinecraftServerSoftware.Runtime
{
    public class Checks
    {
        public static void CheckForAppData()
        {
            if (!Directory.Exists(Program.appdata))
            {
                Directory.CreateDirectory(Program.appdata);
            }
        }
        public static async Task CheckForUninstaller()
        {
            if (!File.Exists(Program.appdata + @".\uninstall\MinecraftServerSoftware-Uninstaller.exe"))
            {
                Directory.CreateDirectory(Program.appdata + @".\uninstall");
                GitHubClient client = new GitHubClient(new ProductHeaderValue("MinecraftServerManager"));
                var releases = await client.Repository.Release.GetAll("CrazyWillBear", "MinecraftServerManager");
                var latest = releases[0];
                WebClient wc = new WebClient();
                wc.DownloadFile("https://github.com/CrazyWillBear/MinecraftServerManager/releases/download/" + latest.TagName + "/" + "uninstaller.zip", Program.appdata + @".\uninstall\uninstaller.zip");
                System.IO.Compression.ZipFile.ExtractToDirectory(Program.appdata + @".\uninstall\uninstaller.zip", Program.appdata + @".\uninstall");
                File.Delete(Program.appdata + @".\uninstall\MCServerSoftware.zip");
            }
        }
    }
}