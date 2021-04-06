using System;

namespace MinecraftServerSoftware_Installer.Utils
{
    public class Screen
    {
        public static void PrintLn(string text, ConsoleColor color = ConsoleColor.Gray)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        public static void Print(string text, ConsoleColor color = ConsoleColor.Gray)
        {
            Console.ForegroundColor = color;
            Console.Write(text);
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        public static void PrintBigLogo()
        {
            Screen.PrintLn(@" ___  ________   ________  _________  ________  ___       ___       _______   ________     ", ConsoleColor.Green);
            Screen.PrintLn(@"|\  \|\   ___  \|\   ____\|\___   ___\\   __  \|\  \     |\  \     |\  ___ \ |\   __  \   ", ConsoleColor.Green);
            Screen.PrintLn(@"\ \  \ \  \\ \  \ \  \___|\|___ \  \_\ \  \|\  \ \  \    \ \  \    \ \   __/|\ \  \|\  \   ", ConsoleColor.Green);
            Screen.PrintLn(@" \ \  \ \  \\ \  \ \_____  \   \ \  \ \ \   __  \ \  \    \ \  \    \ \  \_|/_\ \   _  _\  ", ConsoleColor.Green);
            Screen.PrintLn(@"  \ \  \ \  \\ \  \|____|\  \   \ \  \ \ \  \ \  \ \  \____\ \  \____\ \  \_|\ \ \  \\  \| ", ConsoleColor.Green);
            Screen.PrintLn(@"   \ \__\ \__\\ \__\____\_\  \   \ \__\ \ \__\ \__\ \_______\ \_______\ \_______\ \__\\ _\ ", ConsoleColor.Green);
            Screen.PrintLn(@"    \|__|\|__| \|__|\_________\   \|__|  \|__|\|__|\|_______|\|_______|\|_______|\|__|\|__|", ConsoleColor.Green);
            Screen.PrintLn(@"                   \|_________|                                                            ", ConsoleColor.Green);
        }
    }
}