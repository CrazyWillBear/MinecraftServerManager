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
                Console.WriteLine("Created directory");
                GitHubClient client = new GitHubClient(new ProductHeaderValue("MinecraftServerManager"));
                Console.WriteLine("Created github client");
                var releases = await client.Repository.Release.GetAll("CrazyWillBear", "MinecraftServerManager");
                Console.WriteLine("retreived repository releases");
                var latest = releases[0];
                WebClient wc = new WebClient();
                Console.WriteLine("created webclient");
                Console.WriteLine("https://github.com/CrazyWillBear/MinecraftServerManager/releases/download/" + latest.TagName + "/" + "uninstaller.zip");
                wc.DownloadFile("https://github.com/CrazyWillBear/MinecraftServerManager/releases/download/" + latest.TagName + "/" + "uninstaller.zip", Program.appdata + @".\uninstall\uninstaller.zip");
                System.IO.Compression.ZipFile.ExtractToDirectory(Program.appdata + @".\uninstall\uninstaller.zip", Program.appdata + @".\uninstall");
                File.Delete(Program.appdata + @".\uninstall\MCServerSoftware.zip");
            }
        }
    }
}