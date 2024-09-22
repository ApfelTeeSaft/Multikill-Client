using System;
using System.IO;
using System.Runtime.InteropServices;
using UnityEngine;

namespace Multikill.Multikill
{
    public class ConsoleManager
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool AllocConsole();

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool FreeConsole();

        private bool consoleVisible = false;

        public void InitializeConsole()
        {
            if (AllocConsole())
            {
                var writer = new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = true };
                Console.SetOut(writer);
                Console.SetError(writer);

                Debug.Log("Console allocated.");
                Application.logMessageReceived += HandleLog;
            }
        }

        private void HandleLog(string logString, string stackTrace, LogType type)
        {
            Console.WriteLine($"{type}: {logString}");
            if (type == LogType.Exception)
            {
                Console.WriteLine(stackTrace);
            }
        }

        public void ToggleConsole()
        {
            consoleVisible = !consoleVisible;
            if (consoleVisible)
            {
                AllocConsole();
            }
            else
            {
                FreeConsole();
            }
        }

        public void Cleanup()
        {
            Application.logMessageReceived -= HandleLog;
            FreeConsole();
        }
    }
}