using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace English4Kids
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Signup : ContentPage
    {
        public Signup()
        {
            InitializeComponent();
        }
        private void btn_Signup_clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(usernameEntry.Text) || string.IsNullOrEmpty(passwordEntry.Text))
                DisplayAlert("Đăng ký thất bại", "Vui lòng điền username và password", "Ok");
            else
            {
                if (Connect_Database.CheckUser(usernameEntry.Text) != null)
                    DisplayAlert("Đăng ký thất bại", "Đã tồn tại username, vui lòng chọn username khác", "Ok");
                else
                {
                    Connect_Database.Signup(new User()
                    {
                        USERNAME = usernameEntry.Text,
                        PASSWORD = passwordEntry.Text,
                        HOTEN = fullnameEntry.Text,
                        EMAIL = emailEntry.Text,
                    });
                    DisplayAlert("Đăng ký thành công", "Quay lại đăng nhập", "Ok");
                    App.Current.MainPage = new login();
                }
            }
            
        }
        private void btn_back_clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new login();

        }   
    }
}