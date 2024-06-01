using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QUIZ.DAL
{
    class DBConnection
    {
        private MySqlConnectionStringBuilder stringBuilder =
            new MySqlConnectionStringBuilder();

        private static DBConnection instance = null;
        public static DBConnection Instance
        {
            get
            {
                instance = new DBConnection();
                return instance;
            }
        }

        private MySqlConnection connection;
        public MySqlConnection Connection => connection;//new MySqlConnection(stringBuilder.ToString());


        private DBConnection()
        {

            //stworzenie connection stringa na podstawie danych zapisanych w Settings do których mamy dostęp spoza aplikacji 
            stringBuilder.UserID = Properties.Settings.Default.userID;
            stringBuilder.Server = Properties.Settings.Default.server;
            stringBuilder.Database = Properties.Settings.Default.database;
            stringBuilder.Port = Properties.Settings.Default.port;
            stringBuilder.Password = Properties.Settings.Default.paswd;

            connection = new MySqlConnection(stringBuilder.ToString());
        }
    }
}
