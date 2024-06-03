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

        public static bool EditQuiz(string? quizName, int? number_of_questions, int? idQuiz)
        {
            bool stan = false;
            using (var connection = DBConnection.Instance.Connection)
            {
                string EDIT_QUIZ =
                    $"UPDATE quizy SET name='{quizName}', number_of_questions='{number_of_questions}' WHERE id={idQuiz}";

                MySqlCommand command = new MySqlCommand(EDIT_QUIZ, connection);
                connection.Open();
                var n = command.ExecuteNonQuery();
                if (n == 1) stan = true;

                connection.Close();
            }
            return stan;
        }

        public static bool DeleteQuiz(int? idQuiz)
        {
            bool stan = false;
            using (var connection = DBConnection.Instance.Connection)
            {
                string DELETE_QUIZ =
                    $"Delete from quizy WHERE id={idQuiz}";

                MySqlCommand command = new MySqlCommand(DELETE_QUIZ, connection);
                connection.Open();
                var n = command.ExecuteNonQuery();
                if (n == 1) stan = true;

                connection.Close();
            }
            return stan;
        }
    }
}
