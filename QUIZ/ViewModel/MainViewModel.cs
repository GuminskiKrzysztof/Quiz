using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System;
using System.Globalization;
using System.Windows.Data;

namespace QUIZ.ViewModel
{
    using DAL.Encje;
    using Model;
    using System.Collections.ObjectModel;
    using System.Globalization;
    using System.Windows.Data;

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
