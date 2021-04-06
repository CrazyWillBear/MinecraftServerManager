using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using MinecraftServerSoftware.Servers;
using MinecraftServerSoftware.Utils;

namespace MinecraftServerSoftware.Operations
{
    public class OperationManager
    {
        private static readonly Screen Screen = new();
        private static readonly Paper Paper = new();
        private static readonly Servers.Servers Servers = new();
        private static readonly ServerJars ServerJars = new();

        public static void CreateServer(string servername)
        {
            Screen.Print("\n::What Minecraft version would you like the server to be? >> ", ConsoleColor.Green);
            var chosenversion = Console.ReadLine();
            Directory.CreateDirectory("./server/" + servername);

            if (!Paper.DoesVersionExist(chosenversion) && !CommandOrganizer.useSpigotOnly &&
                !CommandOrganizer.useBukkitOnly &&
                !CommandOrganizer.useVanillaOnly)
                Screen.Print("\n     -Creating Paper server jar... (FAILED)\n", ConsoleColor.Red);
            if ((CommandOrganizer.useSpigotOnly || !Paper.DoesVersionExist(chosenversion) &&
                !CommandOrganizer.useBukkitOnly && !CommandOrganizer.useVanillaOnly &&
                !CommandOrganizer.usePaperOnly) && ServerJars.InstallSpigotJar(chosenversion, servername))
            {
            }
            else if ((CommandOrganizer.useBukkitOnly || !Paper.DoesVersionExist(chosenversion) &&
                !CommandOrganizer.useSpigotOnly && !CommandOrganizer.useVanillaOnly &&
                !CommandOrganizer.usePaperOnly) && ServerJars.InstallBukkitJar(chosenversion, servername))
            {
            }
            else if ((CommandOrganizer.useVanillaOnly || !Paper.DoesVersionExist(chosenversion) &&
                         !CommandOrganizer.useBukkitOnly && !CommandOrganizer.useSpigotOnly &&
                         !CommandOrganizer.usePaperOnly) &&
                     ServerJars.InstallVanillaJar(chosenversion, servername))
            {
            }
            else if (Paper.DoesVersionExist(chosenversion) && Paper.InstallPaperJar(chosenversion, servername))
            {
            }
            else
            {
                Screen.Print("\r::ERROR: This version is not available", ConsoleColor.Red);
                Directory.Delete("./server/" + servername);
                Environment.Exit(0);
            }

            // creating start.bat
            Screen.Print("\r::How much dedicated RAM (in gigs) would you like the server to have? (default is 2G) >> ",
                ConsoleColor.Green);
            var dedicatedram = Console.ReadLine();
            Screen.Print("     -Assigning dedicated RAM...", ConsoleColor.Green);
            if (dedicatedram == "") dedicatedram = "2";
            File.WriteAllText("./server/" + servername + "/start.bat",
                "java -Xmx" + dedicatedram + "G -Xms1024M -jar server.jar nogui");
            Screen.Print("\r     -Assigned dedicated RAM        ", ConsoleColor.Green);

            //agreeing to EULA
            Screen.Print("\n::Do you agree to the EULA? Type `agree` to confirm you agree to the EULA >> ",
                ConsoleColor.Green);
            var input = Console.ReadLine();
            ConsoleSpinner spinner;
            if (input.ToLower() == "agree")
            {
                Screen.Print("     -Generating EULA text file...", ConsoleColor.Green);
                spinner = new ConsoleSpinner();
                spinner.Start();
                SilentStartServer(servername);
                spinner.Stop();
                Screen.Print("\r     -Generated EULA text file    ", ConsoleColor.Green);
            }
            else
            {
                Screen.PrintLn("You have not agreed to the EULA, thus ending the process", ConsoleColor.Red);
                Directory.Delete("./server/" + servername, true);
                Environment.Exit(0);
            }

            Screen.Print("\n     -Agreeing to EULA...", ConsoleColor.Green);
            spinner = new ConsoleSpinner();
            spinner.Start();
            var eula = File.ReadAllText("./server/" + servername + "/eula.txt");
            eula = eula.Replace("false", "true");
            File.WriteAllText("./server/" + servername + "/eula.txt", eula);
            spinner.Stop();
            Screen.Print("\r     -Agreed to EULA     ", ConsoleColor.Green);

            // starting or saving server
            Screen.PrintLn("\nWould you like to start the server? (Y/N) >> ", ConsoleColor.Green);
            var key = Console.ReadKey(true);
            if (key.KeyChar == 'y')
            {
                Screen.PrintLn("Your server will start in 5 seconds. To stop the server, type `stop` into the console",
                    ConsoleColor.Green);
                Thread.Sleep(5000);
                StartServer(servername);
            }
            else
            {
                Screen.PrintLn("Use the start command to start your server at any time", ConsoleColor.Green);
            }
        }

        public static void DeleteServer(string servername)
        {
            if (Directory.Exists(@".\server\" + servername))
            {
                Screen.PrintLn("\n::Are you sure you would like to delete '" + servername + "'? (Y/N)",
                    ConsoleColor.Green);
                var key = Console.ReadKey(true);
                if (key.KeyChar != 'y')
                {
                    Screen.PrintLn("     -Cancelled", ConsoleColor.Green);
                    Environment.Exit(0);
                }
            }
            else
            {
                Screen.PrintLn("\n::Server does not exist", ConsoleColor.Red);
                Environment.Exit(0);
            }

            Screen.Print("     -Attempting to delete '" + servername + "'...", ConsoleColor.Green);
            if (Servers.ServerRunning())
            {
                Screen.PrintLn(
                    "     -You cannot delete the server while it is running, to stop the server type 'stop' into the server console",
                    ConsoleColor.Red);
                Environment.Exit(0);
            }

            Directory.Delete(@".\server\" + servername, true);
            Screen.PrintLn("\r     -Successfully deleted '" + servername + "'              ", ConsoleColor.Green);
        }

        public static void ListServers()
        {
            Screen.PrintLn("\n::Servers", ConsoleColor.Green);
            foreach (var folder in Directory.GetDirectories(@".\server\"))
                Screen.PrintLn("     -" + folder.Split('\\')[2], ConsoleColor.Green);
        }

        public static void SilentStartServer(string servername)
        {
            Process proc = null;
            Environment.CurrentDirectory = Program.programdirectory + @"\server\" + servername;
            var _batDir = string.Format(Program.programdirectory + @"\server\" + servername);
            proc = new Process();
            proc.StartInfo.WorkingDirectory = _batDir;
            proc.StartInfo.FileName = "start.bat";
            proc.StartInfo.CreateNoWindow = true;
            proc.Start();
            proc.WaitForExit();
            proc.Close();
            Environment.CurrentDirectory = Program.programdirectory;
        }

        public static void StartServer(string servername)
        {
            var p = new Process();
            p.StartInfo.UseShellExecute = true;
            p.StartInfo.CreateNoWindow = false;
            p.StartInfo.FileName = "start.bat";
            Environment.CurrentDirectory = Program.programdirectory + @"\server\" + servername;
            p.Start();
        }
    }
}