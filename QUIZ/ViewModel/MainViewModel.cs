using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QUIZ.ViewModel
{
    using QUIZ.Model;
    class MainViewModel
    {
        private Model model = new Model();

        public CreatingQuiz CreateQuiz { get; set; }
        public TakingQuiz TakeQuiz { get; set; }

        public MainViewModel() 
        {
            CreateQuiz = new CreatingQuiz(model);
            TakeQuiz = new TakingQuiz(model);
        }


    }
}
