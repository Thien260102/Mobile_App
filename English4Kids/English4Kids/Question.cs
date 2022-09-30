using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;

namespace English4Kids
{
    class Question
    {
        //private int firstNumber;
        //private int secondNumber;
        static ObservableCollection<Word>  question;
        List<Word> full_word = Connect_Database.GetWord();
        private string answer;
        private string[] answerArray = new string[4];
        private int answerPosition;
        //private int upperLimit;
        private string questionPhrase;

        public Question(int questionCount)
        {
            answerPosition = new Random().Next(4);
            questionPhrase = "Nghĩa của từ " + question[questionCount - 1].TU + " là:";
            answer = question[questionCount - 1].NGHIA;

            List<int> rd_answer = randomAnswer(answerPosition);
            this.answerArray[0] = full_word[rd_answer[0]].NGHIA;
            this.answerArray[1] = full_word[rd_answer[1]].NGHIA;
            this.answerArray[2] = full_word[rd_answer[2]].NGHIA;
            this.answerArray[3] = full_word[rd_answer[3]].NGHIA;

            ShuffleArray(this.answerArray);
            if(!(answerArray[0] == answer || answerArray[1] == answer || 
                answerArray[2] == answer || answerArray[3] == answer))
                this.answerArray[answerPosition] = answer;
        }
        public Question(ObservableCollection<Word> words, int questionCount)
        {

            question = words;
            answerPosition = new Random().Next(4);
            questionPhrase = "Nghĩa của từ " + question[questionCount - 1].TU + " là:";
            answer = question[questionCount - 1].NGHIA;

            List<int> rd_answer = randomAnswer(answerPosition);
            this.answerArray[0] = full_word[rd_answer[0]].NGHIA;
            this.answerArray[1] = full_word[rd_answer[1]].NGHIA;
            this.answerArray[2] = full_word[rd_answer[2]].NGHIA;
            this.answerArray[3] = full_word[rd_answer[3]].NGHIA;

            ShuffleArray(this.answerArray);

            this.answerArray[answerPosition] = question[questionCount - 1].NGHIA;


        }

        List<int> randomAnswer(int answerPosition)
        {
            List<int> ints = new List<int>();
            List<int> values = new List<int>();
            int min = 0;
            int max = full_word.Count;
            int needed = 4;

            for (int i = min; i < max; ++i)
            {
                ints.Add(i);
            }
            ints.Remove(answerPosition);

            for (int i = 0; i < needed; ++i)
            {
                int index = new Random().Next(0, ints.Count);
                values.Add(ints[index]);
                ints.RemoveAt(index);
            }
            return values;
        }

        public string[] getAnswerArray()
        {
            return this.answerArray;
        }

        public void setQuestionPhrase(string questionPhrase)
        {
            this.questionPhrase = questionPhrase;
        }

        public string getQuestionPhrase()
        {
            return questionPhrase;
        }

        public string getAnswer()
        {
            return this.answer;
        }

        public void ShuffleArray(string[] array)
        {
            int randomIndex = new Random().Next(4);
            for (int i = 0; i < array.Length; i++)
            {
                string temp = array[randomIndex];
                array[randomIndex] = array[i];
                array[i] = temp;
            }

        }
    }
}
