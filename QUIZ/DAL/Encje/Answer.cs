using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QUIZ.DAL.Encje
{
    public class Answer
    {
        public int? Id_answer { get; set; }
        public int? Id_question { get; set; }
        public string? Text { get; set; }
        public string? Is_correct { get; set; }
       
        public Answer(MySqlDataReader reader)
        {
            Id_answer = sbyte.Parse(reader["id_answer"].ToString());
            Id_question = sbyte.Parse(reader["id_question"].ToString());
            Text = reader["text"].ToString();
            Is_correct = reader["is_correct"].ToString();
        }

        public Answer(int? id_question, string? text, string? is_correct)
        {
            Id_answer = null;
            Id_question = id_question;
            Text = text;
            Is_correct = is_correct;
        }

        public override string ToString()
        {
            return $"{Text}                                                       {Is_correct}";
        }

        //metoda generuje string dla INSERT TO (nazwisko, imie, wiek, miasto)
        public string ToInsert()
        {
            int id = 0;
            return $"('{id}', '{Id_question}', '{Text}', '{Is_correct}')";
        }
    }
}
