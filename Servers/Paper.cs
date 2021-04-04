using System;
using System.IO;
using System.Net;
using System.Threading;
using Newtonsoft.Json;

namespace MinecraftServerSoftware.Servers
{
    public class Paper
    {
        static Utils.Screen Screen = new Utils.Screen();
        static Utils.ConsoleSpinner ConsoleSpinner = new Utils.ConsoleSpinner();
        
        public static int GetLatestBuild(string MinecraftVersion)
        {
            WebClient wc = new WebClient();
            PaperJSON paper = JsonConvert.DeserializeObject<PaperJSON>(wc.DownloadString("https://papermc.io/api/v2/projects/paper/versions/" + MinecraftVersion));
            
            int largest = paper.builds[0];
            foreach (int item in paper.builds)
            {
                if (item > largest) { largest = item; }
            }
            
            wc.Dispose();
            return largest;
        }

        public bool DoesVersionExist(string minecraftVersion)
        {
            WebClient wc = new WebClient();

            try
            {
                if (wc.DownloadString("https://papermc.io/api/v2/projects/paper/versions/" + minecraftVersion) ==
                    "{\"error\":\"no such version\"}")
                { 
                    wc.Dispose(); return false;
                }
                else
                {
                    wc.Dispose(); return true;
                }
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
                WebClient wc = new WebClient();
                wc.DownloadFile(
                    "https://papermc.io/api/v2/projects/paper/versions/" + chosenversion + "/builds/" +
                    GetLatestBuild(chosenversion) + "/downloads/paper-" + chosenversion + "-" +
                    GetLatestBuild(chosenversion) + ".jar", "./server/" + servername + "/server.jar");
                File.WriteAllText("./server/" + servername + "/serverversion.ver", "Paper\n" + chosenversion + "\n" + Paper.GetLatestBuild(chosenversion).ToString());
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