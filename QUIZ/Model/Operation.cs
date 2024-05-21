using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace QUIZ.QUIZ.Model
{
    class Operation
    {
        private string connectionString;
        public Operation()
        {
            // Pobieranie connection string z App.config
            connectionString = ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString;
        }

        public void TestConnection()
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    Console.WriteLine("Połączenie do bazy danych zostało otwarte.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Błąd połączenia: {ex.Message}");
                }
            }
        }
    }
}
