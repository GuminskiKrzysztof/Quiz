using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QUIZ.ViewModel
{
    using Model;
    using System.Collections.ObjectModel;
    using DAL.Encje;
    using BaseClass;
    class TakingQuiz
    {
        private Model model = new Model();
        private ObservableCollection<Quiz> quizzes = null;
        private ObservableCollection<Answer> answers = null;
        private ObservableCollection<Question> questions = null;

        public TakingQuiz(Model model) 
        {
            this.model = new Model();
            quizzes = model.Quizzes;
            answers = model.Answers;
            questions = model.Questions;
        }
    }
}
