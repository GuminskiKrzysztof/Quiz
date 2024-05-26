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
        public sbyte? Id_quiz { get; set; }
        public sbyte? Id_question { get; set; }
        public string? Text { get; set; }
        public int? Which { get; set; }

        public Question(MySqlDataReader reader)
        {
            Id_quiz = sbyte.Parse(reader["id_answer"].ToString());
            Id_question = sbyte.Parse(reader["id_question"].ToString());
            Text = reader["text"].ToString();
            Which = int.Parse(reader["is_correct"].ToString());
        }

        public override string ToString()
        {
            return $"{Id_quiz} {Id_question} {Text} {Which}";
        }

        //metoda generuje string dla INSERT TO (nazwisko, imie, wiek, miasto)
        public string ToInsert()
        {
            return $"('{Id_quiz}', '{Id_question}', '{Text}', '{Which}')";
        }
    }
}
