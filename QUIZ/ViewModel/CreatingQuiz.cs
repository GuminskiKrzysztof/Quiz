using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace QUIZ.ViewModel
{
    using DAL.Encje;
    using Model;
    using BaseClass;
    using System.Windows.Input;

    class CreatingQuiz:ViewModelBase
    {
        private Model model;
        private ObservableCollection<Quiz> quizzes = null;
        private ObservableCollection<Answer> answers = null;
        private ObservableCollection<Question> questions = null;
        private string numberOfQuestions;
        private string quizName;
        private string answerText;
        private string questionText;

        public CreatingQuiz(Model model)
        {
            this.model = model;
            quizzes = model.Quizzes;
            answers = model.Answers;        
            questions = model.Questions;

        }

        public string NumberOfQuestions
        {
            get { return numberOfQuestions; }
            set
            {
                numberOfQuestions = value;
                onPropertyChanged(nameof(NumberOfQuestions));
            }
        }

        public string QuizName
        {
            get { return quizName; }
            set
            {
                quizName = value;
                onPropertyChanged(nameof(QuizName));
            }
        }

        public string AnswerText
        {
            get { return answerText; }
            set
            {
                answerText = value;
                onPropertyChanged(nameof(AnswerText));
            }
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
        public Quiz CurrentQuestion { get; set; }
        public Quiz CurrentAnswer { get; set; }

        public ObservableCollection<Quiz> Quizzes
        {
            get { return quizzes; }
            set
            {
                quizzes = value;
                onPropertyChanged(nameof(Quizzes));
            }
        }
        public ObservableCollection<Answer> Answers 
        { 
            get { return answers; }
            set
            {
                answers = value;
                onPropertyChanged(nameof(Answers));
            }
        }
        public ObservableCollection<Question> Questions 
        {
            get { return questions; }
            set
            {
                questions = value;
                onPropertyChanged(nameof(Questions));
            }
        }

        public void RefreshQuizzes() => Quizzes = model.Quizzes;

        

        private ICommand addQuiz = null;
        public ICommand AddQuiz
        {
            get
            {
                if (addQuiz == null)
                    addQuiz = new RelayCommand(
                        arg =>
                        {
                            int parsedNumberOfQuestions;
                            if (int.TryParse(NumberOfQuestions, out parsedNumberOfQuestions))
                            {
                                var quiz = new Quiz(QuizName, parsedNumberOfQuestions);

                                if (model.AddQuizToDatabase(quiz))
                                {
                                    System.Windows.MessageBox.Show("Quiz was added to database!");
                                }
                            }
                        },
                        arg => (QuizName != "") && (NumberOfQuestions != "") 
                        );

                return addQuiz;
            }
        }

        public int WhichQuestion = 0;

        private ICommand addQuestion = null;
        public ICommand AddQuestion
        {
            get
            {
                if (addQuestion == null)
                    addQuestion = new RelayCommand(
                        arg =>
                        {

                            WhichQuestion++;
                            var question = new Question(CurrentQuiz.Id, QuestionText, WhichQuestion);
                                if (model.AddQuestionToDatabase(question))
                                {
                                    System.Windows.MessageBox.Show("Question was added to database!");
                                }
                        },
                        arg => (QuestionText != "")
                        );

                return addQuestion;
            }
        }


        private ICommand loadAllQuizzes = null;
        public ICommand LoadAllQuizzes
        { 
            get
            {
                if (loadAllQuizzes == null)
                    loadAllQuizzes = new RelayCommand(
                        arg =>
                        {
                            Quizzes = model.Quizzes;
                        },
                        arg => true
                        );
                return loadAllQuizzes;
            }
                
        }

    }
}
