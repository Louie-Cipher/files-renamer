using System;

namespace FilesRenamer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0) RunMode.Guided();
            else RunMode.Advanced(args);
        }
    }
}