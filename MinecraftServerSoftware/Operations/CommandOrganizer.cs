using System.Collections.Generic;

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
            Update
        }

        public static bool usePaperOnly;
        public static bool useVanillaOnly;
        public static bool useSpigotOnly;
        public static bool useBukkitOnly;

        public static List<Operation> ParseCommand(string[] args)
        {
            var operationList = new List<Operation>();

            if (args[0].ToCharArray()[0] == '-' && args[0].ToCharArray()[1] == '-')
                foreach (var arg in args)
                    switch (arg)
                    {
                        case "--create":
                            operationList.Add(Operation.Create);
                            break;
                        case "--delete":
                            operationList.Add(Operation.Delete);
                            break;
                        case "--start":
                            operationList.Add(Operation.Start);
                            break;
                        case "--checkversion":
                            operationList.Add(Operation.CheckVersion);
                            break;
                        case "--wipeworld":
                            operationList.Add(Operation.WipeWorld);
                            break;
                        case "--paper":
                            usePaperOnly = true;
                            break;
                        case "--vanilla":
                            useVanillaOnly = true;
                            break;
                        case "--bukkit":
                            useBukkitOnly = true;
                            break;
                        case "--spigot":
                            useSpigotOnly = true;
                            break;
                        case "--list":
                            operationList.Add(Operation.ListServers);
                            break;
                        case "--uninstall":
                            operationList.Add(Operation.Uninstall);
                            break;
                        case "--update":
                            operationList.Add(Operation.Update);
                            break;
                    }

            if (args[0].ToCharArray()[0] == '-' && args[0].ToCharArray()[1] != '-')
                foreach (var arg in args)
                    if (arg.Contains('-'))
                        foreach (var character in arg)
                            switch (character)
                            {
                                case 'c':
                                    operationList.Add(Operation.Create);
                                    break;
                                case 'd':
                                    operationList.Add(Operation.Delete);
                                    break;
                                case 's':
                                    operationList.Add(Operation.Start);
                                    break;
                                case 'e':
                                    operationList.Add(Operation.CheckVersion);
                                    break;
                                case 'w':
                                    operationList.Add(Operation.WipeWorld);
                                    break;
                                case 'l':
                                    operationList.Add(Operation.ListServers);
                                    break;
                                case 'p':
                                    usePaperOnly = true;
                                    break;
                                case 'v':
                                    useVanillaOnly = true;
                                    break;
                                case 'b':
                                    useBukkitOnly = true;
                                    break;
                                case 'g':
                                    useSpigotOnly = true;
                                    break;
                                case 'u':
                                    operationList.Add(Operation.Update);
                                    break;
                            }

            return operationList;
        }
    }
}