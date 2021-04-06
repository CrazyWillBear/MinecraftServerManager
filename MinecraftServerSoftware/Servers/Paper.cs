using System;
using System.IO;
using System.Net;
using MinecraftServerSoftware.Utils;
using Newtonsoft.Json;

namespace MinecraftServerSoftware.Servers
{
    public class Paper
    {
        private static readonly Screen Screen = new();
        private static readonly ConsoleSpinner ConsoleSpinner = new();

        public static int GetLatestBuild(string MinecraftVersion)
        {
            var wc = new WebClient();
            var paper = JsonConvert.DeserializeObject<PaperJSON>(
                wc.DownloadString("https://papermc.io/api/v2/projects/paper/versions/" + MinecraftVersion));

            var largest = paper.builds[0];
            foreach (var item in paper.builds)
                if (item > largest)
                    largest = item;

            wc.Dispose();
            return largest;
        }

        public bool DoesVersionExist(string minecraftVersion)
        {
            var wc = new WebClient();

            try
            {
                if (wc.DownloadString("https://papermc.io/api/v2/projects/paper/versions/" + minecraftVersion) ==
                    "{\"error\":\"no such version\"}")
                {
                    wc.Dispose();
                    return false;
                }

                wc.Dispose();
                return true;
            }
            catch
            {
                wc.Dispose();
                return false;
            }
        }

        public bool InstallPaperJar(string chosenversion, string servername)
        {
            try
            {
                Screen.Print("     -Creating Paper server jar...", ConsoleColor.Green);
                ConsoleSpinner.Start();
                var wc = new WebClient();
                wc.DownloadFile(
                    "https://papermc.io/api/v2/projects/paper/versions/" + chosenversion + "/builds/" +
                    GetLatestBuild(chosenversion) + "/downloads/paper-" + chosenversion + "-" +
                    GetLatestBuild(chosenversion) + ".jar", "./server/" + servername + "/server.jar");
                File.WriteAllText("./server/" + servername + "/serverversion.ver",
                    "Paper\n" + chosenversion + "\n" + GetLatestBuild(chosenversion));
                wc.Dispose();
                ConsoleSpinner.Stop();
                Screen.PrintLn("\r     -Created Paper server jar    ", ConsoleColor.Green);
                return true;
            }
            catch
            {
                Screen.Print("\r     -Creating Paper server jar... (FAILED)\n", ConsoleColor.Red);
                return false;
            }
        }
    }

    public class PaperJSON
    {
        public string? project_id { get; set; }
        public string? project_name { get; set; }
        public string? version { get; set; }
        public int[]? builds { get; set; }
    }
}