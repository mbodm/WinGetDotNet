﻿using System.Diagnostics;
using WinGetDotNet;

namespace WinGetDotNetTestHost
{
    internal static class Tests
    {
        public static bool WinGetIsInstalled()
        {
            var winGet = new WinGet();

            return winGet.WinGetIsInstalled;
        }

        public static async Task RunWinGetAsync(string command, string[] packages, bool concurrentMode, bool silentMode)
        {
            var stopwatch = new Stopwatch();

            var winGet = new WinGet();

            stopwatch.Start();

            if (concurrentMode)
            {
                var tasks = packages.Select(async package =>
                {
                    var result = await winGet.RunWinGetAsync($"{command} --exact --id {package}");

                    if (!silentMode) ShowResult(result);

                    return result;
                });

                await Task.WhenAll(tasks);
            }
            else
            {
                foreach (var package in packages)
                {
                    var result = await winGet.RunWinGetAsync($"{command} --exact --id {package}");

                    if (!silentMode) ShowResult(result);
                }
            }

            stopwatch.Stop();

            ShowDuration(command, stopwatch.Elapsed.Seconds);
        }

        public static async Task<bool> TimeoutAsync(int seconds)
        {
            var winGet = new WinGet();

            try
            {
                var result = await winGet.RunWinGetAsync("search", TimeSpan.FromSeconds(seconds));
                ShowResult(result);

                return false;
            }
            catch (WinGetException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine();

                return true;
            }
        }

        private static void ShowResult(WinGetResult result)
        {
            Console.WriteLine(result.ProcessCall);
            Console.WriteLine(result.ConsoleOutput);
            Console.WriteLine();
        }

        private static void ShowDuration(string command, int seconds)
        {
            Console.WriteLine("--------------------------------------------------------------------------------");
            Console.WriteLine($"{command.ToUpper()} finished after {seconds} seconds.");
            Console.WriteLine("--------------------------------------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}
