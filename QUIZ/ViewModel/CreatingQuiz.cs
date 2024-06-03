using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Linq;

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
        private Quiz currentQuiz;
        private Question currentQuestion;
        private bool correctAnswer;
        private bool incorrectAnswer;


        public CreatingQuiz(Model model)
        {
            this.model = model;
            quizzes = model.Quizzes;
            answers = model.Answers;        
            questions = model.Questions;
            CorrectAnswer = true;

            if (quizzes.Count > 0)
            {
                // Ustawienie SelectedItem na pierwszy element listy Quizzes
                CurrentQuiz = quizzes[0];
            }

            if (questions.Count > 0)
            {
                // Ustawienie SelectedItem na pierwszy element listy Questions
                CurrentQuestion = questions[0];
            }
        }

        

        public bool CorrectAnswer
        {
            get { return correctAnswer; }
            set
            {
                if (correctAnswer != value)
                {
                    correctAnswer = value;
                    onPropertyChanged(nameof(CorrectAnswer));

                    // Ensure only one radio button is checked
                    if (correctAnswer)
                    {
                        IncorrectAnswer = false;
                    }
                }
            }
        }

        public bool IncorrectAnswer
        {
            get { return incorrectAnswer; }
            set
            {
                if (incorrectAnswer != value)
                {
                    incorrectAnswer = value;
                    onPropertyChanged(nameof(IncorrectAnswer));

                    // Ensure only one radio button is checked
                    if (incorrectAnswer)
                    {
                        CorrectAnswer = false;
                    }
                }
            }
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



        public Quiz CurrentQuiz
        {
            get { return currentQuiz; }
            set
            {
                currentQuiz = value;
                onPropertyChanged(nameof(CurrentQuiz));
                if (currentQuiz != null)
                {
                    model.ShowQuestions(currentQuiz.Id);
                }
            }
        }
        public Question CurrentQuestion
        {
            get { return currentQuestion; }
            set
            {
                currentQuestion = value;
                onPropertyChanged(nameof(CurrentQuestion));
                if (currentQuestion != null)
                {
                    model.ShowAnswers(currentQuestion.Id_question);
                }
            }
        }
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

        public int WhichQuestion;

        private ICommand addQuestion = null;
        public ICommand AddQuestion
        {
            get
            {
                if (addQuestion == null)
                    addQuestion = new RelayCommand(
                        arg =>
                        {

                            WhichQuestion = questions.Count() + 1;
                            var question = new Question(CurrentQuiz.Id, QuestionText, WhichQuestion);
                                if (model.AddQuestionToDatabase(question))
                                {
                                    System.Windows.MessageBox.Show("Question was added to database! " + WhichQuestion);
                                }
                        },
                        arg => (QuestionText != "")
                        );

                return addQuestion;
            }
        }

        private ICommand addAnswer = null;
        public ICommand AddAnswer
        {
            get
            {
                if (addAnswer == null)
                    addAnswer = new RelayCommand(
                        arg =>
                        {
                            bool isCorrect = CorrectAnswer;
                            string str;
                            if (isCorrect)
                            {
                                str = "T";
                            }
                            else
                            {
                                str = "N";
                            }
                            var answer = new Answer(CurrentQuestion.Id_question, AnswerText, str);
                            if (model.AddAnswerToDatabase(answer))
                            {
                                System.Windows.MessageBox.Show("Answer was added to database!");
                            }
                        },
                        arg => (AnswerText != "") && (CorrectAnswer != null)
                        );

                return addAnswer;
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
