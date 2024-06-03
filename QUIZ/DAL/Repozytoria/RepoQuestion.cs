using MySql.Data.MySqlClient;
using QUIZ.DAL.Encje;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QUIZ.DAL.Repozytoria
{
    class RepoQuestion
    {
        private const string ALL_QUESTIONS = "SELECT * FROM questions";
        private const string ADD_QUESTIONS =
            "INSERT INTO `questions` VALUES ";
        public static List<Question> GetAllQuestions()
        {
            List<Question> questions = new List<Question>();

            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand(ALL_QUESTIONS, connection);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                    questions.Add(new Question(reader));
                connection.Close();
            }

            return questions;
        }

        public static bool AddQuestionToDatabase(Question question)
        {
            bool check = false;
            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command =
                    new MySqlCommand($"{ADD_QUESTIONS} {question.ToInsert()}", connection);
                connection.Open();
                var n = command.ExecuteNonQuery();
                check = true;
                question.Id_question = (sbyte)command.LastInsertedId;
                connection.Close();
            }
            return check;
        }

        public static List<Question> GetQuestionsByQuizId(int? idQuiz)
        {
            List<Question> questions = new List<Question>();
            string query = $"{ALL_QUESTIONS} WHERE id_quiz = @idQuiz";

            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@idQuiz", idQuiz);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                    questions.Add(new Question(reader));
                connection.Close();
            }

            return questions;
        }

        public static bool EditQuestion(string? questionText, int? idQuestion)
        {
            bool stan = false;
            using (var connection = DBConnection.Instance.Connection)
            {
                string EDIT_QUESTION =
                    $"UPDATE questions SET text='{questionText}' WHERE id_question={idQuestion}";

                MySqlCommand command = new MySqlCommand(EDIT_QUESTION, connection);
                connection.Open();
                var n = command.ExecuteNonQuery();
                if (n == 1) stan = true;

                connection.Close();
            }
            return stan;
        }

        public static bool DeleteQuestion(int? idQuestion)
        {
            bool stan = false;
            using (var connection = DBConnection.Instance.Connection)
            {
                string DELETE_QUESTION =
                    $"Delete from questions WHERE id_question={idQuestion}";

                MySqlCommand command = new MySqlCommand(DELETE_QUESTION, connection);
                connection.Open();
                var n = command.ExecuteNonQuery();
                if (n == 1) stan = true;

                connection.Close();
            }
            return stan;
        }
    }
}
