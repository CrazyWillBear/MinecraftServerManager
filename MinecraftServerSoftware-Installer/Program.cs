using System;
using System.IO;
using System.Threading.Tasks;
using MinecraftServerSoftware_Installer.Utils;

namespace MinecraftServerSoftware_Installer
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            var spinner = new ConsoleSpinner();
            string installDir = @"C:\Program Files";
            Screen.PrintBigLogo();
            
            Screen.Print("\n::Would you like to run this installer? (Y/N)  >>  ", ConsoleColor.Yellow);
            ConsoleKeyInfo key = Console.ReadKey();
            if (key.KeyChar != 'y')
            {
                Environment.Exit(0);
            }
            
            Screen.PrintLn("\n::In order to proceed with the installation, we need to detect a Java installation",
                ConsoleColor.Yellow);
            Screen.Print("     -Detecting installation...", ConsoleColor.Yellow);
            spinner.Start();
            bool javainstalled = PreInstallation.DetectJavaInstallation();
            spinner.Stop();
            if (javainstalled)
            {
                Screen.Print("\r     -Java is already installed         ", ConsoleColor.Yellow);
            }
            else
            {
                Screen.Print("\r     -Java is not installed, would you like to install Java? >>  ", ConsoleColor.Yellow);
                ConsoleKeyInfo keyInput = Console.ReadKey();

                if (keyInput.KeyChar != 'y')
                {
                    Screen.Print("\r     -Continuing without Java installed", ConsoleColor.Yellow);
                }
                ConsoleSpinner Spinner = new ConsoleSpinner();
                Spinner.Start();
                PreInstallation.InstallJava();
                Spinner.Stop();
                Screen.Print("\r     -Java has been installed                                                                                ", ConsoleColor.Yellow);
            }

            Screen.Print(
                "\n::Would you like to change the install directory, default is " +
                @"`C:\Program Files`? (type directory or leave blank)  >>  ",
                ConsoleColor.Yellow);
            string input = Console.ReadLine();

            Screen.PrintLn("::Installing", ConsoleColor.Yellow);
            if (Directory.Exists(input))
            {
                installDir = input + @"\MCServerSoftware";
                Screen.Print("     -Installing into custom directory...", ConsoleColor.Yellow);
            }
            else if (input == "")
            {
                Screen.Print("     -Installing into default directory...", ConsoleColor.Yellow);
                installDir = installDir + @"\MCServerSoftware";
            }
            else
            {
                Screen.Print("     -That directory does not exist, installing into default directory...", ConsoleColor.Yellow);
                installDir = installDir + @"\MCServerSoftware";
            }

            spinner = new ConsoleSpinner();
            spinner.Start();
            if (Directory.Exists(installDir))
            {
                Installation.ClearInstallDir(installDir);
            }
            else
            {
                Directory.CreateDirectory(installDir);
            }
            await Installation.CreateBaseData(installDir);

            await Installation.DownloadLatestRelease(installDir);
            Installation.CreateEnvVariable(installDir);
            spinner.Stop();
            Screen.Print("\r     -Finished installing                 ", ConsoleColor.Yellow);
            
            Screen.PrintLn("\n::Installation successful!", ConsoleColor.Yellow);
            Console.ReadKey(true);
        }
    }
}