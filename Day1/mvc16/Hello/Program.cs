using System;

namespace Hello
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = "World"; 
            if (args.Length > 0)
            {
                name = args[0];
            }
            
            Console.WriteLine($"Hello {name}!");
        }
    }
}
