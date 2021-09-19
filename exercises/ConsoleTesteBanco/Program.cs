using System;
using MySql.Data.MySqlClient;

namespace ConsoleTesteBanco
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            MySqlConnection conn = new MySqlConnection("server=localhost;user id=root;password=root;database=teste");
        }
    }
}
