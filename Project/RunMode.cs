using System;
using System.IO;

namespace FilesRenamer
{
    internal class RunMode
    {
        public static void Guided()
        {
            Console.Write("Especifique o RM antigo: ");
            string oldRM = Console.ReadLine();

            if (!Directory.Exists(oldRM))
            {
                Console.WriteLine($"A pasta do RM atual fornecida \"{oldRM}\" não existe\n" +
                $"Certifique-se de que a pasta \"{oldRM}\" contendo o(s) projeto(s) está no mesmo diretório deste executável");
                Console.ReadKey();
                return;
            }

            Console.Write("Especifique o RM novo: ");
            string newRM = Console.ReadLine();

            if (Directory.Exists(newRM))
            {
                Console.WriteLine($"A pasta do RM novo fornecida \"{newRM}\" já existe. O que você deseja fazer?" +
                $"\n 1 - Renomear a pasta \"{newRM}\" para \"{newRM}_old\"" +
                $"\n 2 - Apagar a pasta \"{newRM}\"" +
                $"\n 3 - Cancelar a operação\n" +
                $"\nDigite o número da opção desejada: ");
                string option = Console.ReadLine().ToUpper();

                if (option == "1") Directory.Move(newRM, newRM + "_old");
                else if (option == "2") Directory.Delete(newRM, true);
                else return;
            }

            Edit.Rename(oldRM, oldRM, newRM);
            Console.WriteLine("Concluído");
        }

        public static void Advanced(string[] args)
        {
            string oldPath = "";
            string oldRM = "";
            string newRM = "";

            for (int i = 0; i < args.Length; i += 2)
            {
                if (args[i] == "-p" || args[i] == "--path") oldPath = args[i + 1];
                else if (args[i] == "-o" || args[i] == "--old") oldRM = args[i + 1];
                else if (args[i] == "-n" || args[i] == "--new") newRM = args[i + 1];

                else
                {
                    Console.WriteLine(@"Modo de uso: FilesRenamer.exe -p <diretório> -o <RM antigo> -n <RM novo>\n
                    -p --path  Diretório onde estão os projetos (opcional. por padrão o mesmo do executável)\n
                    -o --old   RM antigo\n
                    -n --new   RM novo\n
                    
                    Exemplo: FilesRenamer.exe -p C:\\Users\\User\\Desktop\\projetos -o 35013 -n 36666");
                    return;
                }
            }

            if (oldPath == "") oldPath = oldRM;

            foreach (string variable in new string[] { oldPath, oldRM, newRM })
            {
                if (variable == "")
                {
                    Console.WriteLine("Um ou mais argumentos não foram fornecidos");
                    return;
                }
            }

            Edit.Rename(oldPath, oldRM, newRM);
            Console.WriteLine("Concluído");

        }

    }
}