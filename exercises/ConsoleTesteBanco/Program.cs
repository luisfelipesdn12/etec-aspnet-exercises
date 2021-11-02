using System;
using MySql.Data.MySqlClient;

namespace ConsoleTesteBanco
{
    class Program
    {
        static void Main(string[] args)
        {
            const string connectionString = "server=localhost;user id=luis;password=[passs];database=[database]";

            MySqlConnection conn = new MySqlConnection(connectionString);
            Console.WriteLine("Conectando ao banco de dados...");
            
            try
            {
                conn.Open();

                var command = conn.CreateCommand();
                command.CommandText = "SELECT * FROM product";

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Console.WriteLine($"{reader["id"]} - {reader["name"]} - {reader["price"]}");
                }

                Console.WriteLine("Conectado!");
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Erro: " + ex.Message);
            }
        }
    }
}
