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
        public List<Answer> answers; 
        
        public Question()
        {
            this.text = string.Empty;   
            this.answers = new List<Answer>();
        }

        public Question(string text, List<Answer> answers)
        {
            this.text = string.Empty;
            this.answers = answers;
        }

    }
}
