using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using MinecraftServerSoftware.Utils;

namespace MinecraftServerSoftware.Plugins
{
    public class Configure
    {
        private static readonly Screen Screen = new();
        public static void configurePlugin(string servername)
        {
            string[] serverdir = Directory.GetDirectories(Program.appdata + @"\server\" + servername + @"\plugins");

            if (serverdir.Length < 2 && serverdir[0].Split('\\')[serverdir[0].Split('\\').Length - 1] == "PluginMetrics")
            {
                Screen.PrintLn("\n::There are no plugins installed that have coniguration options", ConsoleColor.Green);
                Environment.Exit(0);
            }

            Screen.PrintLn("\n::Plugins:", ConsoleColor.Green);

            int index = 1;
            List<string> dirchoices = new List<string>();
            foreach (string dir in serverdir)
            {
                if (dir.Split('\\')[dir.Split('\\').Length - 1] == "PluginMetrics")
                {
                    continue;
                }
                Screen.PrintLn("     - " + index + ") " + dir.Split('\\')[dir.Split('\\').Length - 1], ConsoleColor.Green);
                dirchoices.Add(dir);
                index++;
            }
            Screen.Print("\n::Which plugin would you like to configure? (Enter corresponding number)  >>  ", ConsoleColor.Green);
            string input = Console.ReadLine();
            

            string[] pluginfiles = Directory.GetFiles(dirchoices[int.Parse(input) - 1]);

            Screen.Print("\n::Plugin files:\n", ConsoleColor.Green);
            if (pluginfiles.Length == 0)
            {
                Screen.PrintLn("::This plugin does dot have configuration options", ConsoleColor.Green);
                Environment.Exit(0);
            }

            index = 1;
            List<string> filechoices = new List<string>();
            foreach (string file in pluginfiles)
            {
                Screen.PrintLn("     - " + index + ") " + file.Split('\\')[file.Split('\\').Length - 1], ConsoleColor.Green);
                filechoices.Add(file);
            }
            index++;
            Screen.Print("\n::Which file would you like to modify? (Enter corresponding number)  >>  ", ConsoleColor.Green);
            input = Console.ReadLine();
            Screen.Print("     -Opening configuration file...", ConsoleColor.Green);

            Process proc = null;
            proc = new Process();
            proc.StartInfo.FileName = "notepad.exe";
            proc.StartInfo.Arguments = filechoices[int.Parse(input) - 1];
            proc.StartInfo.CreateNoWindow = false;
            proc.StartInfo.Verb = "runas";
            proc.Start();
            proc.WaitForExit();
            proc.Kill();

            Screen.Print("\r     -Opened and edited configuration file\n", ConsoleColor.Green);
            Environment.Exit(0);
        }
    }
}