using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QUIZ.Model
{
    public class Quiz
    {
        private int number_of_questions;
        public List<Question> question_list;   
    
        public Quiz()
        {
            this.number_of_questions = 0;
            this.question_list = new List<Question>();
        }
        public Quiz(int number_of_questions, List<Question> question_list)
        {
            this.number_of_questions = number_of_questions;
            this.question_list = question_list;
        }   
    }
}
