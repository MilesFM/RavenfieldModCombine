using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;

namespace RavenfieldModCombine
{
    static class Commands
    {
        public static void ILMergeCMD(string cmd)
        {
            if (!Program.installed)
            {
                CMD("ILMerge.exe " + cmd);
            }
            else
            {
                CMD("ILMERGE " + cmd);
            }
        }
        /// <summary>
        /// For CMD commands
        /// </summary>
        /// <param name="cmd">The command to be inputed</param>
        public static void CMD(string cmd)
        {
            Process.Start("C:\\WINDOWS\\system32\\cmd.exe ", cmd);
        }
        /// <summary>
        /// Starts Ravenfield and tests catches errors like 'ravenfield.exe' not existing
        /// </summary>
        public static void StartRavenfield()
        {
            try
            {
                Process.Start("ravenfield.exe");
                Environment.Exit(0);
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
                Console.ReadKey();
            }
        }

        /// <summary>
        /// For returning the current directory and adding it onto the directory.file location
        /// </summary>
        /// <param name="dire"></param>
        /// <returns>Directory/File</returns>
        public static string Dire(string dire)
        {
            return Directory.GetCurrentDirectory() + dire;
        }
        /// <summary>
        /// Tests if directory exists
        /// </summary>
        /// <param name="dire">Directory</param>
        /// <returns></returns>
        public static bool DireEx(string dire)
        {
            if (Directory.Exists(Dire(dire)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool FileEx(string file)
        {
            if (Directory.Exists(Dire(file)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
