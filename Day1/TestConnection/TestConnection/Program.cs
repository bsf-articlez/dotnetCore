using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConnection
{
    class Program
    {
        static void Main(string[] args)
        {
            int rowNumber = 1;
            ConnectionStringSettingsCollection conStrings = ConfigurationManager.ConnectionStrings;
            Console.Write("Test Connection Start ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("!");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("!");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("!\n");
            foreach (ConnectionStringSettings collection in conStrings)
            {
                if (rowNumber == 1) goto EndForeach;

                string[] collectionSplit = collection.ConnectionString.Split(';');

                Console.ResetColor();
                Console.Write($"Running connection to ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("[");
                Console.ResetColor();

                Console.Write($"{collectionSplit[0]}, {collectionSplit[1]}");

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("]");
                Console.ResetColor();
                Console.Write(" ...");

                using (SqlConnection connection = new SqlConnection(collection.ConnectionString))
                {
                    try
                    {
                        connection.Open();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(":: Success\n\n");
                    }
                    catch (SqlException ex)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(":: Fail");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.WriteLine($"{ex.Message}\n");
                    }
                }

                EndForeach:
                rowNumber++;
            }
            Console.ResetColor();
            Console.Write("Done ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("!");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("!");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("!\n");
            Console.ReadKey();
        }
    }
}
