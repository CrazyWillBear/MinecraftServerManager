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
            if (!File.Exists(Program.appdata + @"\dat\installDir.dat"))
            {
                string input;
                ConsoleKeyInfo keyPressed;
                Screen.Print("\n::Program data not found, did you install using Scoop? (Y/N)  >>  ", ConsoleColor.Green);
                keyPressed = Console.ReadKey();
                if (keyPressed.KeyChar == 'y')
                {
                    File.WriteAllText(Program.appdata + @"\dat\installDir.dat", @"C:\Users\" + Environment.UserName + @"\scoop\apps\mcservman");
                }
                else
                {
                    Screen.Print("\n     -What directory did you install MCServMan into (include FULL path)?  >>  ", ConsoleColor.Green);
                    input = Console.ReadLine();
                    File.WriteAllText(Program.appdata + @"\dat\installDir.dat", input);
                }
                Screen.PrintLn("\n     -Successfully updated program data", ConsoleColor.Green);
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