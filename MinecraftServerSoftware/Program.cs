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
        public static string programdirectory;
        public static readonly string appdata = @"C:\Users\" + Environment.UserName + @"\AppData\Roaming\MCServerSoftware";

        private static readonly Screen Screen = new();

        public static async Task Main(string[] args)
        {
            Checks.CheckForAppData();
            try {
                Console.WriteLine("Checking for uninstaller...");
                await Checks.CheckForUninstaller();
            }
            catch (Exception ex) {
                Console.WriteLine(ex);
            }
            
            arguments = args;
            programdirectory = Environment.CurrentDirectory;
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