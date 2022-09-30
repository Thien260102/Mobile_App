using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;

namespace English4Kids
{
    class QuizManager
    {
        //private List<Question> questions;
        //private int score;
        private Question currentQuestion;
        private int questionCount;
        public int CorrectCount { get; set; } = 0;
        public int WrongCount { get; set; } = 0;
        public int maxQuestion;
        public QuizManager(ObservableCollection<Word> words)
        {
            questionCount = 0;
            questionCount++;
            currentQuestion = new Question(words, questionCount);
            maxQuestion = words.Count;
        }


        public Question getCurrentQuestion()
        {
            return this.currentQuestion;
        }

        public void generateQuestion()
        {
            questionCount++;
            if (this.Finish())
                return;
            currentQuestion = new Question(questionCount);
        }
        public bool Finish()
        {
            return questionCount == (maxQuestion + 1);
        }

        public void checkAnswer(string answerArg)
        {
            if (answerArg == this.currentQuestion.getAnswer())
            {
                CorrectCount++;
            }
            else
            {
                WrongCount++;
            }
        }


    }
}
