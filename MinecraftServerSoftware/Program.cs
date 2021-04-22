using System;
using System.IO;
using MinecraftServerSoftware.Operations;
using MinecraftServerSoftware.Utils;

namespace MinecraftServerSoftware
{
    internal class Program
    {
        public static string[] arguments;
        public static string programdirectory;
        public static readonly string appdata = @"C:\Users\" + Environment.UserName + @"\AppData\Roaming\MCServerSoftware";

        private static readonly Screen Screen = new();

        public static void Main(string[] args)
        {
            arguments = args;
            programdirectory = Environment.CurrentDirectory;
            if (args.Length < 1)
                Screen.PrintLn("\n::Please include a command", ConsoleColor.Red);
            else
                CommandExecutor.ExecuteCommands(CommandOrganizer.ParseCommand(args));
            if (!Directory.Exists(appdata))
            {
                Directory.CreateDirectory(appdata);
            }
        }
    }
}