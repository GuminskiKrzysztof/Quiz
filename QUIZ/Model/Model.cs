using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace QUIZ.QUIZ.Model
{
    using DAL.Encje;
    using DAL.Repozytoria;
    using System.Collections.ObjectModel;
    class Model
    {
        public ObservableCollection<Quiz> Quizzes { get; set; } = new ObservableCollection<Quiz>();
        public ObservableCollection<Answer> Answers { get; set; } = new ObservableCollection<Answer>();
        public ObservableCollection<Question> Questions { get; set; } = new ObservableCollection<Question>();
        public Model()
        {
            var quizzes = RepoQuiz.GetAllQuizes();
            foreach (var quiz in quizzes)
            {   
                Quizzes.Add(quiz);
            }

            var answers = RepoAnswer.GetAllAnswers();
            foreach (var answer in answers)
            {
                Answers.Add(answer);
            }

            var questions = RepoQuestion.GetAllQuestions();
            foreach (var question in questions)
            {
                Questions.Add(question);
            }
        }

        public bool AddQuizToDatabase(Quiz quiz)
        {
            if (RepoQuiz.AddQuizToDatabase(quiz))
            {
                Quizzes.Add(quiz);
                return true;
            }
            return false;
        }

        public bool AddAnswerToDatabase(Answer answer)
        {
            if (RepoAnswer.AddAnswerToDatabase(answer))
            {
                Answers.Add(answer);
                return true;
            }
            return false;
        }

        public bool AddQuestionToDatabase(Question question)
        {
            if (RepoQuestion.AddQuestionToDatabase(question))
            {
                Questions.Add(question);
                return true;
            }
            return false;
        }
    }
}
