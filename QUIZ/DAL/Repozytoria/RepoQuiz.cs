using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QUIZ.DAL.Repozytoria
{
    using Encje;
    using MySql.Data.MySqlClient;

    class RepoQuiz
    {
        private const string ALL_QUIZZES = "SELECT * FROM quizy";
        private const string ADD_QUIZ =
            "INSERT INTO `quizy` VALUES ";
        public static List<Quiz> GetAllQuizes()
        {
            List<Quiz> quizzes = new List<Quiz>();

            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand(ALL_QUIZZES, connection);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                    quizzes.Add(new Quiz(reader));
                connection.Close();
            }

            return quizzes;
        }

        public static bool AddQuizToDatabase(Quiz quiz)
        {
            bool check = false;
            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command =
                    new MySqlCommand($"{ADD_QUIZ} {quiz.ToInsert()}", connection);
                connection.Open();
                var n = command.ExecuteNonQuery();
                check = true;
                quiz.Id = (sbyte)command.LastInsertedId;
                connection.Close();
            }
            return check;
        }
    }
}
