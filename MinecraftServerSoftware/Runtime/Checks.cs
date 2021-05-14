using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using MinecraftServerSoftware.Utils;
using Octokit;

namespace MinecraftServerSoftware.Runtime
{
    public class Checks
    {
        private static readonly Screen Screen = new();
        public static void CheckForAppData()
        {
            if (!Directory.Exists(Program.appdata))
            {
                Directory.CreateDirectory(Program.appdata);
            }
            if (!Directory.Exists(Program.appdata + @"\dat"))
            {
                Directory.CreateDirectory(Program.appdata + @"\dat");
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

        public static async Task CheckForUpdate()
        {
            GitHubClient client = new GitHubClient(new ProductHeaderValue("MinecraftServerManager"));
            var releases = await client.Repository.Release.GetAll("CrazyWillBear", "MinecraftServerManager");
            var latest = releases[0];
            if (latest.ToString() != Program.version)
            {
                Screen.PrintLn("\n::An update is required, please rerun the latest installer or update using Scoop (depending on how the software was installed)");
            }
        }
    }
}