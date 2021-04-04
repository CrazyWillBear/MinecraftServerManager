using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinecraftServerSoftware
{
    class Program
    {
        public static string[] arguments;
        public static string programdirectory;
        
        static Utils.Screen Screen = new Utils.Screen();

        public static void Main(string[] args)
        {
            arguments = args;
            programdirectory = Environment.CurrentDirectory;
            if (args.Length < 1)
            {
                Screen.PrintLn("\n::Please include a command", ConsoleColor.Red);
            }
            else
            {
                Operations.CommandExecutor.ExecuteCommands(Operations.CommandOrganizer.ParseCommand(args));
            }
        }
    }
}