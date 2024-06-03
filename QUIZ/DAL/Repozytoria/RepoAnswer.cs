using MySql.Data.MySqlClient;
using QUIZ.DAL.Encje;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QUIZ.DAL.Repozytoria
{
    class RepoAnswer
    {
        private const string ALL_ANSWERS = "SELECT * FROM answers";
        private const string ADD_ANSWERS =
            "INSERT INTO `answers` VALUES ";
        public static List<Answer> GetAllAnswers()
        {
            List<Answer> answers = new List<Answer>();

            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand(ALL_ANSWERS, connection);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                    answers.Add(new Answer(reader));
                connection.Close();
            }

            return answers;
        }

        public static bool AddAnswerToDatabase(Answer answer)
        {
            bool check = false;
            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command =
                    new MySqlCommand($"{ADD_ANSWERS} {answer.ToInsert()}", connection);
                connection.Open();
                var n = command.ExecuteNonQuery();
                check = true;
                answer.Id_answer = (sbyte)command.LastInsertedId;
                connection.Close();
            }
            return check;
        }

        public static List<Answer> GetAnswersByQuestionId(int? questionId)
        {
            List<Answer> answers = new List<Answer>();
            string query = $"{ALL_ANSWERS} WHERE id_question = @questionId";

            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@questionId", questionId);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                    answers.Add(new Answer(reader));
                connection.Close();
            }

            return answers;
        }
    }
}
