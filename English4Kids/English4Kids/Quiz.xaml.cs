using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace English4Kids
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Quiz : ContentPage
    {
        public ObservableCollection<Word> Words { get; set; } = new ObservableCollection<Word>();
        //List<Studied> studied = new List<Studied>();
        //public ArrayList answers = new ArrayList();
        QuizManager quizManager;
        public Quiz()
        {
            InitializeComponent();
            
            ToDoList();
            
        }
        void ToDoList()
        {
            foreach (var item in Connect_Database.GetStudiedByUSERNAME(MainPage.Current_User.USERNAME))
                Words.Add(Connect_Database.GetWordByMATU(item.MATU));
            if (Words.Count == 0)
            {
                DisplayAlert("Không thể làm quiz", "Phải học trước khi làm quiz", "Ok");
                return;
            }
            But1.IsVisible = But2.IsVisible = But3.IsVisible = But4.IsVisible = true;
            quizManager = new QuizManager(Words);
            //correctLabel.Text = "Correct = " + quizManager.CorrectCount;
            //wrongLabel.Text = "Wrong = " + quizManager.WrongCount;
            updateView();
        }

        private void But_Clicked(object sender, EventArgs e)
        {

            Button btn = (Button)sender;
            
            switch (btn.StyleId)
            {
                case "1":
                    quizManager.checkAnswer(But1.Text);
                    break;
                case "2":
                    quizManager.checkAnswer(But2.Text);
                    break;
                case "3":
                    quizManager.checkAnswer(But3.Text);
                    break;
                case "4":
                    quizManager.checkAnswer(But4.Text);
                    break;
            }

            Finish();
            quizManager.generateQuestion();
            updateView();
            Finish();
        }
        private void Finish()
        {
            if (quizManager.Finish())
            {
                DisplayAlert("Hoàn thành", "Số câu đúng trên tổng số là " +
                    quizManager.CorrectCount + '/' + Words.Count, "Ok");
                App.Current.MainPage = new MainPage();
                return;
            }
        }
        private void updateView()
        {
            
            correctLabel.Text = "Correct = " + quizManager.CorrectCount;
            wrongLabel.Text = "Wrong = " + quizManager.WrongCount;
            But1.Text = quizManager.getCurrentQuestion().getAnswerArray()[0].ToString();
            But2.Text = quizManager.getCurrentQuestion().getAnswerArray()[1].ToString();
            But3.Text = quizManager.getCurrentQuestion().getAnswerArray()[2].ToString();
            But4.Text = quizManager.getCurrentQuestion().getAnswerArray()[3].ToString();

            questionText.Text = quizManager.getCurrentQuestion().getQuestionPhrase();


        }
        private void btn_Nop_clicked(object sender, EventArgs e)
        {
            
        }
        private void btn_home_clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new MainPage();
        }

        
    }
}