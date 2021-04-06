using System;
using System.Threading;

namespace MinecraftServerSoftware.Utils
{
    // Code taken from https://stackoverflow.com/questions/1923323/console-animations
    public class ConsoleSpinner
    {
        private const string Sequence = @"/-\|";
        private readonly int delay = 100;
        private readonly Thread thread;
        private bool active;
        private int counter;

        public ConsoleSpinner()
        {
            thread = new Thread(Spin);
        }

        public void Start()
        {
            active = true;
            if (!thread.IsAlive)
                thread.Start();
        }

        public void Stop()
        {
            active = false;
            Draw(' ');
        }

        private void Spin()
        {
            while (active)
            {
                Turn();
                Thread.Sleep(delay);
            }
        }

        private void Draw(char c)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("\r" + c);
        }

        private void Turn()
        {
            Draw(Sequence[++counter % Sequence.Length]);
        }

        public void Dispose()
        {
            Stop();
        }
    }
}