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
        public sbyte? Id_answer { get; set; }
        public sbyte? Id_question { get; set; }
        public string? Text { get; set; }
        public string? Is_correct { get; set; }
       
        public Answer(MySqlDataReader reader)
        {
            Id_answer = sbyte.Parse(reader["id_answer"].ToString());
            Id_question = sbyte.Parse(reader["id_question"].ToString());
            Text = reader["text"].ToString();
            Is_correct = reader["is_correct"].ToString();
        }

        public override string ToString()
        {
            return $"{Id_answer} {Id_question} {Text} {Is_correct}";
        }

        //metoda generuje string dla INSERT TO (nazwisko, imie, wiek, miasto)
        public string ToInsert()
        {
            return $"('{Id_answer}', '{Id_question}', '{Text}', '{Is_correct}')";
        }
    }
}
