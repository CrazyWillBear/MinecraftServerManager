using System;
using System.IO;
using MinecraftServerSoftware_Uninstaller.Utils;

namespace MinecraftServerSoftware_Uninstaller
{
    class Program
    {
        static void Main(string[] args)
        {
            if (!File.Exists(@"C:\Users\" + Environment.UserName + @"\AppData\Roaming\MCServerSoftware\dat\installMethod.dat"))
            {
                Screen.PrintBigLogo();
                Screen.PrintLn("::This software was installed either manually or using Scoop according to our appdata. Please uninstall manually or using Scoop (`scoop uninstall mcservman`) depending on how you installed this application", ConsoleColor.Yellow);
                Console.ReadKey(true);
                Environment.Exit(1);
            }
            string installMethod = File.ReadAllText(@"C:\Users\" + Environment.UserName + @"\AppData\Roaming\MCServerSoftware\dat\installMethod.dat");
            if (installMethod != "INSTALLER")
            {
                Screen.PrintBigLogo();
                Screen.PrintLn("::This program's appdata appears to be corrupted or incorrect... Please manually uninstall", ConsoleColor.Yellow);
                Console.ReadKey(true);
                Environment.Exit(1);
            }
            ConsoleSpinner spinner = new ConsoleSpinner();
            Screen.PrintBigLogo();
            Screen.Print("\n::Would you like to continue with the uninstallation? (Y/N)  >>  ", ConsoleColor.Yellow);
            ConsoleKeyInfo key = Console.ReadKey();
            string installDir = @"C:\Program Files\MCServerSoftware";

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
