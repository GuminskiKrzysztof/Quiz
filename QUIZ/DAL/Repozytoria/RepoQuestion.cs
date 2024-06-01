﻿using MySql.Data.MySqlClient;
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
    }
}