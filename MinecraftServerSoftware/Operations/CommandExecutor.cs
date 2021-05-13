using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using MinecraftServerSoftware.Servers;
using MinecraftServerSoftware.Utils;

namespace MinecraftServerSoftware.Operations
{
    internal class CommandExecutor
    {
        private static readonly Screen Screen = new();
        private static readonly Servers.Servers Servers = new();
        private static Paper Paper = new();
        private static CommandOrganizer CommandOrganizer = new();

        public static void ExecuteCommands(List<CommandOrganizer.Operation> commands)
        {
            foreach (var command in commands)
                switch (command)
                {
                    case CommandOrganizer.Operation.Help:
                        OperationManager.PrintHelpMenu();
                        break;
                    case CommandOrganizer.Operation.Create:
                        try
                        {
                            if (Servers.ServerExists(CommandOrganizer.arguments[0]))
                            {
                                Screen.PrintLn("\nThis server already exists", ConsoleColor.Green);
                                Environment.Exit(0);
                            }

                            OperationManager.CreateServer(CommandOrganizer.arguments[CommandOrganizer.arguments.ToArray().Length - 1]);
                        }
                        catch (Exception ex)
                        {
                            Screen.PrintLn(ex.ToString(), ConsoleColor.Red);
                        }

                        break;
                    case CommandOrganizer.Operation.Delete:
                        try
                        {
                            OperationManager.DeleteServer(CommandOrganizer.arguments[0]);
                        }
                        catch (Exception ex)
                        {
                            Screen.PrintLn(ex.ToString(), ConsoleColor.Red);
                        }

                        break;
                    case CommandOrganizer.Operation.Start:
                        if (Servers.ServerExists(CommandOrganizer.arguments[0]) && Servers.ServerRunning() == false)
                        {
                            Screen.PrintLn(
                                "\n::The server will start in 5 seconds, type 'stop' into the console to shut the server down",
                                ConsoleColor.Green);
                            Thread.Sleep(5000);
                            OperationManager.StartServer(CommandOrganizer.arguments[0]);
                        }
                        else if (Servers.ServerRunning())
                        {
                            Screen.PrintLn("\n::A server is already running", ConsoleColor.Red);
                            Environment.Exit(0);
                        }
                        else
                        {
                            Screen.PrintLn("\n::Server cannot be found, did you spell the name correctly?",
                                ConsoleColor.Red);
                        }

                        break;
                    case CommandOrganizer.Operation.CheckVersion:
                        OperationManager.CheckServerVersion(CommandOrganizer.arguments[0]);
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
                    case CommandOrganizer.Operation.Uninstall:
                        OperationManager.Uninstall();
                        break;
                    case CommandOrganizer.Operation.Update:
                        OperationManager.Update(CommandOrganizer.arguments[CommandOrganizer.arguments.ToArray().Length - 1]);
                        break;
                    case CommandOrganizer.Operation.Plugin:
                        if (Servers.ServerExists(CommandOrganizer.arguments[CommandOrganizer.arguments.ToArray().Length - 1]))
                        {
                            OperationManager.Plugin(CommandOrganizer.arguments[CommandOrganizer.arguments.ToArray().Length - 1]);
                        }
                        else
                        {
                            Screen.Print("\n::Server does not exist \n", ConsoleColor.Green);
                        }
                        break;
                }
        }
    }
}