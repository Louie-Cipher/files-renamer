using System;
using System.IO;

namespace FilesRenamer
{
    internal class Edit
    {
        public static void Rename(string oldPath, string oldRM, string newRM)
        {
            foreach (string file in Directory.GetFiles(oldPath, "*", SearchOption.AllDirectories))
            {
                if (file.Contains(".vs") || file.Contains("bin") || file.Contains("obj")) continue;

                string newFile = file.Replace(oldRM, newRM);
                Directory.CreateDirectory(Path.GetDirectoryName(newFile));

                File.Copy(file, newFile);
                string content = File.ReadAllText(file).Replace(oldRM, newRM);

                File.WriteAllText(newFile, content);
            }
        }
        
        static string GuidGen(string fileContent, bool isAssemblyInfo)
        {
            string split1 = isAssemblyInfo ? "[assembly: Guid(\"" : "<ProjectGuid>{";
            string split2 = isAssemblyInfo ? "\")]" : "}</ProjectGuid>}";

            string[] split = fileContent.Split(new string[] { split1 }, StringSplitOptions.None);

            if (split.Length < 1) return fileContent;

            string oldGuid = split[1].Split(new string[] { split2 }, StringSplitOptions.None)[0];

            string newGuid = Guid.NewGuid().ToString();

            newGuid = isAssemblyInfo ? newGuid.ToLower() : newGuid.ToUpper();

            return fileContent.Replace(oldGuid, newGuid);
        }

        static string GuidFinder(string fileContent)
        {
            string[] split = fileContent.Split(new string[] { "<ProjectGuid>{" }, StringSplitOptions.None);

            if (split.Length < 1) return null;

            string guid = split[1].Split(new string[] { "}</ProjectGuid>}" }, StringSplitOptions.None)[0];

            return guid;
        }

    }
}