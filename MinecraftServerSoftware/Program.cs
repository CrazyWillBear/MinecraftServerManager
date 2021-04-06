using System;
using MinecraftServerSoftware.Operations;
using MinecraftServerSoftware.Utils;

namespace MinecraftServerSoftware
{
    internal class Program
    {
        public static string[] arguments;
        public static string programdirectory;

        private static readonly Screen Screen = new();

        public static void Main(string[] args)
        {
            arguments = args;
            programdirectory = Environment.CurrentDirectory;
            if (args.Length < 1)
                Screen.PrintLn("\n::Please include a command", ConsoleColor.Red);
            else
                CommandExecutor.ExecuteCommands(CommandOrganizer.ParseCommand(args));
        }
    }
}