using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;

namespace MinecraftServerSoftware.Operations
{
    internal class CommandOrganizer
    {
        public enum Operation
        {
            Create,
            Delete,
            Start,
            CheckVersion,
            WipeWorld,
            ListServers,
            Uninstall,
            Update,
            Plugin,
            Help
        }

        public static bool usePaperOnly;
        public static bool useVanillaOnly;
        public static bool useSpigotOnly;
        public static bool useBukkitOnly;
        public static bool openPluginConfig;
        public static List<string> arguments = new List<string>();

        public static List<Operation> ParseCommand(string[] args)
        {
            var operationList = new List<Operation>();

            foreach (string arg in Program.arguments)
            {
                if (arg.ToCharArray()[0] == '-')
                {
                    switch (arg)
                    {
                        case "--create":
                        case "-c":
                            operationList.Add(Operation.Create);
                            break;
                        case "--delete":
                        case "-d":
                            operationList.Add(Operation.Delete);
                            break;
                        case "--start":
                        case "-s":
                            operationList.Add(Operation.Start);
                            break;
                        case "--checkversion":
                        case "-V":
                            operationList.Add(Operation.CheckVersion);
                            break;
                        case "--wipeworld":
                        case "-w":
                            operationList.Add(Operation.WipeWorld);
                            break;
                        case "--paper":
                        case "-p":
                            usePaperOnly = true;
                            break;
                        case "--vanilla":
                        case "-v":
                            useVanillaOnly = true;
                            break;
                        case "--bukkit":
                        case "-b":
                            useBukkitOnly = true;
                            break;
                        case "--spigot":
                        case "-S":
                            useSpigotOnly = true;
                            break;
                        case "--config":
                        case "-C":
                            openPluginConfig = true;
                            break;
                        case "--list":
                        case "-l":
                            operationList.Add(Operation.ListServers);
                            break;
                        case "--uninstall":
                            operationList.Add(Operation.Uninstall);
                            break;
                        case "--update":
                        case "-u":
                            operationList.Add(Operation.Update);
                            break;
                        case "--plugin":
                        case "-P":
                            operationList.Add(Operation.Plugin);
                            break;
                        case "--help":
                        case "-h":
                            operationList.Add(Operation.Help);
                            break;
                    }
                }
                else if (arg.ToCharArray()[0] != '-')
                {
                    CommandOrganizer.arguments.Add(arg);
                }
            }

            return operationList;
        }
    }
}