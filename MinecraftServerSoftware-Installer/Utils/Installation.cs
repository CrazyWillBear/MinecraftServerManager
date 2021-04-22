using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Octokit;

namespace MinecraftServerSoftware_Installer.Utils
{
    public class Installation
    {
        public static async Task DownloadLatestRelease(string destination)
        {
            string[] files = Directory.GetFiles(destination);
            foreach (string file in files)
            {
                File.Delete(file);
            }
            
            GitHubClient client = new GitHubClient(new ProductHeaderValue("MinecraftServerSoftware-Installer"));
            var releases = await client.Repository.Release.GetAll("CrazyWillBear", "MinecraftServerManager");
            var latest = releases[0];
            WebClient wc = new WebClient();
            wc.DownloadFile("https://github.com/CrazyWillBear/MinecraftServerManager/releases/download/" + latest.TagName + "/" + latest.TagName + ".zip", destination + @"\MCServerSoftware.zip");
            System.IO.Compression.ZipFile.ExtractToDirectory(destination + @"\MCServerSoftware.zip", destination);
            File.Delete(destination + @"\MCServerSoftware.zip");
        }
        public static void CreateBaseData(string installDir)
        {
            Directory.CreateDirectory(@"C:\Users\" + Environment.UserName + @"\AppData\Roaming\MCServerSoftware");
            Directory.CreateDirectory(@"C:\Users\" + Environment.UserName + @"\AppData\Roaming\MCServerSoftware\dat");
            File.WriteAllText(@"C:\Users\" + Environment.UserName + @"\AppData\Roaming\MCServerSoftware\dat\installDir.dat", installDir);
        }
        public static void CreateEnvVariable(string destination)
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
                newValue.Add(destination);
                Environment.SetEnvironmentVariable("Path", string.Join(";", newValue.ToArray()), EnvironmentVariableTarget.Machine);
            }
        }
    }
}