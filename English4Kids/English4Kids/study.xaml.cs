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
    public partial class study : ContentPage
    {
        public study()
        {
            InitializeComponent();

        }

        private void btn_home_clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new MainPage();
        }

        private void btn_ABC_clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new study_ABC();
        }
        private void btn_Color_clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new study_Color();
        }
        private void btn_Number_clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new study_Number();
        }
    }
}