using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace QUIZ.Model
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

        public ObservableCollection<Quiz> LoadAllQuizzes(Quiz quiz)
        {
            var quizzes = new ObservableCollection<Quiz>();
            foreach (var it in Quizzes)
            {
                quizzes.Add(it);
            }
            return quizzes;
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

        public void ShowQuestions(int? idQuiz)
        {
            Questions.Clear();
            var questions = RepoQuestion.GetQuestionsByQuizId(idQuiz);
            foreach (var question in questions)
            {
                Questions.Add(question);
            }
        }

        public void ShowAnswers(int? questionId)
        {
            Answers.Clear();
            var answers = RepoAnswer.GetAnswersByQuestionId(questionId);
            foreach (var answer in answers)
            {
                Answers.Add(answer);
            }
        }


        public bool EditQuiz(string? quizName, int? number_of_questions, int? idQuiz)
        {
            if (RepoQuiz.EditQuiz(quizName, number_of_questions, idQuiz))
            {
                for (int i = 0; i < Quizzes.Count; i++)
                {
                    if (Quizzes[i].Id == idQuiz)
                    {
                        Quizzes.RemoveAt(i);
                        Quiz quiz = new Quiz(idQuiz, quizName, number_of_questions);
                        Quizzes.Insert(i, quiz);
                    }
                    
                }
                return true;
            }
            return false;
        }

        public bool DeleteQuiz(int? idQuiz)
        {
            if (RepoQuiz.DeleteQuiz(idQuiz))
            {
                for (int i = 0; i < Quizzes.Count; i++)
                {
                    if (Quizzes[i].Id == idQuiz)
                    {
                        Quizzes.RemoveAt(i);
                    }

                }
                return true;
            }
            return false;
        }


        public bool EditQuestion(string? questionText, int? idQuestion)
        {
            if (RepoQuestion.EditQuestion(questionText, idQuestion))
            {
                for (int i = 0; i < Questions.Count; i++)
                {
                    if (Questions[i].Id_question == idQuestion)
                    {
                        int? idQuiz = Questions[i].Id_quiz;
                        int? which = Questions[i].Which;
                        Questions.RemoveAt(i);
                        Question question = new Question(idQuestion, idQuiz, questionText, which);
                        Questions.Insert(i, question);
                    }

                }
                return true;
            }
            return false;
        }

        public bool DeleteQuestion(int? idQuiz)
        {
            if (RepoQuestion.DeleteQuestion(idQuiz))
            {
                for (int i = 0; i < Questions.Count; i++)
                {
                    if (Questions[i].Id_question == idQuiz)
                    {
                        Questions.RemoveAt(i);
                    }

                }
                return true;
            }
            return false;
        }

        public bool EditAnswer(string? answerText, string? isCorrect, int? idAnswer)
        {
            if (RepoAnswer.EditAnswer(answerText, isCorrect, idAnswer))
            {
                for (int i = 0; i < Answers.Count; i++)
                {
                    if (Answers[i].Id_answer == idAnswer)
                    {
                        int? idQuestion = Answers[i].Id_question;
                        Answers.RemoveAt(i);

                        Answer answer = new Answer(idAnswer, idQuestion, answerText, isCorrect);
                        Answers.Insert(i, answer);
                    }

                }
                return true;
            }
            return false;
        }

        public bool DeleteAnswer(int? idAnswer)
        {
            if (RepoAnswer.DeleteAnswer(idAnswer))
            {
                for (int i = 0; i < Answers.Count; i++)
                {
                    if (Answers[i].Id_answer == idAnswer)
                    {
                        Answers.RemoveAt(i);
                    }

                }
                return true;
            }
            return false;
        }

    }
}
