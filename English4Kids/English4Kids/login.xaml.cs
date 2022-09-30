using System;
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
    public partial class login : ContentPage
    {
        
        public login()
        {
            InitializeComponent();
        }
        private void btn_home_clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new MainPage();
        }
        private void btn_Login_clicked(object sender, EventArgs e)
        {
            User user = Connect_Database.CheckUser(usernameEntry.Text);   
            if (user != null && user.PASSWORD == passwordEntry.Text)
            {
                MainPage.Current_User = user;
                DisplayAlert("Thành công", "Đăng nhập thành công", "Ok");
                App.Current.MainPage = new MainPage();
            }
            else
                DisplayAlert("Thất bại", "Sai tên đăng nhập hoặc mật khẩu.", "Ok");
        }
        private void btn_Signup_clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new Signup();
        }
    }
}