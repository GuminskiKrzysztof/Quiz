using QUIZ.QUIZ.ViewModel.BaseClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QUIZ.ViewModel
{
    using global::QUIZ.DAL.Encje;
    using QUIZ.Model;
    using System.Collections.ObjectModel;
    using System.Windows.Input;

    class CreatingQuiz:ViewModelBase
    {
        private Model model;
        private ObservableCollection<Quiz> quizzes = null;
        private ObservableCollection<Answer> answers = null;
        private ObservableCollection<Question> questions = null;
        private string questionText;

        public CreatingQuiz(Model model)
        {
            this.model = model;
            quizzes = model.Quizzes;
            answers = model.Answers;        
            questions = model.Questions;
        }

        public string QuestionText
        {
            get { return questionText; }
            set
            {
                questionText = value;
                onPropertyChanged(nameof(QuestionText));
            }
        }
        public Quiz CurrentQuiz { get; set; }
        public ObservableCollection<Quiz> Quizzes
        {
            get { return quizzes; }
            set
            {
                quizzes = value;
                onPropertyChanged(nameof(Quizzes));
            }
        }
        public ObservableCollection<Answer> Answers { get; set; }
        public ObservableCollection<Question> Questions { get; set; }

        public void RefreshQuizzes() => Quizzes = model.Quizzes;

        private ICommand loadQuizzes = null;
        public ICommand LoadQuizzes
        { 
            get
            {
                if (loadQuizzes == null)
                    loadQuizzes = new RelayCommand(
                        arg =>
                        {
                            Quizzes = model.LoadAllQuizzes(CurrentQuiz);
                        },
                        arg => true
                        );
                return loadQuizzes;
            }
                
        }

    }
}
