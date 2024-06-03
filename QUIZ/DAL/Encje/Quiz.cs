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
        public int? Id { get; set; }
        public string? Name { get; set; }
        public int? Number_of_questions { get; set; }

        public Quiz(MySqlDataReader reader)
        {
            Id = sbyte.Parse(reader["id"].ToString());
            Name = reader["name"].ToString();
            Number_of_questions = int.Parse(reader["Number_of_questions"].ToString());
        }

        public Quiz(string? name, int? number_of_questions)
        {
            Id = null;
            Name = name;
            Number_of_questions = number_of_questions;
        }

        public Quiz(int? id, string? name, int? number_of_questions)
        {
            Id = id;
            Name = name;
            Number_of_questions = number_of_questions;
        }


        public override string ToString()
        {
            return $"{Id}                        {Name}                     {Number_of_questions}";
        }

        //metoda generuje string dla INSERT TO (nazwisko, imie, wiek, miasto)
        public string ToInsert()
        {
            int id = 0;
            return $"({id}, '{Name}', '{Number_of_questions}')";
        }
    }
}
