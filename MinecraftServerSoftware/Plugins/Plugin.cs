using System;
using System.Collections.Generic;
using System.IO;
using System.Security;
using MinecraftServerSoftware.Utils;
using Octokit;

namespace MinecraftServerSoftware.Plugins
{
    public class Plugin
    {
        private static readonly Screen Screen = new();

        public static bool CheckServerCompatability(string servername)
        {
            string[] text = System.IO.File.ReadAllLines(Program.appdata + @"\server\" + servername + @"\serverversion.ver");
            if (text[0] == "Paper" || text[0] == "Spigot" || text[0] == "Bukkit")
            {
                if (Directory.Exists(Program.appdata + @"\server\" + servername + @"\world")) { }
                else
                {
                    return false;
                }
                return true;
            }
            else
            {
                return false;
            }
        }
        public static void InstallPlugin(string pluginname, string servername)
        {
            try
            {
                System.IO.File.Copy(@"C:\Users\" + Environment.UserName + @"\Downloads\" + pluginname, Program.appdata + "/server/" + servername + @"\plugins", true);
                System.IO.File.Delete(@"C:\Users\" + Environment.UserName + @"\Downloads\" + pluginname);
                Screen.PrintLn("::Successfully installed `" + pluginname + "` in `" + servername + "`", ConsoleColor.Green);
            }
            catch
            {
                Screen.PrintLn("::Could not find plugin `" + pluginname + "` in `Downloads`. Make sure to include the file extension", ConsoleColor.Red);
            }
        }

        public static void DeletePlugin(string servername)
        {
            try
            {
                int index = 1;
                string[] pluginfiles = Directory.GetFiles(Program.appdata + "/server/" + servername + @"\plugins");
                List<string> delchoices = new List<string>();
                foreach (string files in pluginfiles)
                {
                    if (files.Split('\\')[files.Split('\\').Length - 1] == "PluginMetrics")
                    {
                        continue;
                    }
                    Screen.PrintLn("     - " + index + ") " + files.Split('\\')[files.Split('\\').Length - 1], ConsoleColor.Green);
                    delchoices.Add(files);
                    index++;
                }
                Screen.Print("\n::Which plugin would you like to delete? (Enter corresponding number)  >>  ", ConsoleColor.Green);
                string input = Console.ReadLine();
                System.IO.File.Delete(delchoices[int.Parse(input)]);
                Screen.PrintLn("::Successfully deleted `" + delchoices[int.Parse(input)].Split('\\')[delchoices[int.Parse(input)].Split('\\').Length - 1] + "` in `" + servername + "`", ConsoleColor.Green);
            }
            catch (Exception ex)
            {
                Screen.PrintLn(ex.ToString(), ConsoleColor.Red);
            }
        }

        public class File
        {
            public string type { get; set; }
            public double size { get; set; }
            public string sizeUnit { get; set; }
            public string url { get; set; }
            public string externalUrl { get; set; }
        }

        public class Version
        {
            public int id { get; set; }
            public string uuid { get; set; }
        }

        public class Author
        {
            public int id { get; set; }
        }

        public class Category
        {
            public int id { get; set; }
        }

        public class Rating
        {
            public int count { get; set; }
            public double average { get; set; }
        }

        public class Icon
        {
            public string url { get; set; }
            public string data { get; set; }
            public string info { get; set; }
            public string hash { get; set; }
        }

        public class Root
        {
            public File file { get; set; }
            public int likes { get; set; }
            public List<string> testedVersions { get; set; }
            public Dictionary<string, string> links { get; set; }
            public string name { get; set; }
            public string tag { get; set; }
            public Version version { get; set; }
            public Author author { get; set; }
            public Category category { get; set; }
            public Rating rating { get; set; }
            public Icon icon { get; set; }
            public int releaseDate { get; set; }
            public int updateDate { get; set; }
            public int downloads { get; set; }
            public bool premium { get; set; }
            public string sourceCodeLink { get; set; }
            public string donationLink { get; set; }
            public int existenceStatus { get; set; }
            public int id { get; set; }
        }
    }
}