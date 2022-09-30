
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace English4Kids
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            new Connect_Database();
            MainPage = new MainPage();
            //Connect_Database.DeleteAllStudied();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
