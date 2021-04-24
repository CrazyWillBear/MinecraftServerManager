using System;
using System.IO;
using MinecraftServerSoftware_Uninstaller.Utils;

namespace MinecraftServerSoftware_Uninstaller
{
    class Program
    {
        static void Main(string[] args)
        {
            string installDir = File.ReadAllText(@"C:\Users\" + Environment.UserName + @"\AppData\Roaming\MCServerSoftware\dat\installDir.dat");
            if (installDir == "Scoop")
            {
                Screen.PrintBigLogo();
                Screen.Print("::This software was installed using Scoop according to our program data. Please use scoop to uninstall", ConsoleColor.Red);
                Console.ReadKey(true);
                Environment.Exit(1);
            }
            ConsoleSpinner spinner = new ConsoleSpinner();
            Screen.PrintBigLogo();
            Screen.Print("\n::Would you like to continue with the uninstallation? (Y/N)  >>  ", ConsoleColor.Yellow);
            ConsoleKeyInfo key = Console.ReadKey();

            switch (key.KeyChar)
            {
                case ('y'):
                    Screen.Print("\n     -Uninstalling software...", ConsoleColor.Yellow);
                    spinner.Start();
                    Uninstall.UninstallPreserveData(installDir);
                    break;
                default:
                    Screen.Print("\n     -Cancelled uninstallation", ConsoleColor.Yellow);
                    Console.ReadKey(true);
                    Environment.Exit(0);
                    break;
            }

            spinner.Stop();
            Screen.Print("\r     -Successfully uninstalled software", ConsoleColor.Yellow);
            Console.ReadKey(true);
        }
    }
}
