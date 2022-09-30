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
    public partial class Video : ContentPage
    {
        public Video(string url)
        {
            InitializeComponent();
            Browser.Source = url;
        }
        private void btn_back_clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new studywithvideo();
        }
    }
}