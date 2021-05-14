using System;
using System.Collections.Generic;
using System.IO;

namespace MinecraftServerSoftware_Uninstaller.Utils
{
    public class Uninstall
    {
        public static void UninstallPreserveData(string destination)
        {
            RemoveEnvVar(destination);
            Directory.Delete(destination, true);
        }

        public static void RemoveEnvVar(string destination)
        {
            List<string> newValue = new List<string>();
            if (!Environment.GetEnvironmentVariable("Path", EnvironmentVariableTarget.Machine).Contains(destination))
            {
                foreach (string variable in Environment.GetEnvironmentVariable("Path", EnvironmentVariableTarget.Machine).Split(';'))
                {
                    if (variable == destination) { }
                    else
                    {
                        newValue.Add(variable);
                    }
                }
                Environment.SetEnvironmentVariable("Path", string.Join(";", newValue.ToArray()), EnvironmentVariableTarget.Machine);
            }
        }
    }
}