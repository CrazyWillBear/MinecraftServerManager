using System;
using System.Threading.Tasks;
using MinecraftServerSoftware.Operations;
using MinecraftServerSoftware.Utils;
using MinecraftServerSoftware.Runtime;

namespace MinecraftServerSoftware
{
    internal class Program
    {
        public static string[] arguments;
        public static readonly string version = "0.0.7.1-alpha";
        public static readonly string appdata = @"C:\Users\" + Environment.UserName + @"\AppData\Roaming\MCServerSoftware";

        private static readonly Screen Screen = new();

        public static async Task Main(string[] args)
        {
            Checks.CheckForAppData();
            await Checks.CheckForUpdate();
            await Checks.CheckForUninstaller();
            
            arguments = args;
            if (args.Length < 1)
            {
                Screen.PrintLn("\n::Please include a command", ConsoleColor.Red);
            }
            else
            {
                CommandExecutor.ExecuteCommands(CommandOrganizer.ParseCommand(args));
            }
        }
    }
}