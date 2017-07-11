using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace RavenfieldModCombine
{
    static class Program
    {
        // If the program is in the default location
        public static bool installed = false;
        static void Main(string[] args)
        {
            // Checks if ILMerge exsists
            if (!(Commands.DireEx("Mods\\")))
            {
                Directory.CreateDirectory(Commands.Dire("Mods\\"));
                Commands.StartRavenfield();
            }
            // If file does exsist but folder is empty, start Ravenfield
            else if (Directory.GetFiles(Commands.Dire("Mods\\"), "*.dll", SearchOption.TopDirectoryOnly) == null) 
            {
                System.Diagnostics.Process.Start("PathToExe.exe");
                Commands.StartRavenfield();
            }

            if (Commands.DireEx("ILMerge.exe"))
            {
                Start();
            }
            else if (File.Exists("C:\\Program Files (x86)\\Microsoft\\ILMerge\\ILMerge.exe"))
            {
                installed = true;
                Start();
            }
            else if (File.Exists("C:\\Program Files\\Microsoft\\ILMerge\\ILMerge.exe"))
            {
                installed = true;
                Start();
            }
            else
            {
                Console.WriteLine("Please download ILMerge.exe from: https://www.microsoft.com/en-au/download/details.aspx?id=17630");
                Console.ReadKey();
                Commands.CMD("START https://www.microsoft.com/en-au/download/details.aspx?id=17630");
            }
        }
        
        /// <summary>
        /// Starts the mod installing process
        /// </summary>
        public static void Start()
        {
            Console.WriteLine("To remove all mods from Ravenfield, please press 'r'. To install mods, press 'i'.");
            char key = Console.ReadKey().KeyChar;

            switch (key)
            {
                case 'r':
                    FileJobs.Reset();
                    break;
                case 'i':
                    FileJobs.InstallMods();
                    break;
                default:
                    Commands.StartRavenfield();
                    break;
            }
        }
    }
}
