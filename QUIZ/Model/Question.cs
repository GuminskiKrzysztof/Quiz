using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QUIZ.Model
{
    public class Question
    {
        private string text;
        private int which;
        public List<Answer> answers; 
        
        public Question()
        {
            this.text = string.Empty;   
            this.which = 0;
            this.answers = new List<Answer>();
        }

        public Question(string text, int which, List<Answer> answers)
        {
            this.text = string.Empty;
            this.which = which;
            this.answers = answers;
        }

    }
}
