﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QUIZ.Model
{
    public class Answer
    {
        private string text;
        private bool is_correct;
    public Answer() 
        {
            this.text = "";
            this.is_correct = false;
        }
    public Answer(string text, bool is_correct)
    {
        this.text = text;
        this.is_correct = is_correct;
    }
    }
}