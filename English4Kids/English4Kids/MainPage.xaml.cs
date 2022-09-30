
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace English4Kids
{
    public partial class MainPage : ContentPage
    {
        public static User Current_User = Connect_Database.CheckUser("abc");
        public MainPage()
        {
            InitializeComponent();

        }

        private void btn_study_clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new study();
        }
        private void btn_studywithvideo_clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new studywithvideo();
        }
        private void btn_login_clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new login();
        }
        private void btn_quiz_clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new Quiz();
        }
    }
}
