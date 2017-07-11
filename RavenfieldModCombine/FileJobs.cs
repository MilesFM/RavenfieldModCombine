using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace RavenfieldModCombine
{
    static class FileJobs
    {
        public static void Reset()
        {
            if (Commands.DireEx("ravenfield_Data\\Managed\\Assembly-CSharp-NORMAL.dll") && Commands.DireEx("ravenfield_Data\\Managed\\Assembly-CSharp.dll"))
            {
                File.Delete(Commands.Dire("ravenfield_Data\\Managed\\Assembly-CSharp.dll"));
                File.Move(Commands.Dire("ravenfield_Data\\Managed\\Assembly-CSharp-NORMAL.dll"), Commands.Dire("ravenfield_Data\\Managed\\Assembly-CSharp.dll"));
            }
            else if (Commands.DireEx("ravenfield_Data\\Managed\\Assembly-CSharp-NORMAL.dll"))
            {
                File.Move(Commands.Dire("ravenfield_Data\\Managed\\Assembly-CSharp-NORMAL.dll"), "ravenfield_Data\\Managed\\Assembly-CSharp.dll");
            }
            Commands.StartRavenfield();
        }
        public static void InstallMods()
        {
            string[] modFiles = Directory.GetFiles(Commands.Dire("Mods\\"), "*.dll", SearchOption.TopDirectoryOnly);
            // Addes each mod into the game. Also checks if assemblies exist. Thus the try, catch statement.
            try
            {
                foreach (string mod in modFiles)
                {
                    Commands.ILMergeCMD(Commands.Dire("ravenfield_Data\\Managed\\Assembly-CSharp.dll ") + mod + " /out:" + "ravenfield_Data\\Managed\\Assembly-CSharp.dll " + "/target:winexe /targetplatform:'v3.5,C:\\Program Files (x86)\\Reference Assemblies\\Microsoft\\Framework\\.NETFramework\\v3.5");
                }
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }

            if (!(Commands.FileEx("ravenfield_Data\\Managed\\Assembly-CSharp.dll")))
            {
                File.Copy(Commands.Dire("ravenfield_Data\\Managed\\Assembly-CSharp.dll"), Commands.Dire("ravenfield_Data\\Managed\\Assembly-CSharp-NORMAL.dll"));
            }
            Commands.StartRavenfield();
        }
    }
}
