using System;
using System.IO;
using System.Net;
using MinecraftServerSoftware.Utils;

namespace MinecraftServerSoftware.Servers
{
    public class ServerJars
    {
        private static readonly Screen Screen = new();
        private static readonly ConsoleSpinner ConsoleSpinner = new();

        public bool InstallSpigotJar(string chosenversion, string servername)
        {
            try
            {
                Screen.Print("     -Creating Spigot server jar...", ConsoleColor.Green);
                ConsoleSpinner.Start();
                var wc = new WebClient();
                wc.DownloadFile("https://serverjars.com/api/fetchJar/spigot/" + chosenversion,
                    "./server/" + servername + "/server.jar");
                File.WriteAllText("./server/" + servername + "/serverversion.ver", "Spigot\n" + chosenversion);
                wc.Dispose();
                ConsoleSpinner.Stop();
                Screen.PrintLn("\r     -Created Spigot server jar    ", ConsoleColor.Green);
                return true;
            }
            catch
            {
                Screen.Print("\r     -Creating Spigot server jar... (FAILED)\n", ConsoleColor.Red);
                return false;
            }
        }

        public bool InstallVanillaJar(string chosenversion, string servername)
        {
            try
            {
                Screen.Print("     -Creating Vanilla server jar...", ConsoleColor.Green);
                ConsoleSpinner.Start();
                var wc = new WebClient();
                wc.DownloadFile("https://serverjars.com/jars/vanilla/vanilla/vanilla-" + chosenversion + ".jar",
                    "./server/" + servername + "/server.jar");
                File.WriteAllText("./server/" + servername + "/serverversion.ver", "Vanilla\n" + chosenversion);
                wc.Dispose();
                ConsoleSpinner.Stop();
                Screen.PrintLn("\r     -Created Vanilla server jar    ", ConsoleColor.Green);
                return true;
            }
            catch
            {
                Screen.Print("\r     -Creating Vanilla server jar... (FAILED)\n", ConsoleColor.Red);
                return false;
            }
        }

        public bool InstallBukkitJar(string chosenversion, string servername)
        {
            try
            {
                Screen.Print("     -Creating Bukkit server jar...", ConsoleColor.Green);
                ConsoleSpinner.Start();
                var wc = new WebClient();
                wc.DownloadFile("https://serverjars.com/api/fetchJar/bukkit/" + chosenversion,
                    "./server/" + servername + "/server.jar");
                File.WriteAllText("./server/" + servername + "/serverversion.ver", "Bukkit\n" + chosenversion);
                wc.Dispose();
                ConsoleSpinner.Stop();
                Screen.PrintLn("\r     -Created Bukkit server jar    ", ConsoleColor.Green);
                return true;
            }
            catch
            {
                Screen.Print("\r     -Creating Bukkit server jar... (FAILED)\n", ConsoleColor.Red);
                return false;
            }
        }
    }
}