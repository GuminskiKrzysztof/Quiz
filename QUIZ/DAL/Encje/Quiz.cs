using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QUIZ.DAL.Encje
{
    public class Quiz
    {
        public sbyte? Id { get; set; }
        public int? Number_of_questions { get; set; }

        public Quiz(MySqlDataReader reader)
        {
            Id = sbyte.Parse(reader["id"].ToString());
            Number_of_questions = int.Parse(reader["Number_of_questions"].ToString());
        }

        public override string ToString()
        {
            return $"{Id} {Number_of_questions}";
        }

        //metoda generuje string dla INSERT TO (nazwisko, imie, wiek, miasto)
        public string ToInsert()
        {
            return $"('{Id}', '{Number_of_questions}')";
        }
    }
}
