using System;
using System.IO;

namespace FilesRenamer
{
    internal class Program
    {
        static void Main()
        {
            Console.Write("Especifique o RM antigo: ");
            string oldRM = Console.ReadLine();

            if (!Directory.Exists(oldRM))
            {
                Console.WriteLine($"A pasta do RM atual fornecida \"{oldRM}\" não existe");
                Console.WriteLine($"Certifique-se de que a pasta \"{oldRM}\" está no mesmo diretório deste programa");
                return;
            }

            Console.Write("Especifique o RM novo: ");
            string newRM = Console.ReadLine();

            foreach (string file in Directory.GetFiles(oldRM, "*", SearchOption.AllDirectories))
            {
                if (file.Contains(".vs") || file.Contains("bin") || file.Contains("obj")) continue;

                string newFile = file.Replace(oldRM, newRM);
                Directory.CreateDirectory(Path.GetDirectoryName(newFile));

                File.Copy(file, newFile);
                string content = File.ReadAllText(file).Replace(oldRM, newRM);
                File.WriteAllText(newFile, content);
            }

            Console.WriteLine("Concluído");
        }
    }
}
