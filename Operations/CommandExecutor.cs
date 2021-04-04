using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MinecraftServerSoftware.Operations
{
    class CommandExecutor
    {
        static Utils.Screen Screen = new Utils.Screen();
        static Servers.Servers Servers = new Servers.Servers();
        static Servers.Paper Paper = new Servers.Paper();
        public static void ExecuteCommands(List<CommandOrganizer.Operation> commands)
        {

            foreach (CommandOrganizer.Operation command in commands)
            {
                switch (command)
                {
                    case CommandOrganizer.Operation.Create:
                        try
                        {
                            if (Servers.ServerExists(Program.arguments[1]))
                            {
                                Screen.PrintLn("\nThis server already exists", ConsoleColor.Green);
                                Environment.Exit(0);
                            }
                            OperationManager.CreateServer(Program.arguments[Program.arguments.Length - 1]);
                        }
                        catch (Exception ex)
                        {
                            Screen.PrintLn(ex.ToString(), ConsoleColor.Red);
                        }
                        break;
                    case CommandOrganizer.Operation.Delete:
                        try
                        {
                            OperationManager.DeleteServer(Program.arguments[1]);
                        }
                        catch (Exception ex)
                        {
                            Screen.PrintLn(ex.ToString(), ConsoleColor.Red);
                        }
                        break;
                    case CommandOrganizer.Operation.Start:
                        if (Servers.ServerExists(Program.arguments[1]) && Servers.ServerRunning() == false)
                        {
                            Screen.PrintLn("\n::The server will start in 5 seconds, type 'stop' into the console to shut the server down", ConsoleColor.Green);
                            Thread.Sleep(5000);
                            OperationManager.StartServer(Program.arguments[1]);
                        }
                        else if (Servers.ServerRunning())
                        {
                            Screen.PrintLn("\n::A server is already running", ConsoleColor.Red);
                            Environment.Exit(0);
                        }
                        else
                        {
                            Screen.PrintLn("\n::Server cannot be found, did you spell the name correctly?", ConsoleColor.Red);
                        }
                        break;
                    case CommandOrganizer.Operation.CheckVersion:
                        break;
                    case CommandOrganizer.Operation.WipeWorld:
                        break;
                    case CommandOrganizer.Operation.ListServers:
                        if (Directory.GetDirectories(@".\server\").Length < 1)
                        {
                            Screen.PrintLn("\n::There are no servers on this computer", ConsoleColor.Green);
                            Environment.Exit(0);
                        }
                        OperationManager.ListServers();
                        break;
                }
            }
        }
    }
}
