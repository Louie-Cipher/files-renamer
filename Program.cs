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
                Console.WriteLine($"Certifique-se de que a pasta \"{oldRM}\" contendo o(s) projeto(s) está no mesmo diretório deste executável");
                return;
            }

            Console.Write("Especifique o RM novo: ");
            string newRM = Console.ReadLine();

            if (Directory.Exists(newRM))
            {
                Console.WriteLine($"A pasta do RM novo fornecida \"{newRM}\" já existe. O que você deseja fazer?" +
                $"\n 1 - Renomear a pasta \"{newRM}\" para \"{newRM}(1)\"" +
                $"\n 2 - Apagar a pasta \"{newRM}\"" +
                $"\n 3 - Cancelar a operação\n" +
                $"\nDigite o número da opção desejada: ");
                string option = Console.ReadLine().ToUpper();

                if (option == "1") Directory.Move(newRM, newRM + "(1)");
                else if (option == "2") Directory.Delete(newRM, true);
                else return;
            }

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
