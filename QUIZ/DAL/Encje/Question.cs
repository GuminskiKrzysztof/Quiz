using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QUIZ.DAL.Encje
{
    public class Question
    {
        public int? Id_quiz { get; set; }
        public int? Id_question { get; set; }
        public string? Text { get; set; }
        public int? Which { get; set; }

        public Question(MySqlDataReader reader)
        {
            Id_quiz = sbyte.Parse(reader["id_question"].ToString());
            Id_question = sbyte.Parse(reader["id_question"].ToString());
            Text = reader["text"].ToString();
            Which = int.Parse(reader["which"].ToString());
        }

        public Question(int? idQuiz, string? text, int? which)
        {
            Id_quiz = idQuiz;
            Id_question = null;
            Text = text;
            Which = which;
        }
        public override string ToString()
        {
            return $"{Id_quiz} {Id_question} {Text} {Which}";
        }

        //metoda generuje string dla INSERT TO (nazwisko, imie, wiek, miasto)
        public string ToInsert()
        {
            int id = 0;
            return $"('{Id_quiz}', '{id}', '{Text}', '{Which}')";
        }
    }
}
